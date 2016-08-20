using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using db = CarProject.DBSEF;
using System.Web.Mvc;

namespace CarProject.Areas.Admin.Models.Store
{
    public class Products : IValidatableObject
    {

        db.CarAutomationEntities _context = new db.CarAutomationEntities();
        public db.CarAutomationEntities Context { get { return _context; } }

        public db.Product Product { get; set; }
        public db.ProductPrice ProductPrice { get; set; }

        [AllowHtml]
        public string ReviewText { get; set; }

        public Products()
        {
            Product = new db.Product();
            Product.ProductReview = new db.ProductReview();
        }

        public Products(int? id)
        {
            Product = Context.Products.FirstOrDefault(p => p.ProductId == id);
            ProductPrice = Product.ProductPrices.LastOrDefault();
        }

        public void Save()
        {
            Context.Products.Add(this.Product);

            this.ProductPrice.Product = this.Product;
            this.Product.ProductReview.ProductReview1 = ReviewText;
            Context.ProductPrices.Add(ProductPrice);

            Context.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();


            return res;
        }
    }
}