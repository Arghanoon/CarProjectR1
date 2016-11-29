using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CarProject.App_extension;

namespace CarProject.Areas.Admin.Models.Store
{
    public class ProductDiscountModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public DBSEF.Discount Discount { get; set; }
        public List<int> Products { get; set; }

        public ProductDiscountModel()
        {
            Discount = new DBSEF.Discount();
            Products = new List<int>();
        }

        public ProductDiscountModel(int? DiscountId)
        {
            Discount = dbs.Discounts.FirstOrDefault(c => c.DiscountId == DiscountId);
            Products = dbs.ProductDiscounts.Where(pd => pd.DiscountId == DiscountId).Select(pd => pd.ProductId.Value).ToList();
            if (Products == null)
                Products = new List<int>();
        }

        public void Save()
        {
            dbs.Discounts.Add(this.Discount);

            foreach (var item in Products)
            {
                var pr = dbs.Products.FirstOrDefault(p => p.ProductId == item);
                if (pr != null)
                    dbs.ProductDiscounts.Add(new DBSEF.ProductDiscount { Product = pr, Discount = this.Discount });
            }

            dbs.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var res = new List<ValidationResult>();
            if (Discount.DiscountCode.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("کد تخفیف وارد نشد است", new string[] { "Discount.DiscountCode" }));
            if (Discount.Discount1.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("درصد تخفیف وارد نشده است", new string[] { "Discount.Discount1" }));
            else if (!Discount.Discount1.IsFloat())
                res.Add(new ValidationResult("مقدار وارد شده صحیح نیست", new string[] { "Discount.Discount1" }));
            //if (Products.Count == 0)
            //    res.Add(new ValidationResult("محصولات شامل تخفیف تعیین نشده اند", new string[] { "Products" }));
            return res;
        }
    }
}