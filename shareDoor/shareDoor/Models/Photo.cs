using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shareDoor.Models
{
    public class Photo
    {
       
        public bool IsMain { get; set; }
        public string Url { get; set; } 
       
    }
}