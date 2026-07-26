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


namespace DVLD.License
{
    public partial class IssueDrivingLicense : Form
    {
        private int _LDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public IssueDrivingLicense(int LDrivingLicenseApplicationID)
        {
            InitializeComponent();

            this._LDrivingLicenseApplicationID = LDrivingLicenseApplicationID;
        }

        private void _LoadInfo()
        {
            txtNotes.Focus();

            _LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDrivingLicenseApplicationID);
            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("The Application is NOT Found !!"
                     , "NOT Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
            }
            else
            {
                lDrivingLicenseApplicationInfo1.LoadAllInfo(_LDrivingLicenseApplicationID);
                

            
            }

        }
        private void IssueDrivingLicense_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void BtIssue_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure the license is issued"
                     , "issued", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                int LicenseID =
                    _LocalDrivingLicenseApplication.IssueLicenseForTheFirtTime(txtNotes.Text.Trim(), GlobalClass.clsSettingLogin.CurretUser.UserID);

                if (LicenseID != -1)
                {
                    MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                        "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("License Was not Issued ! ",
                     "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void LDrivingLicenseApplicationInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
