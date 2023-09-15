using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HomeAccounting.Models;
using System.Data.Entity;

namespace HomeAccounting
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new IncomeDBInitializer());
            Database.SetInitializer(new ExpenseDBInitializer());
        }
    }
}
