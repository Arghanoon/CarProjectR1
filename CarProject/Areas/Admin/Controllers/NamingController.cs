using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Admin.Controllers
{
    public class NamingController : Controller
    {
        // GET: Admin/Naming

        [HttpPost]
        public ActionResult NewNaming()
        {
            var model = new Models.Dashboard.NamingModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult NewNaming(Models.Dashboard.NamingModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
            }

            return View(model);
        }
    }
}