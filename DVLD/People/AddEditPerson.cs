using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessDVLDLayerPeople;
using DVLD;
using BusinessDVLDLayer;
using System.IO;

namespace DVLD.People
{
    public partial class AddEditPerson : Form
    {

        enum enModes { eAddNew = 0, eUpdate = 1 };
        private enModes _Mode;
        public int _PersonID;
        private clsPeople _Person;
      
        public AddEditPerson(int PersonID)
        {
            InitializeComponent();

            addEdit1.OnDataSaved += AddEdit1_OnDataSaved;
            this._PersonID = PersonID;

            if(PersonID == -1)
            {
                _Mode = enModes.eAddNew;
            }
            else
            {
                _Mode = enModes.eUpdate;
            }
        }

        private void AddEdit1_OnDataSaved(int PersonID)
        {
            _Mode = enModes.eUpdate;
            _PersonID = PersonID;
            labelMode.Text = "Edit Person";
            labelPersonID.Text = _PersonID.ToString();

            _Person = clsPeople.FindPersonByID(_PersonID);
            addEdit1._PersonInfo = _Person;
        }

        private void _LoadData()
        {

            if (_Mode == enModes.eAddNew)
            {
                labelMode.Text = "Add Person";
                _Person = new clsPeople();
                addEdit1._PersonInfo = _Person;

          
                return;
             
            }
            else
            {
                labelMode.Text = "Edit Person";
                labelPersonID.Text = _PersonID.ToString();


                _Person = clsPeople.FindPersonByID(_PersonID);

                if (_Person == null)
                {
                    MessageBox.Show("This Person id Not Found in Data !!");
                    this.Close();
                    return;
                }

                labelPersonID.Text = _PersonID.ToString();
                addEdit1.textFirst.Text = _Person.FirstName;
                addEdit1.textSeccond.Text = _Person.SeccondName;
                addEdit1.textThird.Text = _Person.TherdName;
                addEdit1.textLast.Text = _Person.LastName;
                addEdit1.textNational.Text = _Person.NationalNo;
                addEdit1.textPhone.Text = _Person.Phone;
                addEdit1.textEmail.Text = _Person.Email;
                addEdit1.textAddress.Text = _Person.Address;
                addEdit1.dateBirth.Value = _Person.DateOfBirth;
                addEdit1.radioMale.Checked = (_Person.Gendor == 0);
                addEdit1.radioFemale.Checked = (_Person.Gendor == 1);

                if (_Person.ImagePath != "")
                {
                    addEdit1.picturePerson.ImageLocation = _Person.ImagePath;
                    
                }
                else
                {
                    addEdit1.picturePerson.Image = Properties.Resources.Male_512;
                }
                
                addEdit1.linkLabel2.Visible = (_Person.ImagePath != "");

                addEdit1.comboCountry.SelectedIndex = addEdit1.comboCountry.FindString(clsCountry.Find(_Person.CountryID).CountryName);


                addEdit1._PersonInfo = _Person;
            }
        }

 

        private void AddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

    }
}
