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
    public partial class PrescribeFood : Form
    {
        public PrescribeFood()
        {
            InitializeComponent();
            fillCombo();
            showTable();
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        private void save()
        {
            string insertCommand = "INSERT INTO prescribefood(IPD_ID,PatientName,RoomType,RoomNumber,MorningFood,EveningFood,NightFood) " +
                                                "VALUES(@IPD_ID,@PatientName,@RoomType,@RoomNumber,@MorningFood,@EveningFood,@NightFood)";
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@IPD_ID", comboBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@PatientName", textBox1.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@RoomType", textBox3.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@RoomNumber", textBox4.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@MorningFood", richTextBox1.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@EveningFood", richTextBox2.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@NightFood", richTextBox3.Text);
            command.Parameters.Add(p7);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Save Successfull !!");
                con.Close();
            }
            catch { }

        }

        private void update()
        {
            string updateCommand = "UPDATE prescribefood SET IPD_ID=@IPD_ID,PatientName=@PatientName,RoomType=@RoomType,RoomNumber=@RoomNumber,MorningFood=@MorningFood,EveningFood=@EveningFood,NightFood=@NightFood " +
                                     "WHERE IPD_ID=@IPD_ID";
            SqlCommand command = new SqlCommand(updateCommand, con);

            SqlParameter p1 = new SqlParameter("@IPD_ID", comboBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@PatientName", textBox1.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@RoomType", textBox3.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@RoomNumber", textBox4.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@MorningFood", richTextBox1.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@EveningFood", richTextBox2.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@NightFood", richTextBox3.Text);
            command.Parameters.Add(p7);


            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Update Successfull !!");
            con.Close();

        }

        private void delete()
        {
            string deleteCommand = "DELETE FROM prescribefood WHERE IPD_ID=@IPD_ID";
            SqlCommand command = new SqlCommand(deleteCommand, con);

            SqlParameter p1 = new SqlParameter("@IPD_ID", comboBox1.Text);
            command.Parameters.Add(p1);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Delete Successfull !!");
            con.Close();
        }
        private void showTable()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM prescribefood", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save();
        }

        private void fillCombo()
        {
            string quary = "SELECT * FROM inpatient";
            SqlCommand command = new SqlCommand(quary, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // string dname = reader["Column1"].ToString();
                    comboBox1.Items.Add(reader[0].ToString());
                }

                con.Close();
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string quary = "SELECT * FROM inpatient WHERE patientid='" + comboBox1.Text + "'";
            SqlCommand command = new SqlCommand(quary, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    textBox1.Text = reader[1].ToString();
                    textBox2.Text = reader[18].ToString();
                    textBox3.Text = reader[16].ToString();
                    textBox4.Text = reader[17].ToString();

                }

                con.Close();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            //IPD_ID,PatientName,RoomType,RoomNumber,MorningFood,EveningFood,NightFood

            comboBox1.Text = row.Cells["IPD_ID"].Value.ToString();
            textBox1.Text = row.Cells["PatientName"].Value.ToString();
            textBox3.Text = row.Cells["RoomType"].Value.ToString();
            textBox4.Text = row.Cells["RoomNumber"].Value.ToString();
            richTextBox1.Text = row.Cells["MorningFood"].Value.ToString();
            richTextBox2.Text = row.Cells["EveningFood"].Value.ToString();
            richTextBox3.Text = row.Cells["NightFood"].Value.ToString();
        }
    }
}
