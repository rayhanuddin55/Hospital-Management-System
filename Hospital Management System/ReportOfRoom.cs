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
    public partial class ReportOfRoom : Form
    {
        public ReportOfRoom()
        {
            InitializeComponent();
        }

        private void ReportOfRoom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.roominfo' table. You can move, or remove it, as needed.
            this.roominfoTableAdapter.Fill(this.DataSet1.roominfo);

            this.reportViewer1.RefreshReport();
        }
    }
}
