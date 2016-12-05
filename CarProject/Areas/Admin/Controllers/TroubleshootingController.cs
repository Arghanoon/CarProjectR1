using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Admin.Controllers
{
    //[CLS.AuthFilter]
    public class TroubleshootingController : Controller
    {
        //
        // GET: /Admin/Troubleshooting/

        DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MakeAQuestion(int? Id)
        {
            var model = new Models.Troubleshooting.TSModel();
            model.Troubleshooting.TroubleshootinParentId = Id;
            return View(model);
        }

        [HttpPost]
        public ActionResult MakeAQuestion(Models.Troubleshooting.TSModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("DefineAnswer", new { id = model.Troubleshooting.TroubleshootingId });
            }
            return View(model);
        }

        public ActionResult DefineAnswer(int? Id)
        {
            if (DBS.Troubleshootings.Count(t => t.TroubleshootingId == Id) <= 0)
                return RedirectToAction("Index");

            var model = new Models.Troubleshooting.TSModel();
            model.ModelType = Models.Troubleshooting.TSModel.TroubleshootingType.Answer;
            model.Troubleshooting.TroubleshootinParentId = Id;
            return View(model);
        }
        [HttpPost]
        public ActionResult DefineAnswer(int? Id,Models.Troubleshooting.TSModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();

                return RedirectToAction("DefineAnswer", new { id = model.Troubleshooting.TroubleshootinParentId });
            }
            return View(model);
        }
    }
}
