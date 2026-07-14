using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDVLDLayer;

namespace BusinessDVLDLayer
{
    public class clsTestType
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public clsTestType()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;
        }

        private clsTestType(int TestTypeID, string TestTypeTitle
            , string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsDataTestTypes.GetAllTestType();
        }

        private bool _UpdateTestType()
        {
            return clsDataTestTypes.UpdateTestType(this.TestTypeID, this.TestTypeTitle, 
                this.TestTypeDescription , this.TestTypeFees);
        }

        public bool Save()
        {
            return _UpdateTestType();
        }

        public static bool isApplicationTypeExist(int TestTypeID)
        {
            return clsDataTestTypes.isTestTypeExist(TestTypeID);
        }

        public static clsTestType FindTestType(int TestTypeID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            decimal TestTypeFees = 0;

            if (clsDataTestTypes.GetTestTypeInfoByID(TestTypeID,
                ref TestTypeTitle, ref TestTypeDescription,ref TestTypeFees))
            {
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription
                    , TestTypeFees);
            }
            else
                return null;
        }

    }
}
