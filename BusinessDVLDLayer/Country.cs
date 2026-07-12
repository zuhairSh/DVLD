using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataDVLDLayer;

namespace BusinessDVLDLayer
{
    public class clsCountry
    {

        public int ID { set; get; }
        public string CountryName { set; get; }


        private clsCountry(int ID, string CountryName)

        {
            this.ID = ID;
            this.CountryName = CountryName;
          
        }


        static public DataTable GetAllCountries()
        {
            return clsDataCountry.GetAllCountries();
        }


        public static clsCountry Find(int ID)
        {

            string CountryName = "";
            string Code = "";
            string PhoneCode = "";


            int CountryID = -1;

            if (clsDataCountry.GetCountryInfoByID(ID, ref CountryName, ref Code, ref PhoneCode))

                return new clsCountry(ID, CountryName);
            else
                return null;

        }

        public static clsCountry Find(string CountryName)
        {

            int ID = -1;
            

            if (clsDataCountry.GetCountryInfoByName(CountryName, ref ID))

                return new clsCountry(ID, CountryName);
            else
                return null;

        }
    }
}
