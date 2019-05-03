using PagedList;
using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shareDoor.ViewModels
{
    public enum UserItemsPerPage
    {
        [Display(Name = "2")]
        p02 = 2,
        [Display(Name = "4")]
        p04 = 4,
        [Display(Name = "6")]
        p06 = 6
    }

    public class UserSearchViewModel : ViewModelBase
    {


        public IPagedList<ApplicationUser> Users { get; set; }
        public UserItemsPerPage UserItemsPerPage { get; set; }

    }
}