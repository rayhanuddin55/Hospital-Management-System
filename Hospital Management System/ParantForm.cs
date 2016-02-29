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
    public partial class ParantForm : Form
    {
        public ParantForm()
        {
            InitializeComponent();
        }

        

        private void newDepertmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepertmentRegistration dr = new DepertmentRegistration();
            dr.MdiParent = this;
            dr.Show();
        }

        private void staffRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            staffRegistration sr = new staffRegistration();
            sr.MdiParent = this;
            sr.Show();
        }

        private void staffPayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffPayroll sp = new StaffPayroll();
            sp.MdiParent = this;
            sp.Show();
        }

        private void newRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomEntry re = new RoomEntry();
            re.MdiParent = this;
            re.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            supplier supplier = new supplier();
            supplier.MdiParent = this;
            supplier.Show();
        }

        private void medicineRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicineRegistration mr = new MedicineRegistration();
            mr.MdiParent = this;
            mr.Show();
        }

        private void medicineInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicineInventory mi = new MedicineInventory();
            mi.MdiParent = this;
            mi.Show();
        }

        private void medicinePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicinePurchaseBill mpb = new MedicinePurchaseBill();
            mpb.MdiParent = this;
            mpb.Show();
        }

        private void staffReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportOfDepertment rod = new ReportOfDepertment();
            rod.MdiParent = this;
            rod.Show();
        }

        private void outPatientRegistrationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OutPatient op = new OutPatient();
            op.MdiParent = this;
            op.Show();
        }

        private void inPatientRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InPatient ip = new InPatient();
            ip.MdiParent = this;
            ip.Show();
        }

        private void prescribeFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrescribeFood pf = new PrescribeFood();
            pf.MdiParent = this;
            pf.Show();
        }

        private void salaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportOfSalary ros = new ReportOfSalary();
            ros.MdiParent = this;
            ros.Show();
        }

        private void roomReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportOfRoom ror = new ReportOfRoom();
            ror.MdiParent = this;
            ror.Show();
        }

        private void staffReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportOfStaff rostaff = new ReportOfStaff();
            rostaff.MdiParent = this;
            rostaff.Show();
        }

        private void supplierReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportOfSupplier rosup = new ReportOfSupplier();
            rosup.MdiParent = this;
            rosup.Show();
        }

        private void medicineInventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportOfMedicineInventory rmedicineinventory = new ReportOfMedicineInventory();
            rmedicineinventory.MdiParent = this;
            rmedicineinventory.Show();

        }

        private void inPatientReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportOfInPatient ipatient = new ReportOfInPatient();
            ipatient.MdiParent = this;
            ipatient.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.MdiParent = this;
            ab.Show();
        }
    }
}
