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
    public partial class ScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private int _AppointmentID = -1;
        public ScheduleTest(int LocalDrivingLicenseApplicationID, 
            clsTestType.enTestType TestTypeID, int AppointmentID = -1)
        {
            InitializeComponent();
            this._AppointmentID = AppointmentID;
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this._TestTypeID = TestTypeID;
        }

        private void ScheduleTest_Load(object sender, EventArgs e)
        {
            scheduleTest1.TestTypeID = _TestTypeID;
            scheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }

        private void ScheduleTest1_Load(object sender, EventArgs e)
        {

        }
    }
}
