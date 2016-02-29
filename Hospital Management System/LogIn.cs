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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM login WHERE username='"+textBox1.Text+"' AND password='"+textBox2.Text+"'",con);
            con.Open();
            SqlDataReader reader;
            reader = command.ExecuteReader();
            
            int count=0;

            while(reader.Read()){
                count = count+1;
            }

            if (count == 1)
            {
                this.Hide();
                ParantForm pf = new ParantForm();
                pf.Show();
            }
            else {
                MessageBox.Show("User Name or Password Incorrect !!");
            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Login_Registration lr = new Login_Registration();
            this.Hide();
            lr.Show();
        }
    }
}
