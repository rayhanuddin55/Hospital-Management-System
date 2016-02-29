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
    public partial class ReportOfSupplier : Form
    {
        public ReportOfSupplier()
        {
            InitializeComponent();
        }

        private void ReportOfSupplier_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.DataSet1.supplier);

            this.reportViewer1.RefreshReport();
        }
    }
}
