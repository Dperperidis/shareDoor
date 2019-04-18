using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace shareDoor.ViewModels
{
    public class AdFormViewModel
    {
        public House House { get; set; }
        public ICollection<State> States { get; set; }
        public ICollection<Area> Areas { get; set; }
        public int StateId { get; set; }
        public int AreaId { get; set; }

        public AdFormViewModel()
        {
            States = new Collection<State>();
            Areas = new Collection<Area>();
        }
    }
}