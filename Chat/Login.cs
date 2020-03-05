using RethinkDb.Driver;
using RethinkDb.Driver.Net.Clustering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class Login : Form
    {
        public static RethinkDB r = RethinkDB.R;
        public ConnectionPool pool;

        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textbox_username.Text;
            string password = textbox_password.Text;



            List<Users> all_users = r.Db("chat").Table("users").OrderBy("Username").Run<List<Users>>(pool);
            bool cont = false;
           
            
                foreach (var us in all_users)
                {
                    string use = us.Username;
                    if (use.ToString().Contains(textbox_username.Text))
                    {
                        cont = true;
                        Form1 ga = new Form1();
                        ga.ShowDialog();
                        
                        break;

                    }


                }
                if(cont == false)
            {
                MessageBox.Show("Não está Registado!");
            }
          
          



        }

        private void Login_Load(object sender, EventArgs e)
        {
            var conn = r.ConnectionPool().Seed(new[] { "192.168.0.184:28015", "192.168.1.202:28015", "192.168.1.189:28015" });
            conn.PoolingStrategy(new EpsilonGreedyHostPool(new TimeSpan(0, 1, 0), EpsilonCalculator.Linear())).Discover(true);

            pool = conn.Connect();






        }

        private void button2_Click(object sender, EventArgs e)
        {

            string username = textbox_username.Text;
            string password = textbox_password.Text;


           
            List<Users> all_users = r.Db("chat").Table("users").OrderBy("Username").Run<List<Users>>(pool);

            bool cont = true;

                foreach (var us in all_users)
                {
                    string use = us.Username;
                    if (use.ToString().Contains(textbox_username.Text))
                    {
                    cont =false;
                        MessageBox.Show("Ja existe o Username!");

                    break;
                    }
                    
             

            }

            if (cont  ==true)
            {
                r.Db("chat").Table("users").Insert(new Users { Username = username, Password = password }).Run(pool);
                lb_alert.Text = "Registo efetuado com sucesso!";

            }
          
               

            





        }


    }
    }




        
    

