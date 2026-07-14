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

namespace DVLD.ApplicationType
{
    public partial class UpdateApplicationType : Form
    {
        private int _ApplicationTypeID = -1;
        private clsApplicationTypes _ApplicationType;

        public UpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();

            this._ApplicationTypeID = ApplicationTypeID;

            if (this._ApplicationTypeID != -1)
            {
                _ApplicationType = clsApplicationTypes.FindApplicationType(this._ApplicationTypeID);

            }
        }

        private void UpdateApplicationType_Load(object sender, EventArgs e)
        {

            _LoadInfo();
        }

        private bool _ValidateForm()
        {
            bool isValid = true;
            string errorMsg = "Please fill in the required fields";



            if (string.IsNullOrWhiteSpace(textTitle.Text))
            {
                errorProvider1.SetError(textTitle, errorMsg);
                isValid = false;
            }
            else { errorProvider1.SetError(textTitle, ""); }

            if (string.IsNullOrWhiteSpace(textFees.Text))
            {
                errorProvider1.SetError(textFees, errorMsg);
                isValid = false;
            }
            else { errorProvider1.SetError(textFees, ""); }

            if (!decimal.TryParse(textFees.Text, out decimal Fees))
            {
                errorProvider1.SetError(textFees, "Please fill in the field in the correct format!!");
                isValid = false;
            }
            else { errorProvider1.SetError(textFees, ""); }

            return isValid;
        }


        private void _LoadInfo()
        {

            if (_ApplicationType == null)
            {
                MessageBox.Show("Application Type not found.","Error",MessageBoxButtons.OK
                    ,MessageBoxIcon.Error);
                this.Close(); 
                return;
            }
            labID.Text = _ApplicationType.ApplicationTypeID.ToString();
            textTitle.Text = _ApplicationType.ApplicationTypeTitle;
            textFees.Text = _ApplicationType.ApplicationFees.ToString();
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if(this._ApplicationType != null)
            {

                if (_ValidateForm())
                {
                    _ApplicationType.ApplicationTypeTitle = textTitle.Text;
                    _ApplicationType.ApplicationFees = decimal.Parse(textFees.Text);
                    
                    if (_ApplicationType.Save())
                    {
                        MessageBox.Show(" Saved Successfully !!", "Successfully", MessageBoxButtons.OK
                            , MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show(" Save Failed !!", "Failed", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in the required fields !!", "Failed", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Application Type is NOT Found !!", "Failed", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
