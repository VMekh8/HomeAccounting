using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HomeAccounting.Models
{
    public class IncomeDBInitializer : ChartViewModel
    {
        protected override void Seed(AccountingContext context)
        {
            context.Incomes.Add(new Income
            {
                Name = "Init",
                Amount = 0,
                DateReceived = DateTime.Today

            });

            base.Seed(context);
        }
    }
}