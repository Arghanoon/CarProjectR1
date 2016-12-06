using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Controllers
{
    public class TroubleshootingController : Controller
    {
        //
        // GET: /Troubleshooting/

        public ActionResult Index(int? id)
        {
            return View();
        }

    }
}
