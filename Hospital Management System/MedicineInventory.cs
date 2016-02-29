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
    public partial class MedicineInventory : Form
    {
        public MedicineInventory()
        {
            InitializeComponent();
            fillCombo();
            showTable();
        }

        static string connectionString = "Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);

        private void fillCombo()
        {
            string quary = "SELECT * FROM medicineinfo";
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

        private void save()
        {
            string insertCommand = "INSERT INTO medicineinventory(ItemNo,MedicineName,MedicineID,Stock,PriceQty,ManufactureName,ManufactureDate,ExpireDate) " +
                                        "VALUES(@ItemNo,@MedicineName,@MedicineID,@Stock,@PriceQty,@ManufactureName,@ManufactureDate,@ExpireDate)";
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@ItemNo", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@MedicineName", comboBox1.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@MedicineID", textBox2.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@Stock", int.Parse(textBox5.Text));
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@PriceQty", textBox6.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@ManufactureName", textBox8.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@ManufactureDate", dateTimePicker1.Text);
            command.Parameters.Add(p7);
            SqlParameter p8 = new SqlParameter("@ExpireDate", dateTimePicker2.Text);
            command.Parameters.Add(p8);
            

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Save Successfull !!");
            con.Close();

        }

        private void update()
        {
            string insertCommand = "UPDATE medicineinventory SET ItemNo=@ItemNo,MedicineName=@MedicineName,MedicineID=@MedicineID,Stock=@Stock,PriceQty=@PriceQty,ManufactureName=@ManufactureName,ManufactureDate=@ManufactureDate,ExpireDate=@ExpireDate " +
                                     "WHERE ItemNo=@ItemNo";
            SqlCommand command = new SqlCommand(insertCommand, con);

            SqlParameter p1 = new SqlParameter("@ItemNo", textBox1.Text);
            command.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@MedicineName", comboBox1.Text);
            command.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@MedicineID", textBox2.Text);
            command.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@Stock", int.Parse(textBox5.Text));
            command.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@PriceQty", textBox6.Text);
            command.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@ManufactureName", textBox8.Text);
            command.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@ManufactureDate", dateTimePicker1.Text);
            command.Parameters.Add(p7);
            SqlParameter p8 = new SqlParameter("@ExpireDate", dateTimePicker2.Text);
            command.Parameters.Add(p8);


            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Update Successfull !!");
            con.Close();

        }

        private void search()
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM medicineinventory WHERE ItemNo LIKE ('" + textBox9.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void showTable()
        {
            SqlConnection con = new SqlConnection("Data Source=rayhan-pc\\sqlexpress;Initial Catalog=HospitalManagement;Integrated Security=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM medicineinventory", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void delete()
        {
            string deleteCommand = "DELETE FROM medicineinventory WHERE ItemNo=@ItemNo";
            SqlCommand command = new SqlCommand(deleteCommand, con);

            SqlParameter p1 = new SqlParameter("@ItemNo", textBox9.Text);
            command.Parameters.Add(p1);

            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Delete Successfull !!");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string quary = "SELECT * FROM medicineinfo WHERE MedicineName='" + comboBox1.Text + "'";
            SqlCommand command = new SqlCommand(quary, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    textBox2.Text = reader[0].ToString();
                    textBox3.Text = reader[2].ToString();
                    textBox4.Text = reader[3].ToString();
                   
                }

                con.Close();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int stock = int.Parse(textBox5.Text);
            int pricePerQty = int.Parse(textBox6.Text);
            int total;
            total = stock * pricePerQty;
            textBox7.Text = total.ToString();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]"))
            {

                MessageBox.Show("Please enter only numbers.", "Error");
                textBox5.Text = null; ;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "[^0-9]"))
            {

                MessageBox.Show("Please enter only numbers.", "Error");
                textBox6.Text = null; ;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            //ItemNo,MedicineName,MedicineID,Stock,PriceQty,ManufactureName,ManufactureDate,ExpireDate

            textBox1.Text = row.Cells["ItemNo"].Value.ToString();
            comboBox1.Text = row.Cells["MedicineName"].Value.ToString();
            textBox2.Text = row.Cells["MedicineID"].Value.ToString();
            textBox5.Text = row.Cells["Stock"].Value.ToString();
            textBox6.Text = row.Cells["PriceQty"].Value.ToString();
            textBox8.Text = row.Cells["ManufactureName"].Value.ToString();
            dateTimePicker1.Text = row.Cells["ManufactureDate"].Value.ToString();
            dateTimePicker2.Text = row.Cells["ExpireDate"].Value.ToString();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}
