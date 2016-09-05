using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CarProject.Areas.Admin.Controllers
{
    [CarProject.CLS.AuthFilter]
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
                tobj.Save();
                    
                if (form.AllKeys.Contains("saveOnly"))
                {
                   return RedirectToAction("Index", "Troubleshooting");
                }
                else if (form.AllKeys.Contains("saveAndContinueThisAsRoot"))
                {
                    return RedirectToAction("New", "Troubleshooting", new { id = tobj.Troubleshooting.TroubleshootingId });
                }
                else if (form.AllKeys.Contains("saveAndContinueToThisRoot"))
                {
                    return RedirectToAction("New", "Troubleshooting", new { id = tobj.Troubleshooting.FatherId });
                }
            }

            return View(tobj);
        }

        public ActionResult Update(int? id)
        {
            var tob = new Models.Cars.TroubleshootingClass(id);
            Session["troubleUpdate"] = tob;

            return View(tob);
        }

        [HttpPost]
        public ActionResult Update(Models.Cars.TroubleshootingClass tob)
        {
            if (ViewData.ModelState.IsValid)
            {
                var stob = Session["troubleUpdate"] as Models.Cars.TroubleshootingClass;
                this.TryUpdateModel(stob);
                stob.Update();
                return RedirectToAction("Index");
            }
            return View(tob);
        }

        public ActionResult DeleteTrouble(FormCollection form)
        {
            int id = -1;
            int.TryParse(form["id"], out id);
            if (id > 0)
            {
                var dc = new DBSEF.CarAutomationEntities();

                if (form.AllKeys.Contains("RemoveAll"))
                {
                    DeleteTroubleBranche(id, dc);
                }
                else if (form.AllKeys.Contains("RemoveItem"))
                {
                    var dit = dc.Troubleshootings.FirstOrDefault(t => t.TroubleshootingId == id);

                    if (dit != null)
                    {
                        var fid = dit.FatherId;
                        dc.Troubleshootings.Remove(dit);
                        var l = dc.Troubleshootings.Where(t => t.FatherId == id);
                        foreach (var item in l)
                        {
                            item.FatherId = fid;
                        }
                    }
                }
                dc.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll(int id)
        {
            var dc = new DBSEF.CarAutomationEntities();
            DeleteTroubleBranche(id, dc);
            dc.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult DeleteItem(int id)
        {
            var dc = new DBSEF.CarAutomationEntities();
            var dit = dc.Troubleshootings.FirstOrDefault(t => t.TroubleshootingId == id);

            if (dit != null)
            {
                var fid = dit.FatherId;
                dc.Troubleshootings.Remove(dit);
                var l = dc.Troubleshootings.Where(t => t.FatherId == id);
                foreach (var item in l)
                {
                    item.FatherId = fid;
                }

                dc.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        void DeleteTroubleBranche(int id, DBSEF.CarAutomationEntities con)
        {
            var xt = con.Troubleshootings.FirstOrDefault(t => t.TroubleshootingId == id);
            foreach (var item in con.Troubleshootings.Where(t => t.FatherId == id))
            {
                DeleteTroubleBranche(item.TroubleshootingId, con);
            }
            con.Troubleshootings.Remove(xt);
        }
    }
}
