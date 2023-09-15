using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HomeAccounting.Models;
using System.Threading.Tasks;
using System.Net;

namespace HomeAccounting.Controllers
{
    public class IncomeController : Controller
    {
        private AccountingContext db = new AccountingContext();
        // GET: Income
        public ActionResult Index()
        {
            IEnumerable<Income> incomes = db.Incomes;
            ViewBag.Incomes = incomes;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id, Name, Amount, DateReceived")] Income income)
        {
            if (ModelState.IsValid)
            {
                db.Incomes.Add(income);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(income);
        }

        public ActionResult Delete()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            var income = db.Incomes.Find(id);
            if (income == null)
            {
                ModelState.AddModelError("id", "Об'єкт з введеним id не знайдено."); // Додати повідомлення про помилку в ModelState
                return View("Delete"); // Повернути користувача на сторінку з формою
            }

            // Видалення об'єкту з бази даних
            db.Incomes.Remove(income);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}