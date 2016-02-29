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
    public partial class RoomEntry : Form
    {
        public RoomEntry()
        {
            InitializeComponent();
            fillCombo();
            textBox7.Text = DateTime.Now.ToString(@"dd\/mm\/yyyy h\:mm tt");
            showTable();

        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);


        private void add() {
            string insertCommand = "INSERT INTO roominfo(RoomNo,Depertment,RoomType,NumberOfBed,Status,Price,Date) " +
                                           "VALUES(@RoomNo,@Depertment,@RoomType,@NumberOfBed,@Status,@Price,@Date)";
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@RoomNo", textBox3.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@Depertment", comboBox1.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@RoomType", textBox2.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@NumberOfBed", textBox4.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@Status", comboBox2.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@Price", textBox6.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@Date", textBox7.Text);
            command.Parameters.Add(p7);
            

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Save Successfull !!");
            con.Close();
        }

        private void fillCombo()
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
                    comboBox1.Items.Add(reader[1].ToString());
                }

                con.Close();
            }
            catch { }
        }

        private void showTable() {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM roominfo", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void update() {
            string UpdateCommand = "UPDATE roominfo SET RoomNo=@RoomNo,Depertment=@Depertment,RoomType=@RoomType,NumberOfBed=@NumberOfBed,Status=@Status,Price=@Price,Date=@Date " +
                                     "WHERE RoomNo=@RoomNo";
            SqlCommand command = new SqlCommand(UpdateCommand, con);

            SqlParameter p1 = new SqlParameter("@RoomNo", textBox3.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@Depertment", comboBox1.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@RoomType", textBox2.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@NumberOfBed", textBox4.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@Status", comboBox2.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@Price", textBox6.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@Date", textBox7.Text);
            command.Parameters.Add(p7);


            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Update Successfull !!");
            con.Close();
        }
        private void delete() {
            string deleteCommand = "DELETE FROM roominfo WHERE RoomNo=@RoomNo";
            SqlCommand command = new SqlCommand(deleteCommand, con);

            SqlParameter p1 = new SqlParameter("@RoomNo", textBox3.Text);
            command.Parameters.Add(p1);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Delete Successfull !!");
            con.Close();
        }

        private void search()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM roominfo WHERE RoomNo LIKE ('" + textBox3.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            //RoomNo,Depertment,RoomType,NumberOfBed,Status,Price,Date

            textBox3.Text = row.Cells["RoomNo"].Value.ToString();
            comboBox1.Text = row.Cells["Depertment"].Value.ToString();
            textBox2.Text = row.Cells["RoomType"].Value.ToString();
            textBox4.Text = row.Cells["NumberOfBed"].Value.ToString();
            comboBox2.Text = row.Cells["Status"].Value.ToString();
            textBox6.Text = row.Cells["Price"].Value.ToString();
            textBox7.Text = row.Cells["Date"].Value.ToString();
            
        }
    }
}
