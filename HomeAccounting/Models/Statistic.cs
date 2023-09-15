using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeAccounting.Models
{
    public class Statistic
    {
        public decimal TotalIncome { get; internal set; }
        public decimal TotalExpenses { get; internal set; }
        public decimal Balance { get; internal set; }
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }

        public Income Income
        {
            get => default(Income);
            set
            {
            }
        }

        public Expense Expense
        {
            get => default(Expense);
            set
            {
            }
        }
    }
}