using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Windows.Forms;
using RethinkDb.Driver;
using RethinkDb.Driver.Net;
using RethinkDb.Driver.Net.Clustering;

namespace Chat
{
    public partial class Form1 : Form
    {
        public static RethinkDB r = RethinkDB.R;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            //Stablish connection to RethinkDB Server that is running on Raspberr
            try
            {
                var conn = r.ConnectionPool().Seed(new[] { "192.168.0.184:28015", "192.168.1.202:28015" });

                conn.PoolingStrategy(new RoundRobinHostPool(new TimeSpan(0,1,0),new TimeSpan(0, 1, 0))).Discover(true);

                ConnectionPool pool = conn.Connect();
                var result = r.Now().Run<DateTimeOffset>(pool);
                //var result = r.Now().Run<DateTimeOffset>(conn);
                //Connection conn = r.Connection().Hostname("192.168.1.184").Port(28015).Db("chattable").Connect();
                
            }
            catch (Exception ex)
            {
                
            }


            //Get all messages from RethinkDB
            //r.Table("chattable").Insert(date:DateTime.Now, username:"John Doe", mensagem:"Yo yo, waddup waddup");


            //Get all previous message records

            //Load all previous messages to the listbox of messages

            /*DataTable dt = new DataTable();
            dt.load(cmd.executereader());
            list<datarow> drlist = dt.asenumerable().tolist();
            foreach (datarow str in drlist)
            {
                // mensagem mensagem = new mensagem(date, "select mensagem from [folha1$]", "select username from [folha1$]"); ;
                string msgem = "(" + str.itemarray[3].tostring() + ") " + str.itemarray[1].tostring() + ": " + str.itemarray[2].tostring();
                lb_chat.items.add(msgem);
            }*/

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


                    Mensagem mensagem = new Mensagem(DateTime.Now, tb_mensagem.Text, tb_username.Text);
                    lb_chat.Items.Add(mensagem);
                    //id_message_my_file = id_message_my_file + 1;
                    //id_message_outside_file = id_message_outside_file + 1;
                    string username = tb_username.Text;
                    string message_text = tb_mensagem.Text;
                    lb_username.Text = username;
                    tb_mensagem.Text = "";
                    lb_chat.SetSelected(lb_chat.Items.Count - 1, true);
                    lb_chat.SetSelected(lb_chat.Items.Count - 1, false);

                    //Writing on the database                    
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

