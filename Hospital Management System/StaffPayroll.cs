using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_Management_System
{
    public partial class StaffPayroll : Form
    {
        public StaffPayroll()
        {
            InitializeComponent();
            textBox4.Text = DateTime.Now.ToString(@"dd\/mm\/yyyy h\:mm tt");
            textBox29.Text = DateTime.Now.ToString(@"dd\/mm\/yyyy h\:mm tt");
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        private void save()
        {
            string insertCommand = "INSERT INTO staffsalary(StaffID,StaffName,Depertment,BasicSalary,OvertimeCharge,PF,MiscDeduction,TravelAllowance,MedicalAllowance,ESI) " +
                                           "VALUES(@StaffID,@StaffName,@Depertment,@BasicSalary,@OvertimeCharge,@PF,@MiscDeduction,@TravelAllowance,@MedicalAllowance,@ESI)";
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@StaffID", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@StaffName", textBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@Depertment", textBox3.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@BasicSalary", textBox5.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@OvertimeCharge", textBox6.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@PF", textBox7.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@MiscDeduction", textBox8.Text);
            command.Parameters.Add(p7);
            SqlParameter p8 = new SqlParameter("@TravelAllowance", textBox9.Text);
            command.Parameters.Add(p8);
            SqlParameter p9 = new SqlParameter("@MedicalAllowance", textBox10.Text);
            command.Parameters.Add(p9);
            SqlParameter p10 = new SqlParameter("@ESI", textBox11.Text);
            command.Parameters.Add(p10);


            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Save Successfull !!");
            con.Close();

        }
        private void update()
        {
            string updateCommand = "UPDATE staffsalary SET BasicSalary=@BasicSalary,OvertimeCharge=@OvertimeCharge,PF=@PF,MiscDeduction=@MiscDeduction,TravelAllowance=@TravelAllowance,MedicalAllowance=@MedicalAllowance,ESI=@ESI " +
                                         "WHERE StaffID=@StaffID";
            SqlCommand command = new SqlCommand(updateCommand, con);

            SqlParameter p1 = new SqlParameter("@StaffID", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p4 = new SqlParameter("@BasicSalary", textBox5.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@OvertimeCharge", textBox6.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@PF", textBox7.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@MiscDeduction", textBox8.Text);
            command.Parameters.Add(p7);
            SqlParameter p8 = new SqlParameter("@TravelAllowance", textBox9.Text);
            command.Parameters.Add(p8);
            SqlParameter p9 = new SqlParameter("@MedicalAllowance", textBox10.Text);
            command.Parameters.Add(p9);
            SqlParameter p10 = new SqlParameter("@ESI", textBox11.Text);
            command.Parameters.Add(p10);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Update Successfull !!");
            con.Close();
        }

        private void showSalaryDetails()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM staffsalary", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void search()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM staffsalary WHERE staffID LIKE ('" + textBox12.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string quary = "SELECT * FROM staffinfo WHERE staffID='" + textBox1.Text + "'";
            SqlCommand command = new SqlCommand(quary, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    textBox2.Text = reader[1].ToString();
                    textBox3.Text = reader[8].ToString();
                }

                con.Close();
            }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT staffid,firstname,lastname,depertment FROM staffinfo", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            showSalaryDetails();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["StaffID"].Value.ToString();
                textBox2.Text = row.Cells["StaffName"].Value.ToString();
                textBox3.Text = row.Cells["Depertment"].Value.ToString();
                textBox5.Text = row.Cells["BasicSalary"].Value.ToString();
                textBox6.Text = row.Cells["OvertimeCharge"].Value.ToString();
                textBox7.Text = row.Cells["PF"].Value.ToString();
                textBox8.Text = row.Cells["MiscDeduction"].Value.ToString();
                textBox9.Text = row.Cells["TravelAllowance"].Value.ToString();
                textBox10.Text = row.Cells["MedicalAllowance"].Value.ToString();
                textBox11.Text = row.Cells["ESI"].Value.ToString();
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string quary = "SELECT * FROM staffsalary WHERE staffID='" + textBox13.Text + "'";
            SqlCommand command = new SqlCommand(quary, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    textBox14.Text = reader[2].ToString();
                    textBox15.Text = reader[1].ToString();
                    textBox16.Text = reader[3].ToString();
                    textBox21.Text = reader[8].ToString();
                    textBox22.Text = reader[7].ToString();
                    textBox26.Text = reader[6].ToString();
                    textBox24.Text = reader[5].ToString();
                    textBox25.Text = reader[9].ToString();
                }

                con.Close();
            }
            catch { }
        }

        private void salaryCalculate()
        {

            int basicsalary = int.Parse(textBox16.Text);

            int daysworked = int.Parse(textBox17.Text);

            int daysabsent = int.Parse(textBox18.Text);
            int workedtakaperday = int.Parse(textBox20.Text);
            int absenttakaperday = int.Parse(textBox23.Text);
            int overtimehours = int.Parse(textBox19.Text);
            int overtimetakaperhour = int.Parse(textBox27.Text);

            int travilling = int.Parse(textBox22.Text);
            int medical = int.Parse(textBox21.Text);
            int pf = int.Parse(textBox24.Text);
            int esi = int.Parse(textBox25.Text);
            int misc = int.Parse(textBox26.Text);

            int netSalary;
           
            netSalary = basicsalary + (daysworked * workedtakaperday) - (daysabsent * absenttakaperday) + (overtimehours * overtimetakaperhour) + travilling + medical - (pf + esi + misc);

            textBox28.Text = netSalary.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            salaryCalculate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox17.Text, "[^0-9]"))
            {
                
                MessageBox.Show("Please enter only numbers.","Error");
               // textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox17.Text = null; ;
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox20.Text, "[^0-9]"))
            {

                MessageBox.Show("Please enter only numbers.", "Error");
                textBox20.Text = null; ;
            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox18.Text, "[^0-9]"))
            {

                MessageBox.Show("Please enter only numbers.", "Error");
                textBox18.Text = null; ;
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox23.Text, "[^0-9]"))
            {

                MessageBox.Show("Please enter only numbers.", "Error");
                textBox23.Text = null; ;
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox19.Text, "[^0-9]"))
            {

                MessageBox.Show("Please enter only numbers.", "Error");
                textBox19.Text = null; ;
            }
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox27.Text, "[^0-9]"))
            {

                MessageBox.Show("Please enter only numbers.", "Error");
                textBox27.Text = null;
            }
        }
    }
}
