using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarProject.App_extension;

namespace CarProject.Areas.Admin.Models.Store
{
    public class ProductsModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public DBSEF.Product Product { get; set; }
        public int? Price { get; set; }
        [AllowHtml]
        public string HtmlReview { get { return Product.ProductReview.ProductReview1; } set { Product.ProductReview.ProductReview1 = value; } }

        public ProductsModel()
        {
            Product = new DBSEF.Product();
            Product.ProductReview = new DBSEF.ProductReview();
        }

        public ProductsModel(int? id)
        {
            Product = dbs.Products.FirstOrDefault(p => p.ProductId == id);

            if (Product != null && Product.ProductPrices.Count > 0)
                Price = Product.ProductPrices.Last().ProductPrice1;
        }


        public void Save()
        {
            dbs.Products.Add(this.Product);
            dbs.ProductPrices.Add(new DBSEF.ProductPrice { Product = this.Product, ProductPrice1 = Price });
            dbs.SaveChanges();
        }

        public void Save_review()
        {
            dbs.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (Product.ProductName.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام محصول وارد نشده است", new string[] { "Product.ProductName" }));
            if (Product.CategoryId == null)
                result.Add(new ValidationResult("گروه تعیین نشده است", new string[] { "Product.CategoryId" }));
            return result;
        }
    }
}