using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HomeAccounting.Models
{
    public class ExpenseDBInitializer : ExpenseListViewModel
    {
        protected override void Seed(AccountingContext context)
        {
            context.Expenses.Add(new Expense
            {
                Name = "Init",
                Amount = 0,
                Category = "Init",
                Date = DateTime.Today
            });
            base.Seed(context);
        }
    }
}