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
    public partial class InPatient : Form
    {
        public InPatient()
        {
            InitializeComponent();
            fillDepertmentCombo();
            fillRoomTypeCombo();
            showTable();
            textBox6.Text = DateTime.Now.ToString(@"dd\/mm\/yyyy h\:mm tt");
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);


        private void fillDepertmentCombo()
        {
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
                    comboBox5.Items.Add(reader[1].ToString());
                }

                con.Close();
            }
            catch { }
        }

        private void fillRoomTypeCombo()
        {
            string quary = "SELECT * FROM roominfo";
            SqlCommand command = new SqlCommand(quary, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // string dname = reader["Column1"].ToString();
                    comboBox6.Items.Add(reader[2].ToString());
                }

                con.Close();
            }
            catch { }
        }

        private void showTable()
        {
            SqlConnection con = new SqlConnection("Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM inpatient", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void save()
        {
            string insertCommand = "INSERT INTO inpatient(PatientID,FirstName,LastName,Gender,Occupation,DateOfBirth,Age,BloodGroup,MaritalStatus,Address,City,Country,PIN,ContactNo,Depertment,ConsultantName,RoomType,RoomNumber,date) " +
                                                 "VALUES(@PatientID,@FirstName,@LastName,@Gender,@Occupation,@DateOfBirth,@Age,@BloodGroup,@MaritalStatus,@Address,@City,@Country,@PIN,@ContactNo,@Depertment,@ConsultantName,@RoomType,@RoomNumber,@date)";
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@PatientID", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@FirstName", textBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@LastName", textBox3.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@Gender", comboBox1.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@Occupation", textBox4.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@DateOfBirth", dateTimePicker1.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@Age", textBox5.Text);
            command.Parameters.Add(p7);
            SqlParameter p8 = new SqlParameter("@BloodGroup", comboBox3.Text);
            command.Parameters.Add(p8);
            SqlParameter p9 = new SqlParameter("@MaritalStatus", comboBox4.Text);
            command.Parameters.Add(p9);
            SqlParameter p10 = new SqlParameter("@Address", textBox7.Text);
            command.Parameters.Add(p10);
            SqlParameter p11 = new SqlParameter("@City", textBox8.Text);
            command.Parameters.Add(p11);
            SqlParameter p12 = new SqlParameter("@Country", textBox9.Text);
            command.Parameters.Add(p12);
            SqlParameter p13 = new SqlParameter("@PIN", textBox10.Text);
            command.Parameters.Add(p13);
            SqlParameter p14 = new SqlParameter("@ContactNo", textBox11.Text);
            command.Parameters.Add(p14);
            SqlParameter p15 = new SqlParameter("@Depertment", comboBox5.Text);
            command.Parameters.Add(p15);
            SqlParameter p16 = new SqlParameter("@ConsultantName", textBox12.Text);
            command.Parameters.Add(p16);
            SqlParameter p17 = new SqlParameter("@RoomType", comboBox6.Text);
            command.Parameters.Add(p17);
            SqlParameter p18 = new SqlParameter("@RoomNumber", textBox13.Text);
            command.Parameters.Add(p18);
            SqlParameter p19 = new SqlParameter("@date", textBox6.Text);
            command.Parameters.Add(p19);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Save Successfull !!");
            con.Close();

        }

        private void update()
        {
            string updateCommand = "UPDATE inpatient SET PatientID=@PatientID,FirstName=@FirstName,LastName=@LastName,Gender=@Gender,Occupation=@Occupation,DateOfBirth=@DateOfBirth,Age=@Age,BloodGroup=@BloodGroup,MaritalStatus=@MaritalStatus,Address=@Address,City=@City,Country=@Country,PIN=@PIN,ContactNo=@ContactNo,Depertment=@Depertment,ConsultantName=@ConsultantName,RoomType=@RoomType,RoomNumber=@RoomNumber,date=@date " +
                                     "WHERE PatientID=@PatientID";
            SqlCommand command = new SqlCommand(updateCommand, con);

            SqlParameter p1 = new SqlParameter("@PatientID", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@FirstName", textBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@LastName", textBox3.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@Gender", comboBox1.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@Occupation", textBox4.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@DateOfBirth", dateTimePicker1.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@Age", textBox5.Text);
            command.Parameters.Add(p7);
            SqlParameter p8 = new SqlParameter("@BloodGroup", comboBox3.Text);
            command.Parameters.Add(p8);
            SqlParameter p9 = new SqlParameter("@MaritalStatus", comboBox4.Text);
            command.Parameters.Add(p9);
            SqlParameter p10 = new SqlParameter("@Address", textBox7.Text);
            command.Parameters.Add(p10);
            SqlParameter p11 = new SqlParameter("@City", textBox8.Text);
            command.Parameters.Add(p11);
            SqlParameter p12 = new SqlParameter("@Country", textBox9.Text);
            command.Parameters.Add(p12);
            SqlParameter p13 = new SqlParameter("@PIN", textBox10.Text);
            command.Parameters.Add(p13);
            SqlParameter p14 = new SqlParameter("@ContactNo", textBox11.Text);
            command.Parameters.Add(p14);
            SqlParameter p15 = new SqlParameter("@Depertment", comboBox5.Text);
            command.Parameters.Add(p15);
            SqlParameter p16 = new SqlParameter("@ConsultantName", textBox12.Text);
            command.Parameters.Add(p16);
            SqlParameter p17 = new SqlParameter("@RoomType", comboBox6.Text);
            command.Parameters.Add(p17);
            SqlParameter p18 = new SqlParameter("@RoomNumber", textBox13.Text);
            command.Parameters.Add(p18);
            SqlParameter p19 = new SqlParameter("@date", textBox6.Text);
            command.Parameters.Add(p19);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Update Successfull !!");
            con.Close();

        }

        private void delete()
        {
            string deleteCommand = "DELETE FROM inpatient WHERE PatientID=@PatientID";
            SqlCommand command = new SqlCommand(deleteCommand, con);

            SqlParameter p1 = new SqlParameter("@PatientID", textBox1.Text);
            command.Parameters.Add(p1);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Delete Successfull !!");
            con.Close();
        }

        private void search()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM inpatient WHERE PatientID LIKE ('" + textBox1.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            //PatientID,FirstName,LastName,Gender,Occupation,DateOfBirth,Age,BloodGroup,MaritalStatus,Address
            //City,Country,PIN,ContactNo,Depertment,ConsultantName,RoomType,RoomNumber,date

            textBox1.Text = row.Cells["PatientID"].Value.ToString();
            textBox2.Text = row.Cells["FirstName"].Value.ToString();
            textBox3.Text = row.Cells["LastName"].Value.ToString();
            comboBox1.Text = row.Cells["Gender"].Value.ToString();
            textBox4.Text = row.Cells["Occupation"].Value.ToString();
            dateTimePicker1.Text = row.Cells["DateOfBirth"].Value.ToString();
            textBox5.Text = row.Cells["Age"].Value.ToString();
            comboBox3.Text = row.Cells["BloodGroup"].Value.ToString();
            comboBox4.Text = row.Cells["MaritalStatus"].Value.ToString();
            textBox7.Text = row.Cells["Address"].Value.ToString();
            textBox8.Text = row.Cells["City"].Value.ToString();
            textBox9.Text = row.Cells["Country"].Value.ToString();
            textBox10.Text = row.Cells["PIN"].Value.ToString();
            textBox11.Text = row.Cells["ContactNo"].Value.ToString();
            comboBox5.Text = row.Cells["Depertment"].Value.ToString();
            textBox12.Text = row.Cells["ConsultantName"].Value.ToString();
            comboBox6.Text = row.Cells["RoomType"].Value.ToString();
            textBox13.Text = row.Cells["RoomNumber"].Value.ToString();
            textBox6.Text = row.Cells["Date"].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShowAvailableRoom sar = new ShowAvailableRoom();
            sar.Show();
        }
    }
}
