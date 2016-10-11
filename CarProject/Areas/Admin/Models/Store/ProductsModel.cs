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
        public List<DBSEF.ProductCar> Cars { get; set; }

        public int? Price { get; set; }
        [AllowHtml]
        public string HtmlReview { get { return Product.ProductReview.ProductReview1; } set { Product.ProductReview.ProductReview1 = value; } }

        public ProductsModel()
        {
            Product = new DBSEF.Product();
            Product.ProductReview = new DBSEF.ProductReview();
            Cars = new List<DBSEF.ProductCar>();
        }

        public ProductsModel(int? id)
        {
            Product = dbs.Products.FirstOrDefault(p => p.ProductId == id);

            if (Product != null && Product.ProductPrices.Count > 0)
                Price = Product.ProductPrices.Last().ProductPrice1;
            Cars = dbs.ProductCars.Where(pc => pc.ProductId == this.Product.ProductId).ToList();
        }


        public void Save()
        {
            foreach (var item in Cars)
            {
                Product.ProductCars.Add(item);
            }
            dbs.Products.Add(this.Product);
            //foreach (var item in Cars)
            //{
            //    item.Product = this.Product;
            //    dbs.ProductCars.Add(item);
            //}
            dbs.ProductPrices.Add(new DBSEF.ProductPrice { Product = this.Product, ProductPrice1 = Price });
            
            dbs.SaveChanges();
        }

        public void Save_review()
        {
            dbs.SaveChanges();
        }

        public void Update()
        {
            var lp = Product.ProductPrices.Last();
            if(lp == null || lp.ProductPrice1 != Price)
                dbs.ProductPrices.Add(new DBSEF.ProductPrice { Product = this.Product, ProductPrice1 = Price });

            var xtmp = Cars.Select(c => c.CarsId);
            dbs.ProductCars.RemoveRange(Product.ProductCars.Where(c => !xtmp.Contains(c.CarsId)));
            foreach (var item in Cars)
            {
                if (Product.ProductCars.Count(c => c.CarsId == item.CarsId) <= 0)
                    Product.ProductCars.Add(item);
            }

            dbs.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (Product.ProductName.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام محصول وارد نشده است", new string[] { "Product.ProductName" }));
            if (Product.CategoryId == null)
                result.Add(new ValidationResult("گروه تعیین نشده است", new string[] { "Product.CategoryId" }));
            if (Price == null || Price <= 0)
                result.Add(new ValidationResult("قیمت وارد نشده است", new string[] { "Price" }));
            return result;
        }
    }
}