using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        }

        public void Save()
        {
            DBS.Categories.Add(this.Category);
            DBS.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            return result;
        }
    }
}