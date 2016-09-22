using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using db = CarProject.DBSEF;
using CarProject.App_Code;
using System.Web.Mvc;

namespace CarProject.Areas.Admin.Models.News
{
    public class CategoryModel : IValidatableObject
    {
        public db.CarAutomationEntities DBS = new db.CarAutomationEntities();
        public db.ContentsCategory Category { get; set; }

        public CategoryModel()
        {
            Category = new db.ContentsCategory();
        }

        public void Save()
        {
            DBS.ContentsCategories.Add(this.Category);
            DBS.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (Category.Name.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام گروه وارد نشده است", new string[] { "Category.Name" }));
            if (DBS.ContentsCategories.Count(cc => cc.Name == this.Category.Name && cc.ParentId == Category.ParentId && cc.ContentsCategoryId != this.Category.ContentsCategoryId) > 0)
                result.Add(new ValidationResult("نام گروه تکراری است", new string[] { "Category.Name" }));

            return result;
        }

        public MvcHtmlString GetCategories(UrlHelper Url, int? pid)
        {
            string res = "";
            foreach (var item in DBS.ContentsCategories.Where(c => c.ParentId == pid))
            {
                res += string.Format("<li> <a href=\"{0}\">{1}</a> {2} </li>",
                    Url.Action("Categories", "News", new { Id = item.ContentsCategoryId }),
                    item.Name,
                    GetCategories(Url, item.ContentsCategoryId));
            }
            if (!res.IsNullOrWhiteSpace())
                res = string.Format("<ul>{0}</ul>", res);
            return new MvcHtmlString(res);
        }
    }
}