using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CarProject.App_extension;

namespace CarProject.Areas.Admin.Models.Store
{
    public class AutoServiceCategoryyModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();
        public DBSEF.ServicesCategory ServicesCategory { get; set; }

        public AutoServiceCategoryyModel()
        {
            ServicesCategory = new DBSEF.ServicesCategory();
        }
        public AutoServiceCategoryyModel(int? id)
        {
            ServicesCategory = DBS.ServicesCategories.FirstOrDefault(c => c.ServicesCategoryId == id);
            if (ServicesCategory == null)
                ServicesCategory = new DBSEF.ServicesCategory();
        }

        public void Save()
        {
            DBS.ServicesCategories.Add(this.ServicesCategory);
            DBS.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (ServicesCategory.ServicesCategoryName.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام گروه وارد نشده است", new string[] { "Category.CategoryName" }));
            if (DBS.Categories.Count(c => c.CategoryName == this.ServicesCategory.ServicesCategoryName && c.ParentCategoryId == this.ServicesCategory.ServicesParentCategoryId && c.CategoryId != this.ServicesCategory.ServicesCategoryId) > 0)
                result.Add(new ValidationResult("نام گروه وارد شده تکراری است", new string[] { "Category.CategoryName" }));

            return result;
        }
    }
}