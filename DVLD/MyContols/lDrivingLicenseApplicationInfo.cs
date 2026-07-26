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
    public partial class lDrivingLicenseApplicationInfo : UserControl
    {
        private clsLocalDrivingLicenseApplication _LDrivingLicenseApplication;
        public lDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void LDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

        }

        public void LoadAllInfo(int LDrivingLicenseApplicationID)
        {
            this._LDrivingLicenseApplication =
              clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDrivingLicenseApplicationID);

            if(this._LDrivingLicenseApplication != null)
            {
                lblLocalDrivingLicenseApplicationID.Text = LDrivingLicenseApplicationID.ToString();
                lblAppliedFor.Text = _LDrivingLicenseApplication.LicenseClassInfo.ClassName;
                lblPassedTests.Text = _LDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";

                applicationInfo1.LoadApplicationInfo(_LDrivingLicenseApplication.ApplicationID);
            }
        }


        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
