using System;
using System.Data;
using System.Windows.Forms;
using RethinkDb.Driver;
using RethinkDb.Driver.Net.Clustering;

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
            conn.PoolingStrategy(new EpsilonGreedyHostPool(new TimeSpan(0,1,0), EpsilonCalculator.Linear())).Discover(true);

            pool = conn.Connect();

            //Get all messages from RethinkDB
            var all_messages = r.Db("chat").Table("chattable").Run(pool);

            DataTable dt = new DataTable();
            //Load all previous messages to the listbox of messages
            foreach (var message in all_messages)
            {
                //Getting Date in Epoch format
                double date = message.GetValue("Data").GetValue("epoch_time");
                //Create message
                string msgem = "(" + new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(date) + ") " + message.GetValue("Username") + ": " + message.GetValue("Msg");
                //Adding Message to Listbox
                lb_chat.Items.Add(msgem);
            }

            //Scroll to the last entry
            if (lb_chat.Items.Count != 0)
            {
                lb_chat.SetSelected(lb_chat.Items.Count - 1, true);
                lb_chat.SetSelected(lb_chat.Items.Count - 1, false);
            }
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
                    //Get the Id of the last message sent

                    string username = tb_username.Text;
                    string message_text = tb_mensagem.Text;
                    Mensagem mensagem = new Mensagem { Data = DateTime.Now, Username = username, Msg = message_text};
                    lb_chat.Items.Add(mensagem);
                    tb_mensagem.Text = "";
                    lb_username.Text = username;
                    lb_chat.SetSelected(lb_chat.Items.Count - 1, true);
                    lb_chat.SetSelected(lb_chat.Items.Count - 1, false);

                    //Writing on the database    
                    r.Db("chat").Table("chattable").Insert(mensagem).Run(pool);


                    }
            }
        }
        private void lb_chat_DoubleClick(object sender, EventArgs e)
        {
            //Check if message was sent by user
            //Allows to delete
        }

    }
}

