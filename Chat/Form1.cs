using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Windows.Forms;


namespace Chat
{
    public partial class Form1 : Form
    {
        private string conStr = @"Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};" + @"DBQ=\\DESKTOP-EJB4FV8\SharedDatabase\BaseDados.xls;ReadOnly=0;";
        private string conStr2 = @"Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};" + @"DBQ=\\LAPTOP-DD74SLHJ\baseDados\BaseDadoss.xls;ReadOnly=0;";
        public int id_message_my_file;
        public int id_message_outside_file;


        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OdbcConnection con = new OdbcConnection(conStr);
            OdbcConnection con2 = new OdbcConnection(conStr2);
            
            //query strings
            string query = "select Distinct(Id), Username, Mensagem, Data from [Folha1$] ";

            con.Open();
            OdbcCommand cmd = new OdbcCommand(query, con);
            
            
            //Load all previous messages to the listbox of messages
            dt.Load(cmd.ExecuteReader());
            List<DataRow> drList = dt.AsEnumerable().ToList();
            foreach (DataRow str in drList)
            {
                // Mensagem mensagem = new Mensagem(Date, "Select Mensagem From [Folha1$]", "Select Username From [Folha1$]"); ;
                String msgem = "(" + str.ItemArray[3].ToString() + ") " + str.ItemArray[1].ToString() + ": " + str.ItemArray[2].ToString();
                lb_chat.Items.Add(msgem);
            }
            con.Close();
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
                else if (string.IsNullOrWhiteSpace(tb_mensagem.Text));
                //if everything is ok successfully send and save message
                else
                {
                    OdbcConnection con = new OdbcConnection(conStr);
                    OdbcConnection con2 = new OdbcConnection(conStr2);

                    string query_last_id = "SELECT TOP 1 * FROM [Folha1$] ORDER BY ID DESC";

                    OdbcCommand cmd_last_id = new OdbcCommand(query_last_id, con);
                    con.Open();
                    con2.Open();

                    //Get the Id of the last message sent on my file
                    OdbcDataReader reader = cmd_last_id.ExecuteReader();
                    while (reader.Read())
                    {
                        id_message_my_file = reader.GetInt32(0);
                    }

                    //Get the Id of the last message sent on the outside file
                    OdbcCommand cmd_last_id_outside_file = new OdbcCommand(query_last_id, con2);
                    OdbcDataReader reader2 = cmd_last_id_outside_file.ExecuteReader();
                    while (reader2.Read())
                    {
                        id_message_outside_file = reader2.GetInt32(0);
                    }

                    Mensagem mensagem = new Mensagem(DateTime.Now, tb_mensagem.Text, tb_username.Text);
                    lb_chat.Items.Add(mensagem);
                    id_message_my_file = id_message_my_file + 1;
                    id_message_outside_file = id_message_outside_file + 1;
                    string username = tb_username.Text;
                    string message_text = tb_mensagem.Text;
                    lb_username.Text = username;
                    tb_mensagem.Text = "";

                    //string query
                    string query = "insert into [Folha1$] (Id, Username, Mensagem, Data) values (?, ?, ?, ?)";

                    //Writing on my local Excel File located in my shared folder
                    OdbcCommand cmd = new OdbcCommand(query, con);
                    cmd.Parameters.AddWithValue("?", id_message_my_file);
                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", message_text);
                    cmd.Parameters.AddWithValue("?", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //Writing on another computer's Excel File located in their shared folder
                    OdbcCommand cmd2 = new OdbcCommand(query, con2);
                    cmd2.Parameters.AddWithValue("?", id_message_outside_file);
                    cmd2.Parameters.AddWithValue("?", username);
                    cmd2.Parameters.AddWithValue("?", message_text);
                    cmd2.Parameters.AddWithValue("?", DateTime.Now);
                    cmd2.ExecuteNonQuery();
                    con2.Close();
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

