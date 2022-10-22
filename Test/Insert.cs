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
    public partial class Insert : Form
    {
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=project_final");
        MySqlCommand comm;
        int x = 1;
        private void open_connection()
         {
             con.Open();
             //MessageBox.Show($"MySQL version : {con.ServerVersion}");
         }


        public Insert()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            var newForm = new Home();
            newForm.Show();
            this.Hide();
        }



        private void Save_Click(object sender, EventArgs e)
        {
            var Namethai = namethai.Text;
            var NameEng = nameeng.Text;
            var Sex = sex.SelectedIndex;
            var Age = age.Text;
            var Idcard = idcard.Text;
            string Dob_date = dob.Value.ToString("yyyy-MM-dd");
            var Address = address.Text;
            var Tel = tel.Text;
            var Skill = skill.Text;
            var Position = position.SelectedIndex;
            var Degree = degree.SelectedIndex;
            var Grade = grade.Text;
            var University = university.SelectedIndex;
            var Branch = branch.SelectedIndex;

       
            comm = con.CreateCommand();
            comm.CommandText = "INSERT INTO `project_final`.`employee` (`Employee_id`,`position_id`,`grade`,`nameThai`,`nameEng`,`sex`,`age`,`idCard`,`birthDate`,`address`,`tel`,`skill`,`dgreeBG_id`,`University_id`,`Schedule_id`) " +
                 "VALUES " + "(@Employee_id,@position_id,@grade,@nameThai,@nameEng,@sex,@age,@idCard,@birthDate,@address,@tel,@skill,@dgreeBG_id,@University_id,@Schedule_id)";


            if (Sex == 0)
            {
                comm.Parameters.AddWithValue("@sex", "ชาย");
            }
            else if (Sex == 1)
            {
                comm.Parameters.AddWithValue("@sex", "หญิง");
            }
            else
            {
                comm.Parameters.AddWithValue("@sex", "Unknow");
            }


            comm.Parameters.AddWithValue("@Employee_id", 0);
            comm.Parameters.AddWithValue("@position_id", Position+1);
            comm.Parameters.AddWithValue("@grade", Grade);
            comm.Parameters.AddWithValue("@nameThai", Namethai);
            comm.Parameters.AddWithValue("@nameEng", NameEng);
            comm.Parameters.AddWithValue("@age", Age);
            comm.Parameters.AddWithValue("@idCard", Idcard);
            comm.Parameters.AddWithValue("@birthDate", Dob_date);
            comm.Parameters.AddWithValue("@address", Address);
            comm.Parameters.AddWithValue("@tel", Tel);
            comm.Parameters.AddWithValue("@skill", Skill);
            comm.Parameters.AddWithValue("@dgreeBG_id", Degree+1);
            comm.Parameters.AddWithValue("@University_id", University+1);
            comm.Parameters.AddWithValue("@Schedule_id", Branch + 1);

            if (x == 1)
            {
                open_connection();
                x++;
            }

            try
            {
                int rowsAffected = comm.ExecuteNonQuery();
                MessageBox.Show("Save Data Completed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
           


        }
        private void namethai_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void university_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void position_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void sex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grade_TextChanged(object sender, EventArgs e)
        {

        }
        private void T_clear_data()
        {
            namethai.Text = "";
            nameeng.Text = "";
            sex.Text = "";
            age.Text = "";
            idcard.Text = "";
            position.SelectedIndex = -1;
            tel.Text = "";
            address.Text = "";
            skill.Text = "";
            degree.SelectedIndex = -1;
            grade.Text = "";
            university.SelectedIndex = -1;
            sex.SelectedIndex = -1;
            branch.SelectedIndex = -1;
            dob.Value = DateTime.Now;



        }
        private void button2_Click(object sender, EventArgs e)
        {
            T_clear_data();
        }

        private void address_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
