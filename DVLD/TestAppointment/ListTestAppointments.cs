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

namespace DVLD.TestAppointment
{
    public partial class ListTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;

        public ListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this._TestType = TestType;
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestType.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pictureBox1.Image = Properties.Resources.Vision_512;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pictureBox1.Image = Properties.Resources.Written_Test_512;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pictureBox1.Image = Properties.Resources.driving_test_512;
                        break;
                    }
            }
        }


        private void _LoadInfo()
        {
            DataTable dataTable =
              clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            dgvTestAppointment.DataSource = dataTable;

            LDLinfo.LoadAllInfo(_LocalDrivingLicenseApplicationID);

            lblRecordsCount.Text = dgvTestAppointment.RowCount.ToString();

            if (dgvTestAppointment.Columns["AppointmentDate"] != null)
            {
                dgvTestAppointment.Columns["AppointmentDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
        clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (localDrivingLicenseApplication != null)
            {
                if (localDrivingLicenseApplication.DoesPassTestType(_TestType))
                {
                    btnAddNewAppointment.Enabled = false;
                }
                else
                {
                    btnAddNewAppointment.Enabled = true;

                }
            }
        }

        private void ListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();
                
            _LoadInfo();
        }

        private void BtnAddNewAppointment_Click(object sender, EventArgs e)
        {
            ScheduleTest scheduleTest = new ScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
            scheduleTest.ShowDialog();
            _LoadInfo();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvTestAppointment.CurrentRow.Cells[0].Value;

            ScheduleTest scheduleTest =
                new ScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, TestAppointmentID);
            scheduleTest.ShowDialog();
            _LoadInfo();
        }

        private void LDLinfo_Load(object sender, EventArgs e)
        {

        }

        private void TakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvTestAppointment.CurrentRow.Cells[0].Value;

            TakeTest takeTest = new TakeTest(TestAppointmentID, this._TestType);
            takeTest.ShowDialog();
            _LoadInfo();
        }
    }
}
