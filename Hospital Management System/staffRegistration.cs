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
    public partial class staffRegistration : Form
    {
        public staffRegistration()
        {
            InitializeComponent();
            fillCombo();
            showTable();
            textBox4.Text=DateTime.Now.ToString(@"dd\/mm\/yyyy h\:mm tt");
            
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

       private void fillCombo() {
            string quary = "SELECT * FROM depertment";
            SqlCommand command = new SqlCommand(quary, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                   // string dname = reader["Column1"].ToString();
                    comboBox3.Items.Add(reader[1].ToString());
                }

                con.Close();
            }
            catch { }
        }

       private void showTable()
       {
           SqlConnection con = new SqlConnection("Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True");
           con.Open();
           SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM staffinfo", con);
           DataTable dt = new DataTable();
           sda.Fill(dt);
           dataGridView1.DataSource = dt;
           con.Close();
       }

       private void save() {
           string insertCommand = "INSERT INTO staffinfo(staffID,FirstName,LastName,Address,Gender,BloodGroup,DateOfBirth,EducationalQualification,Depertment,Designation,DateOfJoining,DateOfRetirement,MobileNo,EmailID) " +
                                       "VALUES(@staffID,@FirstName,@LastName,@Address,@Gender,@BloodGroup,@DateOfBirth,@EducationalQualification,@Depertment,@Designation,@DateOfJoining,@DateOfRetirement,@MobileNo,@EmailID)";
           SqlCommand command = new SqlCommand(insertCommand, con);

           SqlParameter p1 = new SqlParameter("@staffID", textBox8.Text);
           command.Parameters.Add(p1);
           SqlParameter p2 = new SqlParameter("@FirstName", textBox1.Text);
           command.Parameters.Add(p2);
           SqlParameter p3 = new SqlParameter("@LastName", textBox2.Text);
           command.Parameters.Add(p3);
           SqlParameter p4 = new SqlParameter("@Address", textBox3.Text);
           command.Parameters.Add(p4);
           SqlParameter p5 = new SqlParameter("@Gender", comboBox1.Text);
           command.Parameters.Add(p5);
           SqlParameter p6 = new SqlParameter("@BloodGroup", comboBox2.Text);
           command.Parameters.Add(p6);
           SqlParameter p7 = new SqlParameter("@DateOfBirth", dateTimePicker1.Text);
           command.Parameters.Add(p7);
           SqlParameter p8 = new SqlParameter("@EducationalQualification", textBox6.Text);
           command.Parameters.Add(p8);
           SqlParameter p9 = new SqlParameter("@Depertment", comboBox3.Text);
           command.Parameters.Add(p9);
           SqlParameter p10 = new SqlParameter("@Designation", comboBox4.Text);
           command.Parameters.Add(p10);
           SqlParameter p11 = new SqlParameter("@DateOfJoining", dateTimePicker2.Text);
           command.Parameters.Add(p11);
           SqlParameter p12 = new SqlParameter("@DateOfRetirement", dateTimePicker3.Text);
           command.Parameters.Add(p12);
           SqlParameter p13 = new SqlParameter("@MobileNo", textBox4.Text);
           command.Parameters.Add(p13);
           SqlParameter p14 = new SqlParameter("@EmailID", textBox5.Text);
           command.Parameters.Add(p14);
           
           con.Open();
           command.ExecuteNonQuery();
           MessageBox.Show("Save Successfull !!");
           con.Close();
       
       }

       private void delete()
       {
           string deleteCommand = "DELETE FROM staffinfo WHERE staffID=@staffID";
           SqlCommand command = new SqlCommand(deleteCommand, con);

           SqlParameter p1 = new SqlParameter("@staffID", textBox8.Text);
           command.Parameters.Add(p1);

           con.Open();
           command.ExecuteNonQuery();
           MessageBox.Show("Delete Successfull !!");
           con.Close();
       }

       private void search()
       {

           con.Open();
           SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM staffinfo WHERE staffID LIKE ('" + textBox8.Text + "%')", con);
           DataTable dt = new DataTable();
           sda.Fill(dt);
           dataGridView1.DataSource = dt;
           con.Close();
       }

       private void update()
       {
           string updateCommand = "UPDATE staffinfo SET staffID=@staffID,FirstName=@FirstName,LastName=@LastName,Address=@Address,Gender=@Gender,BloodGroup=@BloodGroup,DateOfBirth=@DateOfBirth,EducationalQualification=@EducationalQualification,Depertment=@Depertment,Designation=@Designation,DateOfJoining=@DateOfJoining,DateOfRetirement=@DateOfRetirement,MobileNo=@MobileNo,EmailID=@EmailID " +
                                     "WHERE staffID=@staffID";
           SqlCommand command = new SqlCommand(updateCommand, con);

           SqlParameter p1 = new SqlParameter("@staffID", textBox8.Text);
           command.Parameters.Add(p1);
           SqlParameter p2 = new SqlParameter("@FirstName", textBox1.Text);
           command.Parameters.Add(p2);
           SqlParameter p3 = new SqlParameter("@LastName", textBox2.Text);
           command.Parameters.Add(p3);
           SqlParameter p4 = new SqlParameter("@Address", textBox3.Text);
           command.Parameters.Add(p4);
           SqlParameter p5 = new SqlParameter("@Gender", comboBox1.Text);
           command.Parameters.Add(p5);
           SqlParameter p6 = new SqlParameter("@BloodGroup", comboBox2.Text);
           command.Parameters.Add(p6);
           SqlParameter p7 = new SqlParameter("@DateOfBirth", dateTimePicker1.Text);
           command.Parameters.Add(p7);
           SqlParameter p8 = new SqlParameter("@EducationalQualification", textBox6.Text);
           command.Parameters.Add(p8);
           SqlParameter p9 = new SqlParameter("@Depertment", comboBox3.Text);
           command.Parameters.Add(p9);
           SqlParameter p10 = new SqlParameter("@Designation", comboBox4.Text);
           command.Parameters.Add(p10);
           SqlParameter p11 = new SqlParameter("@DateOfJoining", dateTimePicker2.Text);
           command.Parameters.Add(p11);
           SqlParameter p12 = new SqlParameter("@DateOfRetirement", dateTimePicker3.Text);
           command.Parameters.Add(p12);
           SqlParameter p13 = new SqlParameter("@MobileNo", textBox4.Text);
           command.Parameters.Add(p13);
           SqlParameter p14 = new SqlParameter("@EmailID", textBox5.Text);
           command.Parameters.Add(p14);

           con.Open();
           command.ExecuteNonQuery();
           MessageBox.Show("Update Successfull !!");
           con.Close();
       }

        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure to delete this Depertment ??",
                                    "Confirm Delete!!",
                                    MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                delete();
            }
            else
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

          

            textBox8.Text = row.Cells["staffID"].Value.ToString();
            textBox1.Text = row.Cells["FirstName"].Value.ToString();
            textBox2.Text = row.Cells["LastName"].Value.ToString();
            textBox3.Text = row.Cells["Address"].Value.ToString();
            comboBox1.Text = row.Cells["Gender"].Value.ToString();
            comboBox2.Text = row.Cells["BloodGroup"].Value.ToString();
            dateTimePicker1.Text = row.Cells["DateOfBirth"].Value.ToString();
            textBox6.Text = row.Cells["EducationalQualification"].Value.ToString();
            comboBox3.Text = row.Cells["Depertment"].Value.ToString();
            comboBox4.Text = row.Cells["Designation"].Value.ToString();
            dateTimePicker2.Text = row.Cells["DateOfJoining"].Value.ToString();
            dateTimePicker3.Text = row.Cells["DateOfRetirement"].Value.ToString();
            textBox4.Text = row.Cells["MobileNo"].Value.ToString();
            textBox5.Text = row.Cells["EmailID"].Value.ToString();
           
        }
    }
}
