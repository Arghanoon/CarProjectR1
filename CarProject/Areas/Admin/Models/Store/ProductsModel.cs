using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarProject.Areas.Admin.Models.Store
{
    public class ProductsModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public DBSEF.Product Product { get; set; }

        public ProductsModel()
        {
            Product = new DBSEF.Product();
        }

        public ProductsModel(int? id)
        {
            Product = dbs.Products.FirstOrDefault(p => p.ProductId == id);
            if (Product == null)
                Product = new DBSEF.Product();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            return result;
        }
    }
}