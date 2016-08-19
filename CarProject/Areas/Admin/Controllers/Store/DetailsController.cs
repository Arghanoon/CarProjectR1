using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Controllers.Store
{
    public class DetailsController : Controller
    {
        //
        // GET: /Admin/Manufactures/

        public ActionResult Manufactures()
        {
            var model = new db.Manufacture();
            return View(model);
        }
        [HttpPost]
        public ActionResult Manufactures(db.Manufacture model, FormCollection form)
        {
            if (ViewData.ModelState.IsValid)
            {
                var dc = new db.CarAutomationEntities();
                if (form.AllKeys.Contains("NewManufacutre"))
                {
                    dc.Manufactures.Add(model);
                    dc.SaveChanges();
                }
                else if (form.AllKeys.Contains("EditManufacutre"))
                {
                    var mi = dc.Manufactures.FirstOrDefault(c => c.ManufactureId == model.ManufactureId);
                    if (mi != null)
                    {
                        TryUpdateModel(mi);
                        dc.SaveChanges();
                    }
                }

                return RedirectToAction("Manufactures");
            }
            return View(model);
        }
         
    }
}
