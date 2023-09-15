using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeAccounting.Models;

namespace HomeAccounting.Controllers
{
    public class HomeController : Controller
    {
        private AccountingContext db = new AccountingContext();
        public ActionResult Index()
        {
            return View();
        }
    }
}