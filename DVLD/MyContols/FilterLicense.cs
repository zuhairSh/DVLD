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

namespace DVLD.MyContols
{
    public partial class FilterLicense : UserControl
    {
        private int _LicenseID = -1;
        public event Action<int> OnLicenseSelected;

        protected virtual void PersonSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        private clsLicense _LicenseInfo;

        public clsLicense SelectedLicenseInfo
        {
            get { return _LicenseInfo; }
        }

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public FilterLicense()
        {
            InitializeComponent();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FilterLicense_Load(object sender, EventArgs e)
        {

        }

        public void LoadLicenseInfo(int LicenseID)
        {
            textBox1.Text = LicenseID.ToString();
            _LicenseInfo = clsLicense.Find(LicenseID);

            if (_LicenseInfo != null)
            {
                licenseInfo1.LoadLicenseInfo(LicenseID);
                _LicenseID = _LicenseInfo.LicenseID;

                if (OnLicenseSelected != null)
                    OnLicenseSelected(_LicenseID);
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Please enter License ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int.TryParse(textBox1.Text, out int LicenseID);
            _LicenseInfo = clsLicense.Find(LicenseID);

            if (_LicenseInfo == null)
            {
                MessageBox.Show("The License is Not Found!!", "Verified",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }
            else
            {
                _LicenseID = _LicenseInfo.LicenseID;
                licenseInfo1.LoadLicenseInfo(LicenseID);

                // إطلاق الحدث لإبلاغ الشاشة بأن الرخصة تم إيجادها بنجاح
                if (OnLicenseSelected != null)
                    OnLicenseSelected(_LicenseID);
            }
        }
    }
}