using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDVLDLayer;

namespace BusinessDVLDLayerPeople
{
    public class clsPeople
    {
        private enum enMode { Add = 0, Update = 1 };
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SeccondName { get; set; }
        public string TherdName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public byte Gendor { get; set; }
        public string ImagePath { get; set; }

        private enMode _Mode;


        public clsPeople()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SeccondName = "";
            this.TherdName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 2;
            this.CountryID = -1;
            this.ImagePath = "";
            _Mode = enMode.Add;
        }

        private clsPeople(int PersonID, string NationalNo, string FirstName, 
            string SeccondName, string TherdName, string LastName, string Email, string Phone, string Address,
            DateTime DateOfBirth,int CountryID, byte Gendor, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SeccondName = SeccondName;
            this.TherdName = TherdName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;

            _Mode = enMode.Update;
        }

        public static DataTable GetAllPeople()
        {
            return clsDataPeople.GetAllPeople();
        }

        public static clsPeople FindPersonByID(int PersonID)
        {
            string NationalNo = "";
            string FirstName = "";
            string SeccondName = "";
            string TherdName = "";
            string LastName = "";
            string Email = "";
            string Phone = "";
            DateTime DateOfBirth = DateTime.Now;
            string Address = "";
            byte Gendor = 2;
            int CountryID = -1;
            string ImagePath = "";

            if (clsDataPeople.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref SeccondName,
                ref TherdName, ref LastName, ref Email, ref Phone, ref Address, ref DateOfBirth,
                ref CountryID, ref Gendor, ref ImagePath))
            {
                return new clsPeople(PersonID, NationalNo, FirstName, SeccondName, TherdName, LastName,
                    Email, Phone, Address, DateOfBirth, CountryID, Gendor, ImagePath);
            }
            else
            {
                return null;
            }
        }


        public static clsPeople FindPersonByNationalNo(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1, NationalityCountryID = -1;
            byte Gendor = 0;

            bool IsFound = clsDataPeople.GetPersonInfoByNationalNo
                                (
                                    NationalNo, ref PersonID, ref FirstName, ref SecondName,
                                    ref ThirdName, ref LastName, ref DateOfBirth,
                                    ref Gendor, ref Address, ref Phone, ref Email,
                                    ref NationalityCountryID, ref ImagePath
                                );

            if (IsFound)
                return new clsPeople( PersonID,  NationalNo,  FirstName, SecondName,  ThirdName,  LastName,  Email,  Phone,  Address,
             DateOfBirth,  NationalityCountryID,  Gendor,  ImagePath);

            else
                return null;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsDataPeople.AddPerson(this.NationalNo, this.FirstName, this.SeccondName, this.TherdName, this.LastName
               , this.Email, this.Phone, this.Address, this.DateOfBirth, this.CountryID, this.Gendor, this.ImagePath);

            return (PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsDataPeople.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SeccondName, this.TherdName, this.LastName
               , this.Email, this.Phone, this.Address, this.DateOfBirth,
               this.CountryID, this.Gendor, this.ImagePath);
        }

        public static bool DeletePersonByID(int PersonID)
        {
            return clsDataPeople.DeletePersonByID(PersonID);
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if(_AddNewPerson())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();

                default:
                    return false;
            }    
        }



        public static bool isPersonExist(int ID)
        {
            return clsDataPeople.IsPersonExist(ID);
        }

        public static bool isPersonExist(string NationlNo)
        {
            return clsDataPeople.IsPersonExist(NationlNo);
        }
    }
}

