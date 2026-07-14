using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDVLDLayer;

namespace BusinessDVLDLayer
{
    public class clsApplicationTypes
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        public clsApplicationTypes()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = 0;
        }

        private clsApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle
            ,  decimal ApplicationTypeFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationFees = ApplicationTypeFees;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsDataApplicationType.GetAllApplicationType();
        }

        private bool _UpdateApplicationType()
        {
            return clsDataApplicationType.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle
                , this.ApplicationFees);
        }

        public bool Save()
        {
            return _UpdateApplicationType();
        }

        public static bool isApplicationTypeExist(int ApplicationTypeID)
        {
            return clsDataApplicationType.isApplicationTypeExist(ApplicationTypeID);
        }

        public static clsApplicationTypes FindApplicationType(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationTypeFees = 0;

            if (clsDataApplicationType.GetApplicationTypeInfoByID(ApplicationTypeID,
                ref ApplicationTypeTitle, ref ApplicationTypeFees))
            {
                return new clsApplicationTypes(ApplicationTypeID, ApplicationTypeTitle
                    , ApplicationTypeFees);
            }
            else
                return null;
        }
    }
}
