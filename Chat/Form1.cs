﻿using System;
using System.Data;
using System.Windows.Forms;
using RethinkDb.Driver;
using RethinkDb.Driver.Net.Clustering;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            //Stablish connection to RethinkDB Server that is running on Raspberry
            var conn = r.ConnectionPool().Seed(new[] { "192.168.0.184:28015", "192.168.1.202:28015", "192.168.1.189:28015" });
            conn.PoolingStrategy(new EpsilonGreedyHostPool(new TimeSpan(0, 1, 0), EpsilonCalculator.Linear())).Discover(true);
            pool = conn.Connect();

            //Get all messages from RethinkDB
            List<Mensagem> all_messages = r.Db("chat").Table("chattable").OrderBy("Data").Run<List<Mensagem>>(pool);


            DataTable dt = new DataTable();
            //Load all previous messages to the listbox of messages
            foreach (var message in all_messages)
            {
                //Create message
                Mensagem msg = new Mensagem(message.Id, message.Data, message.Username, message.Msg);
                //Adding Message to Listbox
                lb_chat.Items.Add(msg);
            }
            focus_last_message();

            //Calling and running the task
            Task.Run(() => HandleUpdates(pool, lb_chat));
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
                    focus_last_message();

                    //Writing the message on the Database    
                    r.Db("chat").Table("chattable").Insert(new Mensagem { Data = DateTime.Now, Username = username, Msg = message_text }).Run(pool);

                    //Clean up
                    tb_mensagem.Text = "";
                    lb_username.Text = username;
                }
            }
        }
        //Waits for changes in the database and updates the listbox with new messages
        public static async Task HandleUpdates(ConnectionPool pool, ListBox lb_chat)
        {
            //Create a feed that waits for a new message to reach the database
            var feed = await r.Db("chat").Table("chattable").Changes().RunChangesAsync<Mensagem>(pool);
            //Take the feed and create a message
            foreach (var message in feed)
            {
                if (message.NewValue != null)
                {
                    Mensagem msg = new Mensagem(message.NewValue.Id, message.NewValue.Data, message.NewValue.Username, message.NewValue.Msg);
                    try
                    {
                        //Invoke listbox from the Form to the thread to be able to use it
                        lb_chat.Invoke(new Action(() => lb_chat.Items.Add(msg)));
                        if (lb_chat.Items.Count != 0)
                        {
                            lb_chat.Invoke(new Action(() => lb_chat.SetSelected(lb_chat.Items.Count - 1, true)));
                            lb_chat.Invoke(new Action(() => lb_chat.SetSelected(lb_chat.Items.Count - 1, false)));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro");
                    }
                }
                else
                {
                    lb_chat.Invoke(new Action(() => lb_chat.Items.Remove(lb_chat.SelectedItem)));
                }
                //Create message
            }
        }
        //Selecting a message from the listbox to delete
        private void lb_chat_DoubleClick(object sender, EventArgs e)
        {
            //Checks if selected item has a message
            if (lb_chat.SelectedItem != null)
            {
                //Check if message was sent by user
                Mensagem msg = lb_chat.SelectedItem as Mensagem;
                //Allows to delete if message belongs to user
                if (msg.Username == lb_username.Text)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this message?" + "\n" + "\n" + msg.Username + ": " + msg.Msg, "DELETE MESSAGE", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        //Deletes message from database and listbox
                        r.Db("chat").Table("chattable").Get(msg.Id).Delete().Run(pool);

                    }
                }
            }
        }

        //Focus on the last message (this is for the listbox to automaticly scroll down to the last message)
        public void focus_last_message()
        {
            if (lb_chat.Items.Count != 0)
            {
                lb_chat.SetSelected(lb_chat.Items.Count - 1, true);
                lb_chat.SetSelected(lb_chat.Items.Count - 1, false);
            }
        }
    }
}


