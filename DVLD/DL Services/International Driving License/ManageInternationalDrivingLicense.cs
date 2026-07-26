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
using BusinessDVLDLayerPeople;

namespace DVLD.DL_Services.International_Driving_License
{
    public partial class ManageInternationalDrivingLicense : Form
    {
        private DataTable DtListInternationalDrivingLicense;
        clsDriver _Driver;
        public ManageInternationalDrivingLicense()
        {
            InitializeComponent();
        }

        private void _LoadInfo()
        {
            DtListInternationalDrivingLicense =
              clsInternationalLicense.GetAllInternationalLicenses();

            dgvInternationalDrivingLicenses.DataSource = DtListInternationalDrivingLicense;

            comboBox2.Visible = false;
            textBox1.Visible = false;
            comboBox1.SelectedIndex = 0;
        
        }

        private void ManageInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
               , MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Visible = false;
                comboBox2.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                textBox1.Visible = false;
                comboBox2.Visible = true;
            }
            else
            {
                textBox1.Visible = true;
                comboBox2.Visible = false;
            }

        }



        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (comboBox1.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    {
                        FilterColumn = "ApplicationID";
                        break;
                    };

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "IsActive":
                    FilterColumn = "IsActive";
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }

            if (textBox1.Text == "" || comboBox1.SelectedIndex == 0)
            {
                DtListInternationalDrivingLicense.DefaultView.RowFilter = "";
                return;
            }

            if (int.TryParse(textBox1.Text.Trim(), out int value))
            {
                DtListInternationalDrivingLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, value);
            }

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 0)
            {
                DtListInternationalDrivingLicense.DefaultView.RowFilter = "";
                return;
            }
            else if(comboBox2.SelectedIndex == 1)
            {
                DtListInternationalDrivingLicense.DefaultView.RowFilter = string.Format("[IsActive] = 1");

            }
            else
            {
                DtListInternationalDrivingLicense.DefaultView.RowFilter = string.Format("[IsActive] = 0");
            }
        }

        private void MShowPersonalInfo_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalDrivingLicenses.CurrentRow.Cells[2].Value;

            _Driver = clsDriver.FindByDriverID(DriverID);

            if (_Driver != null)
            {
                People.clsShowDetailsPerson showDetailsPerson =
                   new People.clsShowDetailsPerson(_Driver.PersonID);
                showDetailsPerson.ShowDialog();
                _LoadInfo();
            }
            else
            {
                MessageBox.Show("The Person Is Not Found !!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void MShowLicenseHistory_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalDrivingLicenses.CurrentRow.Cells[2].Value;

            _Driver = clsDriver.FindByDriverID(DriverID);

            if (_Driver != null)
            {
                License.ShowLicenseHistory licenseHistory =
                    new License.ShowLicenseHistory(_Driver.PersonID);

                licenseHistory.ShowDialog();
                _LoadInfo();
            }
            else
            {
                MessageBox.Show("The Person Is Not Found !!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void MShowLicenseInfo_Click(object sender, EventArgs e)
        {
            License.ShowInternationaLicenseInfo showInternationa
                = new License.ShowInternationaLicenseInfo((int)dgvInternationalDrivingLicenses.CurrentRow.Cells[0].Value);

            showInternationa.ShowDialog();

            _LoadInfo();
        }

        private void BtAddInternationaLicense_Click(object sender, EventArgs e)
        {
            NewInternationalDrivingLicense newInternationalDrivingLicense = new NewInternationalDrivingLicense();
            newInternationalDrivingLicense.ShowDialog();
            _LoadInfo();
        }
    }
}
