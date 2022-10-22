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
    public partial class Delete : Form
    {
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=project_final");
        MySqlCommand comm;
        int x = 1;
        private void open_connection()
        {
            con.Open();
            //MessageBox.Show($"MySQL version : {con.ServerVersion}");
        }
        public Delete()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Delete_Load(object sender, EventArgs e)
        {
            open_connection();
            Load_all();
        }
        private void search_Load(object sender, EventArgs e)
        {
            open_connection();
            
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


           var Employee_id = employee_id.Text;
            var Comment = comment.Text;
            string DateStart = dateStart.Value.ToString("yyyy-MM-dd");
            string DateEnd = dateEnd.Value.ToString("yyyy-MM-dd");

            comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO `project_final`.`leaving` (`idLeve`,`Employee_id`,`dateStart`,`dateEnd`,`comment`) " +
                             "VALUES " + "(@idLeve,@Employee_id,@dateStart,@dateEnd,@comment)";

            comm.Parameters.AddWithValue("@idLeve", 0);
            comm.Parameters.AddWithValue("@Employee_id", Employee_id);
            comm.Parameters.AddWithValue("@dateStart", DateStart);
            comm.Parameters.AddWithValue("@dateEnd", DateEnd);
            comm.Parameters.AddWithValue("@comment", Comment);
            
            try
            {
                int rowsAffected = comm.ExecuteNonQuery();
                MessageBox.Show("Save Data Completed!");
                Load_all();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Load_all()
        {
             string sql = "SELECT `employee`.`Employee_id`,`employee`.`nameThai`,`leaving`.`dateStart`,`leaving`.`dateEnd`" +
                 " FROM `project_final`.`employee`"
                 + "inner join leaving on `employee`.`Employee_id` = `leaving`.`Employee_id`";
            //string sql = "select * from project_final.employee";

            comm = new MySqlCommand(sql, con);
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            da.Fill(ds, "employee");
            dataGridView1.DataSource = ds.Tables["employee"].DefaultView;
            //dataGridView1.Columns[8].DefaultCellStyle.Format = "yyyy-MM-dd";
        }
        private void Load_search()
        {
            var ID = employee_id.Text;
            string sql = "SELECT `employee`.`Employee_id`,`employee`.`nameThai`,`leaving`.`dateStart`,`leaving`.`dateEnd`,`leaving`.`comment`" +
                " FROM `project_final`.`employee`"
                + "inner join leaving on `employee`.`Employee_id` = `leaving`.`Employee_id`"
                + "where `employee`.`Employee_id` = "+ID;
            //string sql = "select * from project_final.employee";

            comm = new MySqlCommand(sql, con);
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            da.Fill(ds, "employee");
            dataGridView1.DataSource = ds.Tables["employee"].DefaultView;
            //dataGridView1.Columns[8].DefaultCellStyle.Format = "yyyy-MM-dd";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var newForm = new Home();
            newForm.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ID = employee_id.Text;
            try
            {
                if (ID == "")
                {
                    MessageBox.Show("Input data please!");
                }
                else
                {
                    Load_search();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
