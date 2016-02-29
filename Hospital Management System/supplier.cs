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
    public partial class supplier : Form
    {
        public supplier()
        {
            InitializeComponent();
            showTable();
            textBox9.Text = DateTime.Now.ToString(@"dd\/mm\/yyyy h\:mm tt");

        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        private void add()
        {
            string insertCommand = "INSERT INTO supplier(SupplierID,SupplierName,CompanyName,ContactPerson,MobileNo,Address,EmailID,TypeOfSupplier,Rating,Remark) " +
                                                "VALUES(@SupplierID,@SupplierName,@CompanyName,@ContactPerson,@MobileNo,@Address,@EmailID,@TypeOfSupplier,@Rating,@Remark)";
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@SupplierID", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@SupplierName", textBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@CompanyName", textBox3.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@ContactPerson", textBox4.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@MobileNo", textBox5.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@Address", richTextBox2.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@EmailID", textBox6.Text);
            command.Parameters.Add(p7);
            SqlParameter p8 = new SqlParameter("@TypeOfSupplier", textBox7.Text);
            command.Parameters.Add(p8);
            SqlParameter p9 = new SqlParameter("@Rating", textBox8.Text);
            command.Parameters.Add(p9);
            SqlParameter p10 = new SqlParameter("@Remark", richTextBox1.Text);
            command.Parameters.Add(p10);
           
            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Save Successfull !!");
            con.Close();

        }

        private void update() {
            string updateCommand = "UPDATE supplier SET (SupplierID=@SupplierID,SupplierName=@SupplierName,CompanyName=@CompanyName,ContactPerson=@ContactPerson,MobileNo=@MobileNo,Address=@Address,EmailID=@EmailID,TypeOfSupplier=@TypeOfSupplier,Rating=@Rating,Remark=@Remark " +
                                     "WHERE SupplierID=@SupplierID";
            SqlCommand command = new SqlCommand(updateCommand, con);

            SqlParameter p1 = new SqlParameter("@SupplierID", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@SupplierName", textBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@CompanyName", textBox3.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@ContactPerson", textBox4.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@MobileNo", textBox5.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@Address", richTextBox2.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@EmailID", textBox6.Text);
            command.Parameters.Add(p7);
            SqlParameter p8 = new SqlParameter("@TypeOfSupplier", textBox7.Text);
            command.Parameters.Add(p8);
            SqlParameter p9 = new SqlParameter("@Rating", textBox8.Text);
            command.Parameters.Add(p9);
            SqlParameter p10 = new SqlParameter("@Remark", richTextBox1.Text);
            command.Parameters.Add(p10);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Update Successfull !!");
            con.Close();
        }

        private void showTable()
        {
            SqlConnection con = new SqlConnection("Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM supplier", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void delete()
        {
            string deleteCommand = "DELETE FROM supplier WHERE SupplierID=@SupplierID";
            SqlCommand command = new SqlCommand(deleteCommand, con);

            SqlParameter p1 = new SqlParameter("@SupplierID", textBox1.Text);
            command.Parameters.Add(p1);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Delete Successfull !!");
            con.Close();
        }
        private void search()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM supplier WHERE SupplierID LIKE ('" + textBox1.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            //SupplierID,SupplierName,CompanyName,ContactPerson,MobileNo,Address,EmailID,TypeOfSupplier,Rating,Remark

            textBox1.Text = row.Cells["SupplierID"].Value.ToString();
            textBox2.Text = row.Cells["SupplierName"].Value.ToString();
            textBox3.Text = row.Cells["CompanyName"].Value.ToString();
            textBox4.Text = row.Cells["ContactPerson"].Value.ToString();
            textBox5.Text = row.Cells["MobileNo"].Value.ToString();
            richTextBox2.Text = row.Cells["Address"].Value.ToString();
            textBox6.Text = row.Cells["EmailID"].Value.ToString();
            textBox7.Text = row.Cells["TypeOfSupplier"].Value.ToString();
            textBox8.Text = row.Cells["Rating"].Value.ToString();
            richTextBox1.Text = row.Cells["Remark"].Value.ToString();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}
