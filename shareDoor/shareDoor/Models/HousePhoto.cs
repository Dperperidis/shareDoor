using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shareDoor.Models
{
    public class HousePhoto : Photo
    {
        public int Id { get; set; }
        public House House { get; set; }
    }
}