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

namespace DVLD.MyContors
{
    public partial class ScheduledTest : UserControl
    {
        private clsTestType.enTestType _TestTypeID;
        private int _TestID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestType.enTestType.VisionTest:
                        {
                            pbTestTypeImage.Image = Properties.Resources.Vision_512;
                            break;
                        }

                    case clsTestType.enTestType.WrittenTest:
                        {
                            pbTestTypeImage.Image = Properties.Resources.Written_Test_512;
                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            pbTestTypeImage.Image = Properties.Resources.driving_test_512;
                            break;


                        }
                }
            }
        }

        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestAppointment _TestAppointment;


        public ScheduledTest()
        {
            InitializeComponent();
        }


        public void LoadInfo(int TestAppointmentID)
        {
            this._TestAppointmentID = TestAppointmentID;

            _TestAppointment = clsTestAppointment.Find(TestAppointmentID);

            if (_TestAppointment != null)
            {
                lblLocalDrivingLicenseAppID.Text =
                    _TestAppointment.LocalDrivingLicenseApplicationID.ToString();

                _TestID = _TestAppointment.TestID;

                _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
                _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

                if (_LocalDrivingLicenseApplication == null)
                {
                    MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
                lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;


                //this will show the trials for this test before 
                lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();



                lblDate.Text = _TestAppointment.AppointmentDate.ToString("yyyy-mmm-dd");
                lblFees.Text = _TestAppointment.PaidFees.ToString();
                lblTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();

            }

            else
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }
        }

        private void ScheduledTest_Load(object sender, EventArgs e)
        {

        }
    }
}
