
using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shareDoor.ViewModels
{
    public enum Badges
    {
        success,
        warning,
        danger
    }


    public class UserProfileViewModel
    {
        public ApplicationUser User { get; set; }
        public Badges Badge { get; set; } = Badges.warning;
        public HttpPostedFileBase[] Files { get; set; }
        public int Age { get; set; }



        public string GetDate(DateTime dateTime)
        {
            return dateTime.ToShortDateString();
        }




    }
}