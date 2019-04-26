using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shareDoor.ViewModels
{

    public enum SearchOption
    {
        [Display(Name="Συγκάτοικο")]
        RoomMate,
        [Display(Name = "Συγκάτοικο (έχω σπίτι)")]
        NonRoomMate,
        [Display(Name = "Σπίτι")]
        House
    }

    public class SearchViewModel
    {
        public string SearchText { get; set; } = "";
        public SearchOption SearchOption { get; set; }
    }
}