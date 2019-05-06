using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shareDoor.ViewModels
{
    public class PaymentFormViewModel
    {
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public string FullName { get; set; }
        public string Price { get; set; }

    }
}