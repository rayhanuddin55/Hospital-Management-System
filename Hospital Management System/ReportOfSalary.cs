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
    public partial class ReportOfSalary : Form
    {
        public ReportOfSalary()
        {
            InitializeComponent();
        }

        private void ReportOfSalary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.staffsalary' table. You can move, or remove it, as needed.
            this.staffsalaryTableAdapter.Fill(this.DataSet1.staffsalary);

            this.reportViewer1.RefreshReport();
        }
    }
}
