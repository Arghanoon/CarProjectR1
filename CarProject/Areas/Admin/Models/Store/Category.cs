using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CarProject.App_extension;

namespace CarProject.Areas.Admin.Models.Store
{
    public class CategoryModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();
        public DBSEF.Category Category { get; set; }

        public CategoryModel()
        {
            Category = new DBSEF.Category();
        }
        public CategoryModel(int? id)
        {
            Category = DBS.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (Category == null)
                Category = new DBSEF.Category();
        }

        public void Save()
        {
            DBS.Categories.Add(this.Category);
            DBS.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (Category.CategoryName.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام گروه وارد نشده است", new string[] { "Category.CategoryName" }));
            if(DBS.Categories.Count(c => c.CategoryName == this.Category.CategoryName && c.ParentCategoryId == this.Category.ParentCategoryId && c.CategoryId != this.Category.CategoryId) > 0)
                result.Add(new ValidationResult("نام گروه وارد شده تکراری است", new string[] { "Category.CategoryName" }));

            return result;
        }
    }
}