using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using db = CarProject.DBSEF;
using CarProject.App_Code;
using System.Web.Mvc;
using System.Net;

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
        public CategoryModel(int? id)
        {
            Category = DBS.ContentsCategories.FirstOrDefault(cc => cc.ContentsCategoryId == id);
            Category.ContentsCategory2 = DBS.ContentsCategories.FirstOrDefault(cc => cc.ContentsCategoryId == Category.ParentId);
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

        public MvcHtmlString GetCategories(UrlHelper Url, int? pid, int?[] SkippedItems, string OnDelete = "", string EditeHref = "#")
        {
            string res = "";
            foreach (var item in DBS.ContentsCategories.Where(c => c.ParentId == pid))
            {
                if (SkippedItems != null && SkippedItems.Contains(item.ContentsCategoryId))
                    continue;
                res += string.Format("<li title=\"{0}\"> <a href=\"{1}\">{2}</a> {3} {4} {5} </li>",
                    WebUtility.HtmlEncode(item.Describe),
                    Url.Action("Categories", "News", new { Id = item.ContentsCategoryId }),
                    item.Name,
                    string.Format("<a href=\"{0}/{1}\" class=\"gia-edit\"></a>", EditeHref.TrimEnd('/'), item.ContentsCategoryId),
                    string.Format("<a href=\"{0}\" onclick=\"{1}\" class=\"gia-remove\"></a>", "javascript:void", string.Format("{0}('{1}')", OnDelete, item.ContentsCategoryId)),
                    GetCategories(Url, item.ContentsCategoryId, SkippedItems, OnDelete));
            }
            if (!res.IsNullOrWhiteSpace())
                res = string.Format("<ul>{0}</ul>", res);
            return new MvcHtmlString(res);
        }

        public MvcHtmlString GetCategories(int? pid, int?[] SkippedItems, string href = "#", string onclick = "", string OnDelete = "", string EditeHref = "#")
        {
            string res = "";
            foreach (var item in DBS.ContentsCategories.Where(c => c.ParentId == pid))
            {
                if (SkippedItems != null && SkippedItems.Contains(item.ContentsCategoryId))
                    continue;
                res += string.Format("<li title=\"{0}\"> <a href=\"{1}\" onclick=\"{2}('{3}','{4}','{5}')\" >{6}</a> {7} {8} {9} </li>",
                    WebUtility.HtmlEncode(item.Describe),
                    href,
                    onclick,

                    item.ContentsCategoryId,
                    item.Name,
                    item.ParentId,

                    item.Name,
                    string.Format("<a href=\"{0}/{1}\" class=\"gia-edit\"></a>", EditeHref.TrimEnd('/'), item.ContentsCategoryId),
                    string.Format("<a href=\"{0}\" onclick=\"{1}\" class=\"gia-remove\"></a>", "javascript:void", string.Format("{0}('{1}')", OnDelete, item.ContentsCategoryId)),
                    GetCategories(item.ContentsCategoryId, SkippedItems, href, onclick, OnDelete, EditeHref));
            }
            if (!res.IsNullOrWhiteSpace())
                res = string.Format("<ul>{0}</ul>", res);
            return new MvcHtmlString(res);
        }

        public MvcHtmlString GetCategories_readOnly(int? pid, int?[] SkippedItems, string href = "#", string onclick = "")
        {
            string res = "";
            foreach (var item in DBS.ContentsCategories.Where(c => c.ParentId == pid))
            {
                if (SkippedItems != null && SkippedItems.Contains(item.ContentsCategoryId))
                    continue;
                res += string.Format("<li title=\"{0}\"> <a href=\"{1}\" onclick=\"{2}('{3}','{4}','{5}')\" >{6}</a> {7} </li>",
                   WebUtility.HtmlEncode(item.Describe),
                    href,
                    onclick,

                    item.ContentsCategoryId,
                    item.Name,
                    item.ParentId,

                    item.Name,
                    GetCategories_readOnly(item.ContentsCategoryId, SkippedItems, href, onclick));
            }
            if (!res.IsNullOrWhiteSpace())
                res = string.Format("<ul>{0}</ul>", res);
            return new MvcHtmlString(res);
        }
    }
}