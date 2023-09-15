using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HomeAccounting.Models
{
    public class AccountingContext : Statistic
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        //public DbSet<Statistic> Statistics { get; set; }
    }
}