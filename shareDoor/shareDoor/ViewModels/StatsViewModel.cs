using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shareDoor.ViewModels
{
    public class StatsViewModel: ViewModelBase
    {
        public int AdsCount { get; set; }
        public int UserCount { get; set; }
        public int MessagesCount { get; set; }
        public int PurchaseCount { get; set; }
    }
}