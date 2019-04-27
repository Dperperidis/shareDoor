using PagedList;
using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shareDoor.ViewModels
{


    public enum ItemsPerPage
    {
        [Display(Name = "5")]
        p05 = 5,
        [Display(Name = "10")]
        p10 = 10,
        [Display(Name = "15")]
        p15 = 15
    }

    public enum SearchConfirm
    {
        [Display(Name = "Εγκεκριμένες")]
        success,
        [Display(Name = "Εκκρεμών")]
        warning ,
        [Display(Name = "Απορριφθέντες")]
        danger ,
        [Display(Name = "Όλες")]
        all
    }

    public class AdminSearchViewModel
    {
        public IPagedList<House> Houses { get; set; }
        public ItemsPerPage ItemsPerPage { get; set; }
        public SearchConfirm SearchConfirm { get; set; }


    }
}