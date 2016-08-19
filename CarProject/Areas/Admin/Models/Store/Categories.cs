using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using db = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Models.Store
{
    public class Categories : IValidatableObject
    {
        db.CarAutomationEntities dbc = new db.CarAutomationEntities();
        public db.Category CateGory { get; set; }

        public Categories()
        {
            this.CateGory = new db.Category();
        }

        public void Save()
        {
            dbc.Categories.Add(this.CateGory);
            dbc.SaveChanges();
        }
        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(CateGory.CategoryName))
                yield return new ValidationResult("نام دسته بندی وارد نشده است.", new string[] { "CateGory.CategoryName" });
        }
    }
}