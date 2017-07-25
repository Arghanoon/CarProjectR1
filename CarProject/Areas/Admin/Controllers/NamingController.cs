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

        public ActionResult NewNaming()
        {
            var model = new Models.Dashboard.NamingModel();
            return View(model);
        }
        
        public ActionResult NewNaming(Models.Dashboard.NamingModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
            }

            return View(model);
        }
        
        public ActionResult UpdateNaming(int? Id)
        {
            var model = new Models.Dashboard.NamingModel(Id);
            Session["NamingUpdate"] = model;
            return View(model);
        }
    }
}