using RethinkDb.Driver;
using RethinkDb.Driver.Net.Clustering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

        //Login
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textbox_username.Text;
            string password = textbox_password.Text;

            byte[] hash;
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] hashdata = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                hash = hashdata;
            }

            string result = System.Text.Encoding.UTF8.GetString(hash);

            List<Users> all_users = r.Db("chat").Table("users").OrderBy("Username").Run<List<Users>>(pool);
            bool cont = false;

            foreach (var us in all_users)
            {
                string use = us.Username;
                string pwd = us.Password;
                if (use.ToString().Equals(textbox_username.Text) && pwd.ToString().Equals(result))
                {
                    cont = true;
                    Chat ga = new Chat(textbox_username.Text);
                    ga.ShowDialog();
                    break;
                }

            }
            if (cont == false)
            {
                MessageBox.Show("Dados incorretos ou não está Registado!");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            var conn = r.ConnectionPool().Seed(new[] { "192.168.0.184:28015", "192.168.1.202:28015", "192.168.1.189:28015" });
            conn.PoolingStrategy(new EpsilonGreedyHostPool(new TimeSpan(0, 1, 0), EpsilonCalculator.Linear())).Discover(true);
            pool = conn.Connect();
        }



        private void button_registo_Click(object sender, EventArgs e)
        {
            string username = textbox_username.Text;
            string password = textbox_password.Text;

            byte[] hash;
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] hashdata = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                hash = hashdata;
            }
            string result = System.Text.Encoding.UTF8.GetString(hash);

            List<Users> all_users = r.Db("chat").Table("users").OrderBy("Username").Run<List<Users>>(pool);

            bool cont = true;

            foreach (var us in all_users)
            {

                string use = us.Username;

                if (use.ToString().Equals(textbox_username.Text))
                {
                
                    cont = false;
                    MessageBox.Show("Ja existe o Username!");

                    break;
                }
            }

            if (cont == true)
            {


                r.Db("chat").Table("users").Insert(new Users { Username = username, Password = result }).Run(pool);
                lb_alert.Text = result;
            }
        }
    }
}







