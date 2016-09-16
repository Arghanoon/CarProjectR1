using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Controllers
{
    public class CarsController : Controller
    {
        //
        // GET: /Cars/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Car(int id)
        {
            
            return View();
        }

        public class tst
        {
            public string username { get; set; }
            public string fullname { get; set; }
        }
        public class tstcol : System.Collections.ObjectModel.ObservableCollection<tst>
        {
            public tstcol()
            {
                for (int i = 0; i < 100; i++)
                {
                    this.Add(new tst { username = "Username" + i.ToString(), fullname = "Fullname " + i.ToString() });
                }
            }
        }
    }
}
