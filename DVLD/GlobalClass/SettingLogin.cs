using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessDVLDLayer;

namespace DVLD.GlobalClass
{
    public class clsSettingLogin
    {
        public static int UserID = -1;
        public static string UserName = "";
        public static string Password = "";
        public static bool isRemandUser = false;

        public static bool GetUserID()
        {
            return clsUser.GetUserIDByUserName(UserName,ref UserID);
        }

    }
}
