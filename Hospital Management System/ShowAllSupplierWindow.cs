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
    public partial class ShowAllSupplierWindow : Form
    {
        public ShowAllSupplierWindow()
        {
            InitializeComponent();
            showTable();
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

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

        private void search()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM supplier WHERE SupplierID LIKE ('" + textBox1.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
