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
    public partial class MedicinePurchaseBill : Form
    {
        public MedicinePurchaseBill()
        {
            InitializeComponent();
            fillCombo();
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);


        private void fillCombo()
        {
            string quary = "SELECT * FROM medicineinventory";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string quary = "SELECT * FROM medicineinventory WHERE medicinename='" + comboBox1.Text + "'";
            SqlCommand command = new SqlCommand(quary, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    textBox1.Text = reader[2].ToString();
                    textBox2.Text = reader[6].ToString();
                    textBox3.Text = reader[7].ToString();
                    textBox10.Text = reader[3].ToString();

                }

                con.Close();
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
                string quary = "SELECT * FROM inpatient WHERE patientid='" + textBox7.Text + "'";
                SqlCommand command = new SqlCommand(quary, con);
                SqlDataReader reader;
                try
                {
                    con.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        textBox8.Text = reader[1].ToString();

                    }

                    con.Close();
                }
                catch { }
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {

                MessageBox.Show("Please enter only numbers.", "Error");
                textBox4.Text = null; ;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]"))
            {

                MessageBox.Show("Please enter only numbers.", "Error");
                textBox5.Text = null; ;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox9.Text, "[^0-9]"))
            {

                MessageBox.Show("Please enter only numbers.", "Error");
                textBox9.Text = null; ;
            }
        }

        private void totalCalculate() {
            int quantity = int.Parse(textBox4.Text);
            int pricePerQty= int.Parse(textBox5.Text);

            int total;
            total = quantity * pricePerQty;
            textBox9.Text = total.ToString();
        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            totalCalculate();
        }

        private void save()
        {
            string insertCommand = "INSERT INTO medicinepurchase(TransectionID,PatientID,PatientName,MedicineName,MedicineID,Quantity,PriceQty,TotalAmount) " +
                                           "VALUES(@TransectionID,@PatientID,@PatientName,@MedicineName,@MedicineID,@Quantity,@PriceQty,@TotalAmount)";
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@TransectionID", textBox6.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@PatientID", textBox7.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@PatientName", textBox8.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@MedicineName", comboBox1.Text);
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@MedicineID", textBox1.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@Quantity", int.Parse(textBox4.Text));
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@PriceQty", textBox5.Text);
            command.Parameters.Add(p7);
            SqlParameter p8 = new SqlParameter("@TotalAmount", textBox9.Text);
            command.Parameters.Add(p8);
            
            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Save Successfull !!");
            con.Close();

        }

        private void updateMedicineQuantity() {
            string updateCommand = "UPDATE medicineinventory SET stock= stock - @purchaseQuantity " +
                                             "WHERE medicinename=@medicinename";
            SqlCommand command = new SqlCommand(updateCommand, con);

            SqlParameter p1 = new SqlParameter("@medicinename", comboBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@purchaseQuantity", int.Parse(textBox4.Text));
            command.Parameters.Add(p2);
            

            con.Open();
            command.ExecuteNonQuery();           
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            totalCalculate();
            save();
            updateMedicineQuantity();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showtable() {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM medicinepurchase",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showtable();
        }
    }
}
