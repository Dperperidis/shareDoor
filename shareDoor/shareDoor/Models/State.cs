using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shareDoor.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Area> Areas { get; set; }
        public ICollection<House> Houses { get; set; }

        public State()
        {
            Areas = new List<Area>();
            Houses = new List<House>();
        }
    }
}