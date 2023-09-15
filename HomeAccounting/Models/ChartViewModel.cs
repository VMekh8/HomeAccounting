using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAccounting.Models
{
    public class ChartViewModel : AccountingContext
    {
        public List<string> Dates { get; set; }
        public List<decimal> Amounts { get; set; }
    }
}