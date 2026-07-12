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
using System.Text.RegularExpressions;
using System.IO;
using DVLD.Classes;
using DVLD.Properties;

namespace DVLD
{
    public partial class AddEdit : UserControl
    {
        public delegate void DataSavedEventHandler(int PersonID);
        public event DataSavedEventHandler OnDataSaved;

        public clsPeople _PersonInfo { get; set; }
        private string _ImagePathToBeDeleted = "";


        public AddEdit()
        {
            InitializeComponent();
        }

        private void _FillCountresInComboCountries()
        {
            DataTable dataTable = clsCountry.GetAllCountries();

            foreach (DataRow row in dataTable.Rows)
            {
                comboCountry.Items.Add(row["CountryName"]);
            }
        }

       private void _SendDefaultInfo()
        {
            _FillCountresInComboCountries();
            dateBirth.MaxDate = DateTime.Today.AddYears(-18);
            dateBirth.MinDate = DateTime.Today.AddYears(-100);

            comboCountry.SelectedIndex = comboCountry.FindString("Oman");
            linkLabel2.Visible = (picturePerson.ImageLocation != null);

        }

        private void AddEdit_Load(object sender, EventArgs e)
        {
            _SendDefaultInfo();
        }


        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Select Image for Person";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectPathForImage = openFileDialog.FileName;
                picturePerson.Load(selectPathForImage);
                linkLabel2.Visible = true;
            }
        }

        private bool _HandlePersonImage()
        {
            if (_PersonInfo.ImagePath != picturePerson.ImageLocation)
            {
                if (_PersonInfo.ImagePath != "")
                {
                    try
                    {
                        if (File.Exists(_PersonInfo.ImagePath))
                            File.Delete(_PersonInfo.ImagePath);
                    }
                    catch (IOException) { }
                }

                if (picturePerson.ImageLocation != null)
                {
                    string SourceImageFile = picturePerson.ImageLocation;

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        picturePerson.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Do you want to Remove Image ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _ImagePathToBeDeleted = picturePerson.ImageLocation;

                picturePerson.ImageLocation = null;

                picturePerson.Image = radioFemale.Checked ? Resources.Female_512 : Resources.Male_512;

                linkLabel2.Visible = false;
            }
        }

        private void RadioMale_CheckedChanged(object sender, EventArgs e)
        {
            picturePerson.Image = Properties.Resources.Male_512;
        }

        private bool _ValidateForm()
        {
            bool isValid = true;
            string errorMsg = "Please fill in the required fields";



            if (string.IsNullOrWhiteSpace(textFirst.Text))
            {
                errorProvider1.SetError(textFirst, errorMsg);
                isValid = false;
            }
            else { errorProvider1.SetError(textFirst, ""); }

            if (string.IsNullOrWhiteSpace(textSeccond.Text))
            {
                errorProvider1.SetError(textSeccond, errorMsg);
                isValid = false;
            }
            else { errorProvider1.SetError(textSeccond, ""); }


            if (string.IsNullOrWhiteSpace(textLast.Text))
            {
                errorProvider1.SetError(textLast, errorMsg);
                isValid = false;
            }
            else { errorProvider1.SetError(textLast, ""); }



            if (string.IsNullOrWhiteSpace(textNational.Text))
            {
                errorProvider1.SetError(textNational, errorMsg);
                isValid = false;
            }
            else { errorProvider1.SetError(textNational, ""); }

            if (string.IsNullOrWhiteSpace(textPhone.Text))
            {
                errorProvider1.SetError(textPhone, errorMsg);
                isValid = false;
            }
            else { errorProvider1.SetError(textPhone, ""); }

            if (string.IsNullOrWhiteSpace(textAddress.Text))
            {
                errorProvider1.SetError(textAddress, errorMsg);
                isValid = false;
            }
            else { errorProvider1.SetError(textAddress, ""); }

    

            if (comboCountry.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboCountry, errorMsg);
                isValid = false;
            }
            else { errorProvider1.SetError(comboCountry, ""); }

           
            if (!radioMale.Checked && !radioFemale.Checked)
            {
                errorProvider1.SetError(radioMale, errorMsg);
                isValid = false;
            }
            else { errorProvider1.SetError(radioMale, ""); }

            return isValid;
        }


        private bool _EmailFormat(string email)
        {
    
          string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

          return Regex.IsMatch(email, pattern);
            
        }


        private bool _ValidateEmail()
        {
            bool _Validate = false;
            string email = textEmail.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                errorProvider1.SetError(textEmail, ""); 
                return _Validate = true;
            }

            
            if (!_EmailFormat(email))
            {
                errorProvider1.SetError(textEmail, "The email format is incorrect!");
                _Validate = false;
            }
           
            else
            {
                errorProvider1.SetError(textEmail, "");
                _Validate = true;
            }

            return _Validate;
        }

        private bool _ValidateNationalNo()
        {
            bool Validate = false;

            if (_PersonInfo != null && textNational.Text == _PersonInfo.NationalNo)
            {
                errorProvider1.SetError(textNational, "");
                return true;
            }


            if (textNational.Text != null && clsPeople.isPersonExist(textNational.Text))
            {
                errorProvider1.SetError(textNational, "The NationalNo belongs to erson else !!");
                Validate = false;
            }
            else
            {
                errorProvider1.SetError(textNational, "");
                Validate = true;


            }
               
            return Validate;
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if (_ValidateForm() && _ValidateEmail() && _ValidateNationalNo())
            {

                if (!_HandlePersonImage())
                    return;

                _PersonInfo.FirstName = textFirst.Text;
                _PersonInfo.SeccondName = textSeccond.Text;
                _PersonInfo.TherdName = textThird.Text;
                _PersonInfo.LastName = textLast.Text;
                _PersonInfo.NationalNo = textNational.Text;
                _PersonInfo.Phone = textPhone.Text;
                _PersonInfo.Email = textEmail.Text;
                _PersonInfo.Address = textAddress.Text;
                _PersonInfo.DateOfBirth = dateBirth.Value;
                _PersonInfo.Gendor = (radioMale.Checked) ? (byte)0 : (byte)1;

                _PersonInfo.CountryID = clsCountry.Find(comboCountry.Text).ID;
                if (picturePerson.ImageLocation != null)
                    _PersonInfo.ImagePath = picturePerson.ImageLocation;
                else
                    _PersonInfo.ImagePath = "";
                

                if (_PersonInfo.Save())
                {
                    
                    MessageBox.Show("Data Saved Successfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnDataSaved?.Invoke(_PersonInfo.PersonID);
                }
                else
                {
                    MessageBox.Show("Error!! , Data Is NOT Saved !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void BtClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Form ?", "Verified"
                ,MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.ParentForm.Close();
            }
        }

        private void RadioFemale_CheckedChanged(object sender, EventArgs e)
        {
            picturePerson.Image = Properties.Resources.Female_512;
        }

        private void TextPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void PicturePerson_Click(object sender, EventArgs e)
        {

        }

        private void TextThird_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }
    }
}
