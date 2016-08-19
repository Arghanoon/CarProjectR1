using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using db = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Models.Store
{
    public class Products : IValidatableObject
    {

        db.CarAutomationEntities _context = new db.CarAutomationEntities();
        public db.CarAutomationEntities Context { get { return _context; } }

        public db.Product Product { get; set; }
        public db.ProductPrice ProductPrice { get; set; }
        public db.ProductReview ProductReview { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();


            return res;
        }
    }
}