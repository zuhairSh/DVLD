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

namespace DVLD.DL_Services.RenewLocalDrivingLicense
{
    public partial class RenewLocalDrivingLicense : Form
    {
        private int _NewLicenseID;
        public RenewLocalDrivingLicense()
        {
            InitializeComponent();

            

        }

        private void RenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {

        }



        private void BtRenew_Click(object sender, EventArgs e)
        {
            if(filterLicense1.SelectedLicenseInfo == null)
            {
                MessageBox.Show("Please search and select a valid local license first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!filterLicense1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " 
                    + (filterLicense1.SelectedLicenseInfo.ExpirationDate.ToString("yyyy-MM-dd"))
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btRenew.Enabled = false;
                return;
            }

            if (!filterLicense1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btRenew.Enabled = false;
                return;
            }

            clsLicense NewLicense = filterLicense1.SelectedLicenseInfo.RenewLicnse(
                txtNotes.Text.Trim(), GlobalClass.clsSettingLogin.CurretUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lbLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" 
                + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            btRenew.Enabled = false;
            filterLicense1.Enabled = false;
            linkLabel2.Enabled = true;
            linkLabel1.Enabled = true;

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (filterLicense1.SelectedLicenseInfo == null)
            {
                MessageBox.Show("Please search and select a valid local license first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            License.ShowLicenseHistory showLicenseHistory =
                new License.ShowLicenseHistory(filterLicense1.SelectedLicenseInfo.DriverInfo.PersonID);

            showLicenseHistory.ShowDialog();

            
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (filterLicense1.SelectedLicenseInfo == null)
            {
                MessageBox.Show("Please search and select a valid local license first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            License.ShowLicenseInfo showLicenseInfo = new License.ShowLicenseInfo(_NewLicenseID);

            showLicenseInfo.ShowDialog();

           
        }

        private void FilterLicense1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            int DefaultValidityLength = filterLicense1.SelectedLicenseInfo.LicenseClassIfo.DefaultValidityLength;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();


            lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblCreatedByUser.Text = GlobalClass.clsSettingLogin.CurretUser.UserName;
            lblExpirationDate.Text = DateTime.Now.AddYears(DefaultValidityLength).ToString("yyyy-MM-dd");
            lblApplicationFees.Text = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationFees.ToString();
            lbLicenseFees.Text = filterLicense1.SelectedLicenseInfo.LicenseClassIfo.ClassFees.ToString();
            lbTotalFees.Text = (int.Parse(lbLicenseFees.Text) + int.Parse(lblApplicationFees.Text)).ToString();
            lbIssueDate.Text = lblApplicationDate.Text;
        }

        private void FilterLicense1_Load(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
