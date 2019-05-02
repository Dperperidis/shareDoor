﻿using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shareDoor.ViewModels
{
    public class AdSearchFiltersViewModel
    {
        public ICollection<House> Houses {get; set;}
        public ICollection<State> States { get; set; }
        public ICollection<Area> Areas { get; set; }
        public string Pets { get; set; }
        public string Smoker { get; set; }
        public string Gender { get; set; }
        public string SearchRentCost { get; set; }
        public string HasPhotos { get; set; }
        public int AreaId { get; set; } 
        public int StateId { get; set; }

        public AdSearchFiltersViewModel()
        {
            Areas = new List<Area>();
        }
    }
}