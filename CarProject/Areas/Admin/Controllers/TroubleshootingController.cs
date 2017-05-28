using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Admin.Controllers
{
    [CLS.AuthFilter]
    public class TroubleshootingController : Controller
    {
        //
        // GET: /Admin/Troubleshooting/

        DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();

        public ActionResult Index(int? id)
        {
            var prnt = DBS.Troubleshootings.FirstOrDefault(t => t.TroubleshootingId == id);
            if (prnt != null && prnt.Type == 1)
                return RedirectToAction("ShowAnswer", new { id = prnt.TroubleshootingId });
            return View();
        }

        public ActionResult ShowAnswer(int? id)
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
        public ActionResult MakeAQuestion(int? Id, Models.Troubleshooting.TSModel model, int InsertType)
        {
            //if (ModelState.IsValid)
            {
                if (model.mCars != null && model.mCars.Count != 0)
                {
                    Session["PassCarId"] = model.mCars;
                } //foreach (var item in COLLECTION)
                //{
                //    model.mCars.Add();
                //}
                model.Save();
                if (InsertType == 1)
                    return RedirectToAction("MakeAQuestion", new { id = model.Troubleshooting.TroubleshootingId });
                else if(InsertType == 2)
                    return RedirectToAction("MakeAQuestion", new { id = model.Troubleshooting.TroubleshootinParentId });
                else if(InsertType == 3)
                    return RedirectToAction("DefineAnswer", new { id = model.Troubleshooting.TroubleshootingId });
            }
            return View(model);
        }

        public ActionResult UpdateQuestion(int? Id)
        {
            var model = new Models.Troubleshooting.TSModel(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateQuestion(int? Id,Models.Troubleshooting.TSModel model )
        {
            if (ModelState.IsValid)
            {
                var mdl = new Models.Troubleshooting.TSModel(Id);
                TryUpdateModel(mdl);
                mdl.Update();

                return RedirectToAction("Index", new { id = mdl.Troubleshooting.TroubleshootingId });
            }
            return View(model);
        }

        public ActionResult RemoveQuestion(int? id)
        {
            var model = new Models.Troubleshooting.TSModel(id);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }
        [HttpPost,ActionName("RemoveQuestion")]
        public ActionResult RemoveQuestionConfirm(int? id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            Models.Troubleshooting.TSModel.Delete(dbs, id.Value);
            dbs.SaveChanges();

            return RedirectToAction("Index");
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

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult UpdateAnswer(int? id)
        {
            var model = new Models.Troubleshooting.TSModel(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateAnswer(int? id,Models.Troubleshooting.TSModel model)
        {
            if (ModelState.IsValid)
            {
                var mdl = new Models.Troubleshooting.TSModel(id);
                TryUpdateModel(mdl);
                mdl.Update();

                return RedirectToAction("ShowAnswer", new { id = id });
            }
            return View(model);
        }

        public ActionResult RemoveAnswer(int? id)
        {
            var model = new Models.Troubleshooting.TSModel(id);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }
        [HttpPost, ActionName("RemoveAnswer")]
        public ActionResult RemoveAnswerConfirm(int? id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            Models.Troubleshooting.TSModel.Delete(dbs, id.Value);
            dbs.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult JsonCarsearch(string search, List<int> notinId)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            if (notinId == null) { notinId = new List<int>(); }

            var res = dbs.Cars.Where(c => c.CarModel.CarModelName.Contains(search) && !notinId.Contains(c.CarsId)).Select(c => new { id = c.CarsId, num = c.CarsId.ToString(), name = c.CarModel.CarBrand.CarBrandName, cat = c.CarModel.CarModelName }).ToList();
            return Json(res, JsonRequestBehavior.DenyGet);
        }
       
    }
}
