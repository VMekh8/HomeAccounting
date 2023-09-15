using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeAccounting.Models
{
    public class ExpenseListViewModel : ChartViewModel
    {
        public IEnumerable<Expense> Epxenses { get; set; }
        public SelectList Category { get; set; }
        public SelectList Name { get; set; }
    }
}