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
    public partial class ReportOfStaff : Form
    {
        public ReportOfStaff()
        {
            InitializeComponent();
        }

        private void ReportOfStaff_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.staffinfo' table. You can move, or remove it, as needed.
            this.staffinfoTableAdapter.Fill(this.DataSet1.staffinfo);

            this.reportViewer1.RefreshReport();
        }
    }
}
