using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using db = CarProject.DBSEF;
using CarProject.App_Code;

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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (Category.Name.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام گروه وارد نشده است", new string[] { "Category.Name" }));
            if (DBS.ContentsCategories.Count(cc => cc.Name == this.Category.Name && cc.ContentsCategoryId != this.Category.ContentsCategoryId) > 0)
                result.Add(new ValidationResult("نام گروه تکراری است", new string[] { "Category.Name" }));

            return result;
        }
    }
}