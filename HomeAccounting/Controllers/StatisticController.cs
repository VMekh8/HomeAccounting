using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeAccounting.Models;



namespace HomeAccounting.Controllers
{

    public class StatisticController : Controller
    {
        private AccountingContext db = new AccountingContext();
        
        public ActionResult Index()
        {

            decimal totalIncome = 0;
            decimal totalExpense = 0;
            decimal balance = 0;

            if (db.Incomes.Any())
            {
                totalIncome = db.Incomes.Sum(income => income.Amount);
            }

            if (db.Expenses.Any())
            {
                totalExpense = db.Expenses.Sum(income => income.Amount);
            }

            balance = totalIncome - totalExpense;
            Statistic model = new Statistic
            {
                TotalIncome = totalIncome,
                TotalExpenses = totalExpense,
                Balance = balance
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult GetTransactionsByPeriod(DateTime StartTime, DateTime EndTime)
        {
            decimal totalIncome = 0;
            decimal totalExpense = 0;
            decimal balance = 0;

            var incomes = db.Incomes.Where(i => i.DateReceived >= StartTime && i.DateReceived<= EndTime).ToList();
            var expenses = db.Expenses.Where(e => e.Date >= StartTime && e.Date <= EndTime).ToList();

            totalIncome = incomes.Sum(income => income.Amount);
            totalExpense = expenses.Sum(expense => expense.Amount);
            balance = totalIncome - totalExpense;

            Statistic model = new Statistic
            {
                TotalIncome = totalIncome,
                TotalExpenses = totalExpense,
                Balance = balance,
                Incomes = incomes,
                Expenses = expenses
            };

            return View(model);
        }
    }
}