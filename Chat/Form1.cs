using System;
using System.Data;
using System.Windows.Forms;
using RethinkDb.Driver;
using RethinkDb.Driver.Net.Clustering;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;

namespace Chat
{
    public partial class Form1 : Form
    {
        public static RethinkDB r = RethinkDB.R;
        public ConnectionPool pool;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Stablish connection to RethinkDB Server that is running on Raspberr
            var conn = r.ConnectionPool().Seed(new[] { "192.168.0.184:28015", "192.168.1.202:28015", "192.168.1.189:28015" });
            conn.PoolingStrategy(new EpsilonGreedyHostPool(new TimeSpan(0, 1, 0), EpsilonCalculator.Linear())).Discover(true);

            pool = conn.Connect();

            //Get all messages from RethinkDB
            List<Mensagem> all_messages = r.Db("chat").Table("chattable").OrderBy("Data").Run<List<Mensagem>>(pool);


            //Load all previous messages to the listbox of messages
            foreach (var message in all_messages)
            {
                //Create message
                string msgem = "(" + message.Data + ") " + message.Username + ": " + message.Msg;
                //Adding Message to Listbox
                lb_chat.Items.Add(msgem);
            }

            //Scroll to the last entry
            if (lb_chat.Items.Count != 0)
            {
                lb_chat.SetSelected(lb_chat.Items.Count - 1, true);
                lb_chat.SetSelected(lb_chat.Items.Count - 1, false);
            }

            //Calling and running the task
            Task.Run(() => HandleUpdates(pool,lb_chat));
        }


        private void Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            //Checks if Enter key is pressed on the Textbox
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //if shift is pressed, enter will paragraph
                if (e.Shift)
                {
                    tb_mensagem.AppendText(Environment.NewLine);
                }
                //if there is no username available enter will warn that it needs a username
                else if (tb_username.Text.Length == 0)
                {
                    MessageBox.Show("Preencha todos os campos");
                }
                //if message textbox is empty it wont do anything
                else if (string.IsNullOrWhiteSpace(tb_mensagem.Text)) ;
                //if everything is ok successfully send and save message
                else
                {
                    //getting the information to a variable
                    string username = tb_username.Text;
                    string message_text = tb_mensagem.Text;
                    //Creating a message
                    Mensagem mensagem = new Mensagem { Data = DateTime.Now, Username = username, Msg = message_text };

                    //Writing the message on the Listbox
                    if (lb_chat.Items.Count != 0)
                    {
                        lb_chat.SetSelected(lb_chat.Items.Count - 1, true);
                        lb_chat.SetSelected(lb_chat.Items.Count - 1, false);
                    }

                    //Writing the message on the Database    
                    r.Db("chat").Table("chattable").Insert(new Mensagem { Data = DateTime.Now, Username = username, Msg = message_text }).Run(pool);

                    //Clean up
                    tb_mensagem.Text = "";
                    lb_username.Text = username;
                }
            }
        }
        private void lb_chat_DoubleClick(object sender, EventArgs e)
        {
            //Check if message was sent by user
            //Allows to delete
        }
        public static async Task HandleUpdates(ConnectionPool pool, ListBox lb_chat)
        {
            //Create a feed that waits for a new message to reach the database
            var feed = await r.Db("chat").Table("chattable").Changes().RunChangesAsync<Mensagem>(pool);
            //Take the feed and create a message
            foreach (var message in feed)
            {
                //Create message
                string msgem = "(" + message.NewValue.Data + ") " + message.NewValue.Username + ": " + message.NewValue.Msg;
                try
                {
                    //Invoke listbox from the Form to the thread to be able to use it
                    lb_chat.Invoke(new Action(() => lb_chat.Items.Add(msgem)));
                    lb_chat.Invoke(new Action(() => lb_chat.SetSelected(lb_chat.Items.Count - 1, true)));
                    lb_chat.Invoke(new Action(() => lb_chat.SetSelected(lb_chat.Items.Count - 1, false)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}


