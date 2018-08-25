using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Railway_Ticket_management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myconnection = "datasource=localhost;port=3306;username=root;password=tuba";
                MySqlConnection myconn = new MySqlConnection(myconnection);
                MySqlDataAdapter mydataadapter = new MySqlDataAdapter();
                mydataadapter.SelectCommand = new MySqlCommand(" select * from mar.login ;", myconn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(mydataadapter);
                myconn.Open();
                DataSet ds = new DataSet();
                //MessageBox.Show("connected");
                myconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string myconnection = "datasource=localhost;port=3306;username=root;password=tuba";
                MySqlConnection myconn = new MySqlConnection(myconnection);

                MySqlCommand selectcommand = new MySqlCommand("select * from mar.login where username = '" + this.textBox1.Text + "' and password= '" + this.textBox2.Text + "' ;", myconn);

                MySqlDataReader myreader;
                myconn.Open();
                myreader = selectcommand.ExecuteReader();
                int count = 0;
                while (myreader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!");
                }
                myconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

