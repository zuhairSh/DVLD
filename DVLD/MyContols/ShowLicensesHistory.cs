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

namespace DVLD.MyContols
{
    public partial class ShowLicensesHistory : UserControl
    {
        private clsPeople _Person;
        public ShowLicensesHistory()
        {
            InitializeComponent();
        }

        public void LoadAllInfo(int personID)
        {
            _Person = clsPeople.FindPersonByID(personID);
            if (_Person != null)
            {
                displayFilter1.Enabled = false;
                displayFilter1._DownData(_Person);

                clsDriver Driver = clsDriver.FindByPersonID(personID);
                if (Driver != null)
                {
                    dvgLocalLicense.DataSource = clsLicense.GetDriverLicenses(Driver.DriverID);
                    dgvInternationalLicense.DataSource = clsInternationalLicense.GetDriverInternationalLicenses(Driver.DriverID);
                }
            }
        }

        private void ShowLicensesHistory_Load(object sender, EventArgs e)
        {

        }

        private void DisplayFilter1_Load(object sender, EventArgs e)
        {

        }

        private void DgvInternationalLicense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ShowLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                License.ShowLicenseInfo showLicenseInfo =
                        new License.ShowLicenseInfo((int)dvgLocalLicense.CurrentRow.Cells[0].Value);
                showLicenseInfo.ShowDialog();
            }
           
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                showLicenseInfoToolStripMenuItem.Visible = true;
                showILicenseInfoToolStripMenuItem.Visible = false;
                
            }
            else
            {
                showLicenseInfoToolStripMenuItem.Visible = false;
                showILicenseInfoToolStripMenuItem.Visible = true;

            }
        }

        private void ShowILicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                License.ShowInternationaLicenseInfo showInternationa =
                    new License.ShowInternationaLicenseInfo((int)dgvInternationalLicense.CurrentRow.Cells[0].Value);

                showInternationa.ShowDialog();
            }
        }
    }
}
