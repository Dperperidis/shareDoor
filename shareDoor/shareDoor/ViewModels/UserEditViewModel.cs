using Microsoft.AspNet.Identity.EntityFramework;
using shareDoor.Dto;
using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shareDoor.ViewModels
{
    public class UserEditViewModel : ViewModelBase
    {
        public ICollection<IdentityRole> Roles { get; set; }
        public ApplicationUser User { get; set; }


        public string GetImage()
        {
            if (User.UserPhotos.Any(x => x.IsMain == true))
            {
                return User.UserPhotos.FirstOrDefault(y => y.IsMain == true).Url;
            }
            else
            {
                return "https://res.cloudinary.com/dmizwj8w8/image/upload/v1556883161/wheckiv5kur0dsjnxynr.jpg";
            }
        }

        public MemberShipDto TrophyColor()
        {
            MemberShipDto result = new MemberShipDto();
            var role = User.Roles.First();
            var roleName = Roles.FirstOrDefault(x => x.Id == role.RoleId).Name;
            result.TrophyColor = "";
            result.TrophyTitle = "";

            switch (roleName)
            {
                case "Member":
                    result.TrophyColor = "~/Images/trophies/cup.png";
                    result.TrophyTitle = "Member";
                    break;
                case "Silver Member" :
                    result.TrophyColor = "~/Images/trophies/cup(1).png";
                    result.TrophyTitle = "Silver";
                    break;
                case "Gold Member":
                    result.TrophyColor = "~/Images/trophies/cup(2).png";
                    result.TrophyTitle = "Gold";
                    break;
                case "Admin":
                    result.TrophyColor = "~/Images/trophies/cup(3).png";
                    result.TrophyTitle = "Admin";
                    break;
                   
            }

            return result;
        }

    }

}