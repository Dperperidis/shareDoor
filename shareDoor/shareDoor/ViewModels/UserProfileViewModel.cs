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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<House> Houses { get; set; }
        public string Email { get; set; }
        public Badges Badge { get; set; } = Badges.warning;

    }
}