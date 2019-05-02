using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shareDoor.ViewModels
{
    public class ViewModelBase
    {
        public static string UserPhoto { get; set; }
        public static string NickName { get; set; }

        public string GetUserPhoto()
        {
            return UserPhoto;
        }

        public string GetNickName()
        {
            return NickName;
        }
    }
}