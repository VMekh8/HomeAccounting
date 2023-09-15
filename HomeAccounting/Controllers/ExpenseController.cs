using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HomeAccounting.Models;


namespace HomeAccounting.Controllers
{
    public class ExpenseController : Controller
    {
        private AccountingContext db = new AccountingContext();
        // GET: Expense
        public ActionResult Index()
        {
            IEnumerable<Expense> expenses = db.Expenses;
            ViewBag.Expenses = expenses;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id, Name, Amount, Category, Date")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            var expense = db.Expenses.Find(id);
            if (expense == null)
            {
                ModelState.AddModelError("id", "Об'єкт з введеним id не знайдено."); // Додати повідомлення про помилку в ModelState
                return View("Delete"); // Повернути користувача на сторінку з формою
            }

            // Видалення об'єкту з бази даних
            db.Expenses.Remove(expense);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public ActionResult Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ViewBag.ErrorMessage = "Категорія не вибрана.";
                return PartialView("Error");
            }

            var allexpenses = db.Expenses.Where(a => a.Category.Contains(name)).ToList();
            if (allexpenses.Count <= 0)
            {
                return HttpNotFound();
            }

            return PartialView(allexpenses);
        }

        public ActionResult ExpenseView(int id)
        {
            var software = db.Expenses.Find(id);
            if (software != null)
            {
                return View(software);
            }
            return RedirectToAction("Index");
        }

    }
}