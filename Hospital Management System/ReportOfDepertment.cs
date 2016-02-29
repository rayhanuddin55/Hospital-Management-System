using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class ReportOfDepertment : Form
    {
        public ReportOfDepertment()
        {
            InitializeComponent();
        }

        private void ReportOfDepertment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.depertment' table. You can move, or remove it, as needed.
            this.depertmentTableAdapter.Fill(this.DataSet1.depertment);

            this.reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
