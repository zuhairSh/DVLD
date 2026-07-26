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
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public clsTestType.enTestType ID { set; get; }

        public clsTestType()
        {
            this.ID = clsTestType.enTestType.VisionTest;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;
        }

        private clsTestType(enTestType TestTypeID, string TestTypeTitle
            , string TestTypeDescription, decimal TestTypeFees)
        {
            this.ID = TestTypeID;
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
             return clsDataTestTypes.UpdateTestType((int) this.ID,this.TestTypeTitle,this.TestTypeDescription
                 ,this.TestTypeFees);
        }

        public bool Save()
        {
            return _UpdateTestType();
        }

        public static bool isApplicationTypeExist(int TestTypeID)
        {
            return clsDataTestTypes.isTestTypeExist(TestTypeID);
        }

        public static clsTestType FindTestType(clsTestType.enTestType TestTypeID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            decimal TestTypeFees = 0;

            if (clsDataTestTypes.GetTestTypeInfoByID((int)TestTypeID,
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
