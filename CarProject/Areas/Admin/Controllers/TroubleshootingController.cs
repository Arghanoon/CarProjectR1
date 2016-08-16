using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CarProject.Areas.Admin.Controllers
{
    public class TroubleshootingController : Controller
    {
        public ActionResult Index(int? parentID)
        {
            var xc = new DBSEF.CarAutomationEntities();
            var xtcol = xc.Troubleshootings.Where(t => t.FatherId == parentID).ToList();
            return View(xtcol);
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
                    return RedirectToAction("Index", "Troubleshooting");
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
