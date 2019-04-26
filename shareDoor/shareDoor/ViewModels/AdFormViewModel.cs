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

    public class AdFormViewModel
    {
        public int Id { get; set; }
        public ICollection<State> States { get; set; }
        public ICollection<Area> Areas { get; set; }
        public House House { get; set; }    
        public HttpPostedFileBase[] Files { get; set; }


        public AdFormViewModel()
        {
            States = new Collection<State>();
            Areas = new Collection<Area>();
      
        }
    }
}