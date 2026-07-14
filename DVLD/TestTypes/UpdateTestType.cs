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

namespace DVLD.TestTypes
{
    public partial class UpdateTestType : Form
    {
        private int _TestTypeID = -1;
        private clsTestType _TestType;
        public UpdateTestType(int TestTypeID)
        {
            InitializeComponent();

            this._TestTypeID = TestTypeID;

            if(this._TestTypeID != -1)
            {
                _TestType = clsTestType.FindTestType(this._TestTypeID);
            }
        }

        private void UpdateTestType_Load(object sender, EventArgs e)
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

            if (string.IsNullOrWhiteSpace(textDescription.Text))
            {
                errorProvider1.SetError(textDescription, errorMsg);
                isValid = false;
            }
            else { errorProvider1.SetError(textDescription, ""); }


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

            if (_TestType == null)
            {
                MessageBox.Show("Test Type not found.", "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                this.Close();
                return;
            }
            labID.Text = _TestType.TestTypeID.ToString();
            textTitle.Text = _TestType.TestTypeTitle;
            textDescription.Text = _TestType.TestTypeDescription;
            textFees.Text = _TestType.TestTypeFees.ToString();
        }

        private void BtSave_Click_1(object sender, EventArgs e)
        {
            if (this._TestType != null)
            {

                if (_ValidateForm())
                {
                    _TestType.TestTypeTitle = textTitle.Text;
                    _TestType.TestTypeDescription = textDescription.Text;
                    _TestType.TestTypeFees = decimal.Parse(textFees.Text);

                    if (_TestType.Save())
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
                MessageBox.Show("Test Type is NOT Found !!", "Failed", MessageBoxButtons.OK
                            , MessageBoxIcon.Error);
            }
        }
    }
}
