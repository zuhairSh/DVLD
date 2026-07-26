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
    public partial class MainDetainedLicenses : Form
    {
        private DataTable _DtListDetainedLicense;
        public MainDetainedLicenses()
        {
            InitializeComponent();
        }

        private void MShowPersonalInfo_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicnses.CurrentRow.Cells[1].Value;

            clsLicense LicenseInfo = clsLicense.Find(LicenseID);
            if (LicenseInfo != null)
            {

                People.clsShowDetailsPerson personInfo =
                    new People.clsShowDetailsPerson(LicenseInfo.DriverInfo.PersonID);


                personInfo.ShowDialog();
                MainDetainedLicenses_Load(null, null);
            }
            else
            {
                MessageBox.Show("The Person Is Not Found !!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void MainDetainedLicenses_Load(object sender, EventArgs e)
        {
            _DtListDetainedLicense =
             clsDetainedAndReleaseLicense.GetAllDetained();

            dgvDetainedLicnses.DataSource = _DtListDetainedLicense;

            comboBox2.Visible = false;
            textBox1.Visible = false;
            comboBox1.SelectedIndex = 0;
        }

        private void BtRelease_Click(object sender, EventArgs e)
        {
            ReleaseLicense releaseLicense = new ReleaseLicense();

            releaseLicense.ShowDialog();

            MainDetainedLicenses_Load(null, null);
        }

        private void BtDetain_Click(object sender, EventArgs e)
        {
            DetainLicense.NewDetainLicense DetainLicense = new DetainLicense.NewDetainLicense();

            DetainLicense.ShowDialog();

            MainDetainedLicenses_Load(null, null);
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void MShowLicenseInfo_Click(object sender, EventArgs e)
        {
            License.ShowLicenseInfo ShowLicenseInfo
                = new License.ShowLicenseInfo((int)dgvDetainedLicnses.CurrentRow.Cells[1].Value);

            ShowLicenseInfo.ShowDialog();
        }

        private void MShowLicenseHistory_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicnses.CurrentRow.Cells[1].Value;

            clsLicense LicenseInfo = clsLicense.Find(LicenseID);
            if(LicenseInfo != null)
            { 

                License.ShowLicenseHistory licenseHistory =
                    new License.ShowLicenseHistory(LicenseInfo.DriverInfo.PersonID);

                licenseHistory.ShowDialog();
                MainDetainedLicenses_Load(null, null);
            }
            else
            {
                MessageBox.Show("The Person Is Not Found !!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ReleaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicnses.CurrentRow.Cells[1].Value;
            
            if (clsDetainedAndReleaseLicense.IsLicenseDetained(LicenseID))
            { 
                ReleaseLicense releaseLicense = new ReleaseLicense((int)dgvDetainedLicnses.CurrentRow.Cells[0].Value);

                releaseLicense.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selected License Detained !!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            MainDetainedLicenses_Load(null, null);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (comboBox1.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    {
                        FilterColumn = "IsReleased";
                        break;
                    };

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (textBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                _DtListDetainedLicense.DefaultView.RowFilter = "";
                return;
            }


            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                //in this case we deal with numbers not string.
                _DtListDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                _DtListDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = comboBox2.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _DtListDetainedLicense.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _DtListDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Is Released")
            {
                textBox1.Visible = false;
                comboBox2.Visible = true;
                comboBox2.Focus();
                comboBox2.SelectedIndex = 0;
            }

            else

            {

                textBox1.Visible = (comboBox1.Text != "None");
                comboBox2.Visible = false;

                if (comboBox1.Text == "None")
                {
                    textBox1.Enabled = false;
                    //_dtDetainedLicenses.DefaultView.RowFilter = "";
                    //lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

                }
                else
                    textBox1.Enabled = true;

                textBox1.Text = "";
                textBox1.Focus();
            }
        }
    }
}
