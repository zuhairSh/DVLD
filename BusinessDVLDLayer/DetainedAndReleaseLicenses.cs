using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDVLDLayer;

namespace BusinessDVLDLayer
{
    public class clsDetainedAndReleaseLicense
    {
        private enum enMode { eAdd  = 0, eUpdate  =1};
        private enMode _Mode;

        public int DetainID { set; get; }
        public int LicenseID { set; get; }
        public clsLicense LicenseInfo { set; get; }
        public DateTime DetainDate { set; get; }
        public float FineFees { set; get; }
        public bool IsReleased { set; get; }
        public int CreatedByUserID { set; get; }
        public int ReleasedByUserID { set; get; }
        public int ReleaseApplicationID { set; get; }
        public DateTime ReleaseDate { set; get; }


        public clsDetainedAndReleaseLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees  = -1;
            IsReleased = false;
            CreatedByUserID = -1;
            ReleasedByUserID  = -1;
            ReleaseApplicationID = -1;
            ReleaseDate = DateTime.Now;
            _Mode = enMode.eAdd;
        }

        private clsDetainedAndReleaseLicense(int DetainID,int LicenseID,DateTime DetainDate
            ,float FineFees,bool IsReleased,int CreatedByUserID, int ReleasedByUserID
            ,int ReleaseApplicationID,DateTime ReleaseDate)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.IsReleased = IsReleased;
            this.CreatedByUserID = CreatedByUserID;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.ReleaseDate = ReleaseDate;
            this.LicenseInfo = clsLicense.Find(LicenseID);
            _Mode = enMode.eUpdate;
        }

        public static clsDetainedAndReleaseLicense Find(int DetainID)
        {
            int LicenseID = -1, CreatedByUserID = -1, ReleasedByUserID = -1,
                ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.MinValue;
            float FineFees = 0;
            bool IsReleased = false;

            if (clsDataDetainedAndReleaseLicenses.GetDetainedLicenseInfoByID(DetainID,
                ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID,
                ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedAndReleaseLicense(DetainID, LicenseID, 
                    DetainDate , FineFees, IsReleased, CreatedByUserID, 
                    ReleasedByUserID, ReleaseApplicationID, ReleaseDate);
            }
            else
            {
                return null;
            }
        }

        static public DataTable GetAllDetained()
        {
            return clsDataDetainedAndReleaseLicenses.GetAllDetainedAndReleaseLicenses();
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID)
        {

            int ReleaseApplicationID = -1;
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.LicenseInfo.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationFees;
            Application.CreatedByUserID = ReleasedByUserID;

            if(!Application.Save())
            {
                ReleaseApplicationID = -1;
                return false;
            }

            ReleaseApplicationID = Application.ApplicationID;

            bool isReleased = clsDataDetainedAndReleaseLicenses.ReleaseDetainedLicense(
                this.DetainID, ReleasedByUserID, ReleaseApplicationID);

            if (isReleased)
            {
                this.IsReleased = true;
                this.ReleaseDate = DateTime.Now;
                this.ReleasedByUserID = ReleasedByUserID;
                this.ReleaseApplicationID = ReleaseApplicationID;

                return this.LicenseInfo.ActivateCurrentLicense();
            }

            return false;
        }

        static public clsDetainedAndReleaseLicense FindByLicenseID(int LicenseID)
        {
            int DetainID = -1, CreatedByUserID = -1, ReleasedByUserID = -1,
                ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.MinValue;
            float FineFees = 0;
            bool IsReleased = false;

            if (clsDataDetainedAndReleaseLicenses.GetDetainedLicenseInfoByLicenseID(LicenseID,
                ref DetainID , ref DetainDate, ref FineFees, ref CreatedByUserID,
                ref IsReleased, ref ReleaseDate, ref ReleasedByUserID
                , ref ReleaseApplicationID))
            {
                return new clsDetainedAndReleaseLicense(DetainID, LicenseID, DetainDate, 
                    FineFees
                    , IsReleased, CreatedByUserID, ReleasedByUserID,
                    ReleaseApplicationID, ReleaseDate);
            }
            else
            {
                return null;
            }
        }


        private bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDataDetainedAndReleaseLicenses.DetainedLicenses(
                this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);

            this.LicenseInfo = clsLicense.Find(this.LicenseID);

            if (this.DetainID != -1 && LicenseInfo != null)
            {
                return LicenseInfo.DeactivateCurrentLicense();
            }

            return false;
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            clsDetainedAndReleaseLicense detainedLicense = FindByLicenseID(LicenseID);

            return (detainedLicense != null && !detainedLicense.IsReleased);
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.eAdd:
                    if (_AddNewDetainedLicense())
                    {
                        _Mode = enMode.eUpdate;
                        return true;
                    }
                    return false;

                case enMode.eUpdate:
                    
                    return false;
            }

            return false;
        }

    }
}
