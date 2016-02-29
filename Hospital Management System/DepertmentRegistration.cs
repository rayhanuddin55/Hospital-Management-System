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
    public partial class DepertmentRegistration : Form
    {
        public DepertmentRegistration()
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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM depertment", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void save()
        {

            string insertCommand = "INSERT INTO depertment(depertmentid,depertmentname,headname,address,contractno,description) " +
                                    "VALUES(@depertmentid,@depertmentname,@headname,@address,@contractno,@description)";
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@depertmentid", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@depertmentname", textBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@headname", textBox4.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@address", textBox5.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@contractno", textBox6.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@description", richTextBox1.Text);
            command.Parameters.Add(p6);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Save Successfull !!");
            con.Close();

        }

        private void update()
        {
            string updateCommand = "UPDATE depertment SET depertmentid=@depertmentid,depertmentname=@depertmentname,headname=@headname,address=@address,contractno=@contractno,description=@description " +
                                      "WHERE depertmentid=@depertmentid";
            SqlCommand command = new SqlCommand(updateCommand, con);

            SqlParameter p1 = new SqlParameter("@depertmentid", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@depertmentname", textBox2.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@headname", textBox4.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@address", textBox5.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@contractno", textBox6.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@description", richTextBox1.Text);
            command.Parameters.Add(p6);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Update Successfull !!");
            con.Close();
        }

        private void delete()
        {
            string deleteCommand = "DELETE FROM depertment WHERE depertmentid=@depertmentid";
            SqlCommand command = new SqlCommand(deleteCommand, con);

            SqlParameter p1 = new SqlParameter("@depertmentid", textBox1.Text);
            command.Parameters.Add(p1);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Delete Successfull !!");
            con.Close();
        }

        private void search() {
            
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM depertment WHERE depertmentid LIKE ('" + textBox1.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showTable();
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

        private void button6_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            textBox1.Text = row.Cells["depertmentid"].Value.ToString();
            textBox2.Text = row.Cells["depertmentname"].Value.ToString();
            textBox4.Text = row.Cells["headname"].Value.ToString();
            textBox5.Text = row.Cells["address"].Value.ToString();
            textBox6.Text = row.Cells["contractno"].Value.ToString();
            richTextBox1.Text = row.Cells["description"].Value.ToString();
            
        }
    }
}
