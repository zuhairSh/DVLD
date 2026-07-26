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

namespace DVLD.DL_Services.DetainLicense
{
    public partial class NewDetainLicense : Form
    {
        public NewDetainLicense()
        {
            InitializeComponent();
        }

        private void FilterLicense1_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblCreatedByUser.Text = GlobalClass.clsSettingLogin.CurretUser.UserName;
        }

        private void FilterLicense1_OnLicenseSelected(int obj)
        {
            int LicenseSelectedID = obj;

            lbLicenseID.Text = LicenseSelectedID.ToString();
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


        private bool _Validate()
        {
            if (string.IsNullOrEmpty(txtFineFees.Text))
            {
                MessageBox.Show("Please specify the Fine!!"
                    , "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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

            if (!filterLicense1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            

            return true;
        }

        private void BtDetain_Click(object sender, EventArgs e)
        {

            if (!_Validate())
                return;

            if (MessageBox.Show("Are you sure you want to detain this license?" +
                "", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.No)
            {
                return;
            }

            clsDetainedAndReleaseLicense NewDetained = new clsDetainedAndReleaseLicense();

            NewDetained.LicenseID = filterLicense1.SelectedLicenseInfo.LicenseID;
            NewDetained.FineFees = Convert.ToSingle(txtFineFees.Text);
            NewDetained.DetainDate = DateTime.Now;
            NewDetained.CreatedByUserID = GlobalClass.clsSettingLogin.CurretUser.UserID;
            NewDetained.IsReleased = false;

            if(NewDetained.Save())
            {
                lblDetainID.Text = NewDetained.DetainID.ToString();

                MessageBox.Show("The driver's license was successfully Detain !! this Detain ID = "
                + NewDetained.DetainID.ToString(), "Detain", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                btDetain.Enabled = false;
                filterLicense1.Enabled = false;
                txtFineFees.Enabled = false;
                return;
            }
            else
            {
                MessageBox.Show("The driver's license was not Detain !!"
                , "Failed", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
           
            

        }

        private void TxtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees cannot be empty!");
                return;
            }

            if (!float.TryParse(txtFineFees.Text.Trim(), out float fineFees))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalid Number! Please enter a valid decimal number.");
                return;
            }

            if (fineFees < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fine fees cannot be negative!");
                return;
            }

            errorProvider1.SetError(txtFineFees, null);
        }

        private void NewDetainLicense_Load(object sender, EventArgs e)
        {
            filterLicense1.textBox1.Focus();
        }

        private void TxtFineFees_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
