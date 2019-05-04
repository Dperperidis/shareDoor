using shareDoor.Data;
using shareDoor.Dto;
using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shareDoor.ViewModels
{

    public class AdFormViewModel : ViewModelBase
    {

        public AdFormViewModel()
        {
            States = new List<State>();
            Areas = new List<Area>();
        }

        public int Id { get; set; }
        public ICollection<State> States { get; set; } 
        public ICollection<Area> Areas { get; set; }
        public House House { get; set; }
        public ApplicationUser User { get; set; }
        public AlertDto Alert { get; set; }
        public HttpPostedFileBase[] Files { get; set; }
        public string Action { get; set; }
        public string ButtonAction { get; set; }
        public string FormAction { get; set; }
        

     
    }
}