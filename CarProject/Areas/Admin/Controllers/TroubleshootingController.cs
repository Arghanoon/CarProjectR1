using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarProject.App_extension;
using CarProject.Areas.Admin.Models;
using CarProject.CLS;


namespace CarProject.Areas.Admin.Controllers
{
    [CarProject.CLS.AuthFilter]
    public class TroubleshootingController : Controller
    {
        public ActionResult Index(int? parentID)
        {
            var xc = new DBSEF.CarAutomationEntities();
            var xtcol = xc.Troubleshootings.Where(t => t.FatherId == parentID + 1).ToList();
            if (parentID != null)
            {
                xtcol.AddRange(xc.Troubleshootings.Where(t => t.FatherId == parentID + 2).ToList());
            }
            return View(xtcol);
        }
        // GET: Admin/Troubleshooting
        public ActionResult New(int? id)
        {
            var tob = new Models.TroubleshootingClass();
            if (id != null && id > 0)
            {
                DBSEF.CarAutomationEntities c = new DBSEF.CarAutomationEntities();
                tob.Troubleshooting.FatherId = c.Troubleshootings.FirstOrDefault(t => t.TroubleshootingId == id).TroubleshootingId;
            }
            return View(tob);
        }
        [HttpPost]
        public ActionResult New(TroubleshootingClass tobj, TroubleshootingClass tobj1, TroubleshootingClass tobj2, FormCollection form)
        {
            int id = 0;
            if (ViewData.ModelState.IsValid)
            {
                if (!tobj.Troubleshooting.QQuestion.IsNullOrWhiteSpace())
                {
                    if (tobj.Troubleshooting.FatherId.HasValue)
                    {
                        tobj.Troubleshooting.HasFather = true;
                    }
                    else
                    {
                        tobj.Troubleshooting.HasFather = false;

                    }
                    tobj.trb.Answer = tobj.Troubleshooting.QQuestion;
                    tobj.Troubleshooting.QQuestion = null;
                    tobj.Save();
                }
                if (!tobj.Troubleshooting.AnswerYes.IsNullOrWhiteSpace())
                {
                    tobj1.trb.FatherId = tobj.trb.TroubleshootingId;
                    tobj1.trb.HasFather = false;
                    tobj1.trb.Answer = tobj.Troubleshooting.AnswerYes;
                    tobj1.Troubleshooting.AnswerYes = null;

                    tobj1.Save();



                }
                if (!tobj.Troubleshooting.AnswerNo.IsNullOrWhiteSpace())
                {
                    tobj2.trb.FatherId = tobj.trb.TroubleshootingId;
                    tobj2.trb.HasFather = false;
                    tobj2.trb.Answer = tobj.Troubleshooting.AnswerNo;
                    tobj2.Troubleshooting.AnswerNo = null;

                    tobj2.Save();
                }


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
    }
}