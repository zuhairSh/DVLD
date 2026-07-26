using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessDVLDLayer;

namespace DVLD.DL_Services.LocalDrivingLicenseApplication
{
    public partial class ManageLocalDrivingLicenseApplication : Form
    {
        public ManageLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            comboBox1.SelectedIndex = 0;
            dgvLocalDrivingLicenses.DataSource =
                clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

            dgvLocalDrivingLicenses.Columns["ApplicationDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
        }


        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtAddLocalDrivingLicense_Click(object sender, EventArgs e)
        {
            DL_Services.NewDL.AddEditLocalLicense AddLocalLicense = new NewDL.AddEditLocalLicense(-1);
            AddLocalLicense.ShowDialog();
            _LoadData();

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Visible = false;
            }
            else
                textBox1.Visible = true;
        }

        private void ManageLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void ShowLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            License.ShowLicenseHistory licenseHistory = new License.ShowLicenseHistory(localDrivingLicenseApplication.ApplicantPersonID);

            licenseHistory.ShowDialog();

            _LoadData();
        }

        private void EditApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DL_Services.NewDL.AddEditLocalLicense EditLocalLicense =
                new NewDL.AddEditLocalLicense((int)dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value);

            EditLocalLicense.ShowDialog();
            _LoadData();
        }

        private void DeletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure the Application was deleted?", "Verified"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value;
                clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

                if (LocalDrivingLicenseApplication != null)
                {
                    if (LocalDrivingLicenseApplication.Delete())
                    {
                        MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DL_Services.LocalDrivingLicenseApplication.ShowApplicationInfo showApplication
                = new ShowApplicationInfo((int)dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value);

            showApplication.ShowDialog();
        }


        private void _FilterData(string txt)
        {
            if (dgvLocalDrivingLicenses.DataSource == null) return;

            DataTable dataTable = (DataTable)dgvLocalDrivingLicenses.DataSource;

            if (comboBox1.SelectedItem == null) return;

            string columnName = comboBox1.SelectedItem.ToString();

            switch (columnName)
            {
                case "L.D.L.AppID":
                    columnName = "LocalDrivingLicenseApplicationID";
                    break;

                case "Class Name":
                    columnName = "ClassName";
                    break;

                case "National No":
                    columnName = "NationalNo";
                    break;

                case "Full Name":
                    columnName = "FullName";
                    break;

                case "Application Date":
                    columnName = "ApplicationDate";
                    break;

                case "Passed Test Count":
                    columnName = "PassedTestCount";
                    break;

                case "Status":
                    columnName = "Status";
                    break;

                default:
                    break;
            }

            string fillterColumn = "[" + columnName + "]";

            if (string.IsNullOrWhiteSpace(txt))
            {
                dataTable.DefaultView.RowFilter = "";
                return;
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                if (int.TryParse(txt, out int result))
                {
                    dataTable.DefaultView.RowFilter = string.Format("{0} = {1}", fillterColumn, result);
                }
                else
                {
                    dataTable.DefaultView.RowFilter = "1=0"; // لا شيء يطابق عند كتابة نص في حقل رقمي
                }
            }
            else
            {
                dataTable.DefaultView.RowFilter = string.Format("{0} LIKE '%{1}%'", fillterColumn, txt);
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            _FilterData(textBox1.Text);
        }

        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int ApplicationID = (int)dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(ApplicationID);

            if (LocalDrivingLicenseApplication == null) return;

            int TotalPassedTests = (int)dgvLocalDrivingLicenses.CurrentRow.Cells[5].Value;
            bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();
            bool IsApplicationNew = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            issueToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            ShowLicensToolStripMenuItem.Enabled = LicenseExists;
            showLicenseHistoryToolStripMenuItem.Enabled = LicenseExists;

            EditApplicationToolStripMenuItem.Enabled = !LicenseExists && IsApplicationNew;

            CancelToolStripMenuItem.Enabled = IsApplicationNew;
            deletToolStripMenuItem.Enabled = IsApplicationNew;

            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest);
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);

            TestToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && IsApplicationNew;

            if (TestToolStripMenuItem.Enabled)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest &&
                    !clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(ApplicationID, clsTestType.enTestType.VisionTest);

                scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest &&
                    !clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(ApplicationID, clsTestType.enTestType.WrittenTest);

                scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest &&
                    !clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(ApplicationID, clsTestType.enTestType.StreetTest);
            }
        }

        private void ScheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestAppointment.ListTestAppointments TestAppointmentVision
                = new TestAppointment.ListTestAppointments(
                    (int)dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value,
                    clsTestType.enTestType.VisionTest);

            TestAppointmentVision.ShowDialog();
            _LoadData();
        }

        private void ScheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestAppointment.ListTestAppointments TestAppointmentVision
                = new TestAppointment.ListTestAppointments(
                    (int)dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value,
                    clsTestType.enTestType.WrittenTest);

            TestAppointmentVision.ShowDialog();
            _LoadData();
        }

        private void ScheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestAppointment.ListTestAppointments TestAppointmentVision
                = new TestAppointment.ListTestAppointments(
                    (int)dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value,
                    clsTestType.enTestType.StreetTest);

            TestAppointmentVision.ShowDialog();
            _LoadData();
        }

        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    _LoadData();
                }
                else
                {
                    MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value;

            License.IssueDrivingLicense issueDrivingLicense = new License.IssueDrivingLicense(LocalDrivingLicenseApplicationID);
            issueDrivingLicense.ShowDialog();

            _LoadData();

        }

        private void ShowLicensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value;

            int LicenseID = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(
               LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                License.ShowLicenseInfo frm = new License.ShowLicenseInfo(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
