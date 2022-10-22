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

namespace Test
{
 
    public partial class Home : Form
    {
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=project_final");
        MySqlCommand comm;
        private void open_connection()
        {
            //con.Open();
            //MessageBox.Show($"MySQL version : {con.ServerVersion}");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            open_connection();
        }
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Select
            var newForm = new Select();
            newForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Insert
            var newForm = new Insert();
            newForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var newForm = new Update();
            newForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Delete
            var newForm = new Delete();
            newForm.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
