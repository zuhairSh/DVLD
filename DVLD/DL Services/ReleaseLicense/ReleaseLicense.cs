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

namespace DVLD.DL_Services.ReleaseLicense
{
    public partial class ReleaseLicense : Form
    {
        private int _DetainID;
        private clsDetainedAndReleaseLicense _DetainedInfo;
        public ReleaseLicense(int DetainID = -1)
        {
            InitializeComponent();

            this._DetainID = DetainID;
        }

        


        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (filterLicense1.SelectedLicenseInfo == null)
            {
                MessageBox.Show("Please search and select a valid license first!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            License.ShowLicenseInfo showLicenseInfo =
                new License.ShowLicenseInfo(filterLicense1.SelectedLicenseInfo.LicenseID);

            showLicenseInfo.ShowDialog();
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

        private void _LoadDetainInfo(int LicnseID)
        {

        }

        private void ReleaseLicense_Load(object sender, EventArgs e)
        {
            
            filterLicense1.textBox1.Focus();

            if (this._DetainID != -1)
            {
                this._DetainedInfo = clsDetainedAndReleaseLicense.Find(_DetainID);

                if (_DetainedInfo != null)
                {
                    filterLicense1.textBox1.Text = this._DetainedInfo.LicenseID.ToString();

                    filterLicense1.LoadLicenseInfo(_DetainedInfo.LicenseID);
                    lbLicenseID.Text = _DetainedInfo.LicenseID.ToString();
                    lblApplicationFees.Text =
                       clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees.ToString();
                    lblDetainDate.Text = _DetainedInfo.DetainDate.ToString("yyyy-MM-dd");
                    lblDetainID.Text = _DetainID.ToString();
                    lblFineFees.Text = _DetainedInfo.FineFees.ToString();
                    
                    float.TryParse(lblFineFees.Text, out float fineFees);
                    float.TryParse(lblApplicationFees.Text, out float appFees);

                    lblTotalFees.Text = (fineFees + appFees).ToString("0.##");
                    lblCreatedByUser.Text = _DetainedInfo.CreatedByUserID.ToString();

                    filterLicense1.Enabled = false;
                
                }
            }
            
        }

        private void FilterLicense1_OnLicenseSelected(int obj)
        {
            int LicenseSelectedID = obj;

            _DetainedInfo = clsDetainedAndReleaseLicense.FindByLicenseID(LicenseSelectedID);

            if(_DetainedInfo == null)
            {
                MessageBox.Show("The License is UnDetained!!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _DetainID = _DetainedInfo.DetainID;

            lbLicenseID.Text = _DetainedInfo.LicenseID.ToString();
            lblApplicationFees.Text =
               clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees.ToString();
            lblDetainDate.Text = _DetainedInfo.DetainDate.ToString("yyyy-MM-dd");
            lblDetainID.Text = _DetainID.ToString();
            lblFineFees.Text = _DetainedInfo.FineFees.ToString();

            float.TryParse(lblFineFees.Text, out float fineFees);
            float.TryParse(lblApplicationFees.Text, out float appFees);

            lblTotalFees.Text = (fineFees + appFees).ToString("0.##");
            lblCreatedByUser.Text = _DetainedInfo.CreatedByUserID.ToString();

        }

        private bool _Validate()
        {
            if (filterLicense1.SelectedLicenseInfo == null)
            {
                MessageBox.Show("Please search and select a valid local license first!"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (filterLicense1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is Expired !!"
                    , "Expired", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (!clsDetainedAndReleaseLicense.IsLicenseDetained(filterLicense1.SelectedLicenseInfo.LicenseID))
            {
                MessageBox.Show("Please Select License is Detained !!"
                    , "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void BtRelease_Click(object sender, EventArgs e)
        {
            if (!_Validate())
                return;

            if (MessageBox.Show("Are you sure you want to Release this license??"
                , "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.No)
            {
                return;
            }


            if(_DetainedInfo.ReleaseDetainedLicense(GlobalClass.clsSettingLogin.CurretUser.UserID))
            {
                MessageBox.Show("The license reservation has been Successfully Released!!"
                , "successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                filterLicense1.LoadLicenseInfo(_DetainedInfo.LicenseID);

                lblApplicationID.Text = _DetainedInfo.ReleaseApplicationID.ToString();
                filterLicense1.Enabled = false;
                btRelease.Enabled = false;
            }
            else
            {
                MessageBox.Show("The license release Failed!!"
                , "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void FilterLicense1_Load(object sender, EventArgs e)
        {

        }
    }
}
