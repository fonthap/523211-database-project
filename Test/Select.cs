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
    public partial class Select : Form
    {
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=project_final");
        MySqlCommand comm;
       
        public Select()
        {
            InitializeComponent();
        }
        private void open_connection()
        {
            con.Open();
            //MessageBox.Show($"MySQL version : {con.ServerVersion}");
        }
        private void select_Load(object sender, EventArgs e)
        {
            open_connection();
            Load_all();
            //Select_Load();



        }


            private void Load_all()
        {
            string sql = "SELECT * FROM project_final.employee";
            comm = new MySqlCommand(sql, con);
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            da.Fill(ds, "employee");
            dataGridView1.DataSource = ds.Tables["employee"].DefaultView;
            //dataGridView1.Columns[8].DefaultCellStyle.Format = "yyyy-MM-dd";
        }
       

            private void Select_Load()
        {
            var ID = textBox1.Text;
            //string sql = "SELECT Employee_id,nameThai,nameEng,sex,age,grade,tel from project_final.employee  where employee.Employee_id = " + ID;
       
            string sql =
            "SELECT `employee`.`Employee_id`,`employee`.`nameThai`,`employee`.`nameEng`,`employee`.`sex`,`employee`.`age`,`employee`.`grade`,`employee`.`tel`,`position`.`positionName`,`position`.`salary`,`department`.`DepartmentName`,`schedule`.`timeWork`,`schedule`.`StopWork` "//"//FROM project_final.employee inner join leaving on employee.Employee_id = leaving.Employee_id WHERE  employee.Employee_id =+ ID;
            + "FROM `project_final`.`employee`"
            //+ "inner join leaving on `employee`.`Employee_id` = `leaving`.`Employee_id`"
            +"inner join position on `employee`.`position_id` = `position`.`position_id`"
            + "inner join department on `position`.`Department_id` = `department`.`Department_id`"
            + "inner join schedule on `employee`.`Schedule_id` = `schedule`.`idSchedule`"
            + "WHERE `employee`.`Employee_id` =" + ID;
          

            comm = new MySqlCommand(sql, con);
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            da.Fill(ds,"employee");
            dataGridView1.DataSource = ds.Tables["employee"].DefaultView;
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void T_clear_data()
        {
            textBox1.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var ID = textBox1.Text;

            try
            {
                if (ID == "")
                {
                    MessageBox.Show("Input Data please!");
                }
                else {
                    Select_Load();
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var newForm = new Home();
            newForm.Show();
            this.Hide();
        }
    }
}
