using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Areas.Admin.Controllers.Store
{
    [CarProject.CLS.AuthFilter]
    public class CategoriesController : Controller
    {
        //
        // GET: /Admin/Categories/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (form.AllKeys.Contains("InsertNode"))
            {
                return RedirectToAction("New", new { id = form["SelectedID"] });
            }
            else if (form.AllKeys.Contains("updateItem"))
            {
                return RedirectToAction("Update", new { id = form["SelectedID"] });
            }
            return View();
        }

        public ActionResult New(int? id)
        {
            Models.Store.Categories model = new Models.Store.Categories();
            if (id != null && id > 0)
                model.CateGory.ParentCategoryId = id;

            return View(model);
        }
        [HttpPost]
        public ActionResult New(Models.Store.Categories model,FormCollection form)
        {
            if (ViewData.ModelState.IsValid)
            {
                if (form.AllKeys.Contains("saveAndFinish"))
                {
                    model.Save();
                    return RedirectToAction("Index");
                }
                if (form.AllKeys.Contains("saveAndAddAgainToThisfather"))
                {
                    model.Save();
                    return RedirectToAction("New", "Categories", new { id = model.CateGory.ParentCategoryId });
                }
                if (form.AllKeys.Contains("saveAndAddAgainThisWillBefather"))
                {
                    model.Save();
                    return RedirectToAction("New", "Categories", new { id = model.CateGory.CategoryId });
                }
            }
            return View(model);
        }


        public ActionResult Update(int? id)
        {
            var model = new Models.Store.Categories(id);
            Session["categoryUpdate"] = model;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Models.Store.Categories model)
        {
            if (ViewData.ModelState.IsValid)
            {
                var x = Session["categoryUpdate"] as Models.Store.Categories;
                TryUpdateModel(x);

                x.Update();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        
        public ActionResult Delete(int? id,FormCollection form)
        {
            if (id != null && id > 0)
            {
                var dc = new DBSEF.CarAutomationEntities();
                var ritem = dc.Categories.FirstOrDefault(c => c.CategoryId == id);

                if (form.AllKeys.Contains("RemoveItem"))
                {
                    foreach (var item in dc.Categories.Where(c => c.ParentCategoryId == id))
                    {
                        item.ParentCategoryId = ritem.ParentCategoryId;
                    }
                }
                else if (form.AllKeys.Contains("RemoveAll"))
                {
                    DeleteAll(id, dc);
                }

                dc.Categories.Remove(ritem);
                dc.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        void DeleteAll(int? id, DBSEF.CarAutomationEntities dc)
        {
            foreach (var item in dc.Categories.Where(c => c.ParentCategoryId == id))
            {
                DeleteAll(item.CategoryId, dc);
                dc.Categories.Remove(item);
            }
        }
    }

    public class CategoriesTools
    {
        public MvcHtmlString CreateTreeView(int? parentID, DBSEF.CarAutomationEntities dc, string JSfunnection = "")
        {
            string res = "";

            res += "<ul>";
            foreach (var item in dc.Categories.Where(c => c.ParentCategoryId == parentID))
            {
                res += "<li>";

                res += string.Format("<section  onClick=\"{0}\" data-id=\"{1}\" data-name=\"{2}\" data-description=\"{3}\"  class=\"gia-information information\"></section>", JSfunnection, item.CategoryId, item.CategoryName, item.Description);
                
                if (dc.Categories.Count(c => c.ParentCategoryId == item.CategoryId) > 0)
                {
                    res += string.Format("<a href=\"javascript: void();\" >{0}</a>", item.CategoryName);
                    res += CreateTreeView(item.CategoryId, dc, JSfunnection).ToString();
                }
                else
                {
                    res += string.Format("<section>{0}</section>", item.CategoryName);
                }

                res += "</li>";
            }
            res += "</ul>";


            return new MvcHtmlString(res);
        }
    }
}
