using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CarProject.Areas.Admin.Controllers
{
    public class TroubleshootingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New(int? id)
        {
            var tob = new Models.Cars.TroubleshootingClass();
            if (id != null && id > 0)
            {
                DBSEF.CarAutomationEntities c = new DBSEF.CarAutomationEntities();
                tob.Troubleshooting.FatherId = c.Troubleshootings.FirstOrDefault(t => t.TroubleshootingId == id).TroubleshootingId;
            }
            return View(tob);
        }
        [HttpPost]
        public ActionResult New(Models.Cars.TroubleshootingClass tobj, FormCollection form)
        {
            if (ViewData.ModelState.IsValid)
            {
                if (form.AllKeys.Contains("saveOnly"))
                {
                    tobj.Save();
                    return RedirectToAction("Index", "Dashboard");
                }
                else if (form.AllKeys.Contains("saveAndContinue"))
                {
                    tobj.Save();

                    return RedirectToAction("New", "Troubleshooting", new { id = tobj.Troubleshooting.TroubleshootingId });
                }
            }

            return View(tobj);
        }
    }
}
