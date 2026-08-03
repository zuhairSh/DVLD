using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessDVLDLayer;
using Microsoft.Win32;

namespace DVLD.GlobalClass
{
    public class clsSettingLogin
    {
        public static clsUser CurretUser;


        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            try
            {

                string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

                Registry.SetValue(KeyPath, "UserName", Username);
                Registry.SetValue(KeyPath, "Password", Password);


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {

                string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

                string _UserName, _Password = "";

                _UserName = Registry.GetValue(KeyPath, "UserName", null) as string;
                _Password = Registry.GetValue(KeyPath, "Password", null) as string;

                if (_UserName != null && _Password != null)
                {
                    Username = _UserName;
                    Password = _Password;
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }



    }
}
