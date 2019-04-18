using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shareDoor.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
        public ICollection<House> Houses { get; set; }

        public Area()
        {
            Houses = new List<House>();
        }

    }
}