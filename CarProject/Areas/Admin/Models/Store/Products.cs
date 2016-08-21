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
        public int ProductPrice { get; set; }

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
            if (Product == null)
                return;

            if (Product.ProductReview != null)
                this.ReviewText = Product.ProductReview.ProductReview1;
            ProductPrice = Product.ProductPrices.LastOrDefault().ProductPrice1.GetValueOrDefault();
        }

        public void Save()
        {
            this.Product.ProductReview.ProductReview1 = ReviewText;
            Context.Products.Add(this.Product);

            Context.ProductPrices.Add(new db.ProductPrice { Product = this.Product, ProductPrice1 = this.ProductPrice, Date = DateTime.Now });

            Context.SaveChanges();
        }

        public void Update()
        {
            this.Product.ProductReview.ProductReview1 = ReviewText;

            var lp = Product.ProductPrices.LastOrDefault();
            if (lp != null && lp.ProductPrice1 != ProductPrice)
                Context.ProductPrices.Add(new db.ProductPrice { Product = this.Product, ProductPrice1 = this.ProductPrice, Date = DateTime.Now });
            
            Context.SaveChanges();
        }

        public void Delete()
        {
            if (this.Product == null)
                return;

            Context.ProductPrices.RemoveRange(Context.ProductPrices.Where(pp => pp.ProductId == this.Product.ProductId));
            Context.ProductReviews.Remove(this.Product.ProductReview);
            Context.Products.Remove(this.Product);

            Context.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();


            return res;
        }

        public bool IsNull()
        {
            return (this.Product == null);
        }
    }
}