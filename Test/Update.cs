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
    public partial class Update : Form
    {
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=project_final");
        MySqlCommand comm;
        public Update()
        {
            InitializeComponent();
        }
        private void open_connection()
        {
            con.Open();
            //MessageBox.Show($"MySQL version : {con.ServerVersion}");
        }
        private void update_Load(object sender, EventArgs e)
        {
            open_connection();
            Load_all();

        }
        private void Load_all()
        {
            string sql =
            "SELECT `employee`.`Employee_id`,`employee`.`position_id`,`employee`.`nameThai`,`employee`.`nameEng`,`employee`.`address`,`employee`.`tel`,`position`.`positionName` "//"//FROM project_final.employee inner join leaving on employee.Employee_id = leaving.Employee_id WHERE  employee.Employee_id =+ ID;
            + "FROM `project_final`.`employee`"
            + "inner join position on `employee`.`position_id` = `position`.`position_id`"
            + "inner join department on `position`.`Department_id` = `department`.`Department_id`";
            comm = new MySqlCommand(sql, con);
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            da.Fill(ds, "employee");
            datagridview_update.DataSource = ds.Tables["employee"].DefaultView;

        }
       

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void datagridview_update_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datagridview_update_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datagridview_update.SelectedRows.Count >= 0) // make sure user select at least 1 row 
            {
                string ID = datagridview_update.SelectedRows[0].Cells[0].Value.ToString();
                string Position = datagridview_update.SelectedRows[0].Cells[1].Value.ToString();
                string Namethai = datagridview_update.SelectedRows[0].Cells[2].Value.ToString();
                string Nameeng = datagridview_update.SelectedRows[0].Cells[3].Value.ToString();
                string Address = datagridview_update.SelectedRows[0].Cells[4].Value.ToString();
                string Tel = datagridview_update.SelectedRows[0].Cells[5].Value.ToString();
                



                textBox1.Text = Namethai;
                textBox2.Text = Nameeng;
                textBox4.Text = Address;
                textBox3.Text = Tel;
                textBox5.Text = ID;

               if (Position != "")
                 {
                     position.SelectedIndex = int.Parse(Position) -1;
                 }
               

            }
        }
        private void update_search_Load()
        {
            var ID = textBox5.Text;
            string sql =
            "SELECT `employee`.`Employee_id`,`employee`.`nameThai`,`employee`.`nameEng`,`employee`.`tel`,`position`.`positionName` "//"//FROM project_final.employee inner join leaving on employee.Employee_id = leaving.Employee_id WHERE  employee.Employee_id =+ ID;
            + "FROM `project_final`.`employee`"
            + "inner join position on `employee`.`position_id` = `position`.`position_id`"
            + "inner join department on `position`.`Department_id` = `department`.`Department_id`"
            + "WHERE `employee`.`Employee_id` =" + ID;


            comm = new MySqlCommand(sql, con);
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            da.Fill(ds, "employee");
            datagridview_update.DataSource = ds.Tables["employee"].DefaultView;


        }
        private void button4_Click(object sender, EventArgs e)
        {
            var ID = textBox5.Text;

            try
            {
                if (ID == "")
                {
                    MessageBox.Show("Input Data please!");
                }
                else
                {
                    update_search_Load();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var ID = textBox5.Text;
            var Namethai = textBox1.Text;
            var NameEng = textBox2.Text;
            var Address = textBox4.Text;
            var Tel = textBox3.Text;
            var Position = position.SelectedIndex;

            /*comm.CommandText = "UPDATE `project_database`.`Teacher` " +
                "SET `Teacher_name` = @Teacher_name, `Gender`= @Gender,`DOB`= @DOB " +
                "WHERE `Teacher_id` = @Teacher_id";
            "SET `Teacher_name` = (@Employee_id,@position_id,@nameThai,@nameEng,@address,@tel)";*/
            comm = con.CreateCommand();
            comm.CommandText = "UPDATE `project_final`.`employee` "  +
               "SET `Employee_id` = @Employee_id, `position_id`= @position_id,`nameThai`= @nameThai ,`nameEng`= @nameEng,`address`= @address,`tel`= @tel " +
                "WHERE `Employee_id` = @Employee_id"; 


            comm.Parameters.AddWithValue("@Employee_id", ID);
            comm.Parameters.AddWithValue("@position_id", Position+1);
            comm.Parameters.AddWithValue("@nameThai", Namethai);
            comm.Parameters.AddWithValue("@nameEng", NameEng);
            comm.Parameters.AddWithValue("@address", Address);
            comm.Parameters.AddWithValue("@tel", Tel);


            try
            {
                int rowsAffected = comm.ExecuteNonQuery();
                MessageBox.Show("Update Data Completed!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Load_all();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            var ID = textBox5.Text;

            comm = con.CreateCommand();
            comm.CommandText = "DELETE FROM  `project_final`.`employee` " +
                "WHERE `Employee_id` = @Employee_id";

            comm.Parameters.AddWithValue("@Employee_id", ID);


            try
            {
                int rowsAffected = comm.ExecuteNonQuery();
                MessageBox.Show("Delete Data Completed!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Load_all();
        }
        
        
        
        
        
        
        
        
        private void T_clear_data()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            position.SelectedIndex = -1;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            T_clear_data();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var newForm = new Home();
            newForm.Show();
            this.Hide();
        }
    }
}
