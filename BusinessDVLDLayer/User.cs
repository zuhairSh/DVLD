using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDVLDLayer;
using System.Data;

namespace BusinessDVLDLayer
{
    public class clsUser
    {
        private enum enMode { Add = 0, Update = 1 };
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }

        private enMode _Mode;


        public clsUser()
        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.PersonID = -1;
            this.isActive = false;
            _Mode = enMode.Add;

        }

        private clsUser(int UserID, int PersonID, string UserName,string Password,bool isActive)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.PersonID = PersonID;
            this.isActive = isActive;
            _Mode = enMode.Update;
        }

        static public clsUser FindUser(int UserID)
        {
            string UserName = "";
            string Password = "";
            int PersonID = -1;
            bool isActive = false;

            if (clsDataUser.GetUserInfoByID(UserID, ref PersonID, ref UserName, ref Password, ref isActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            }
            else
                return null;
        }

        static public clsUser FindUser(string NationalNo)
        {
            int UserID = -1;
            string UserName = "";
            string Password = "";
            int PersonID = -1;
            bool isActive = false;

            if (clsDataUser.GetUserInfoByNationalNo(NationalNo,ref UserID,ref PersonID,ref UserName,
                ref Password,ref isActive))
            { 
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            }
            else
                return null;
        }

        static public DataTable GetAllUsers()
        {
            return clsDataUser.GetAllUsers();
        }

        private bool _AddUse()
        {
            this.UserID = clsDataUser.AddUser(this.PersonID, this.UserName,
                this.Password, this.isActive);
            return this.UserID != -1;
        }

        private bool _UpdateUser()
        {
            return clsDataUser.UpdateUser(this.UserID, this.PersonID, this.UserName,
                this.Password , this.isActive);
        }

        public static bool DeleteUserByID(int UserID)
        {
            return clsDataUser.DeleteUserByID(UserID);
        }

        public static bool isUserExist(int UserID)
        {
            return clsDataUser.IsUserExist(UserID);
        }

        public static bool isUserExist(string NationalNo)
        {
            return clsDataUser.IsUserExist(NationalNo);
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            return clsDataUser.IsUserExistByPersonID(PersonID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_AddUse())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateUser();

                default:
                    return false;
            }
        }

    }
}
