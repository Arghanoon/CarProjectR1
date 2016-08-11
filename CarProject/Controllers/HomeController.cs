using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            DBSEF.CarAutomationEntities ca = new DBSEF.CarAutomationEntities();
            if (!ca.Database.Exists())
            {
                ca.Database.CreateIfNotExists();
                DBSEF.Person p = new DBSEF.Person();
                p.PersonFirtstName = "Administrator";
                p.PersonLastName = "Administrator";
                p.User = new DBSEF.User { Uname = "Admin", Upass = CarProject.Areas.Admin.CLS.Usefulls.MD5Passwords("admin") };

                ca.People.Add(p);
                ca.SaveChanges();
            }
            return View();
        }

    }
}
