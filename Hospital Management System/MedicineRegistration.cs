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
    public partial class MedicineRegistration : Form
    {
        public MedicineRegistration()
        {
            InitializeComponent();
            showTable();
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        private void save()
        {
            string insertCommand = "INSERT INTO medicineinfo(MedicineID,MedicineName,MedicineType,SupplierID,Date) " +
                                        "VALUES(@MedicineID,@MedicineName,@MedicineType,@SupplierID,@Date)";
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@MedicineID", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@MedicineName", textBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@MedicineType", textBox3.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@SupplierID", textBox4.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@Date", dateTimePicker1.Text);
            command.Parameters.Add(p5);
            

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Save Successfull !!");
            con.Close();

        }

        private void update()
        {
            string upadateCommand = "UPDATE medicineinfo SET MedicineID=@MedicineID,MedicineName=@MedicineName,MedicineType=@MedicineType,SupplierID=@SupplierID,Date=@Date " +
                                     "WHERE MedicineID=@MedicineID";
            SqlCommand command = new SqlCommand(upadateCommand, con);

            SqlParameter p1 = new SqlParameter("@MedicineID", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@MedicineName", textBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@MedicineType", textBox3.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@SupplierID", textBox4.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@Date", dateTimePicker1.Text);
            command.Parameters.Add(p5);


            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Update Successfull !!");
            con.Close();

        }

        private void showTable()
        {
            SqlConnection con = new SqlConnection("Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM medicineinfo", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        private void search()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM medicineinfo WHERE MedicineID LIKE ('" + textBox5.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void delete()
        {
            string deleteCommand = "DELETE FROM medicineinfo WHERE MedicineID=@MedicineID";
            SqlCommand command = new SqlCommand(deleteCommand, con);

            SqlParameter p1 = new SqlParameter("@MedicineID", textBox5.Text);
            command.Parameters.Add(p1);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Delete Successfull !!");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAllSupplierWindow allSuplier = new ShowAllSupplierWindow();
            allSuplier.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button7_Click(object sender, EventArgs e)
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
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

            //MedicineID,MedicineName,MedicineType,SupplierID,Date

            textBox1.Text = row.Cells["MedicineID"].Value.ToString();
            textBox2.Text = row.Cells["MedicineName"].Value.ToString();
            textBox3.Text = row.Cells["MedicineType"].Value.ToString();
            textBox4.Text = row.Cells["SupplierID"].Value.ToString();
            dateTimePicker1.Text = row.Cells["Date"].Value.ToString();
           
        }
    }
}
