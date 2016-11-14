using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CarProject.Controllers;
using System.ComponentModel.DataAnnotations;

namespace CarProject.Models.Store
{
    public class CartUsefull
    {
        DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public string GetNameOfCartObject(int id, CartOfProducts.CartType typeofcart)
        {
            switch (typeofcart)
            {
                case CartOfProducts.CartType.Product:
                    {
                        var x = dbs.Products.FirstOrDefault(c => c.ProductId == id);
                        if (x != null)
                            return x.ProductName;
                        else
                            return "";
                    }
                case CartOfProducts.CartType.AutoService:
                    {
                        var x = dbs.AutoServices.FirstOrDefault(c => c.AutoServiceId == id);
                        if (x != null)
                            return x.AutoServiceName;
                        else
                            return "";
                    }
                case CartOfProducts.CartType.AutoServicePack:
                    {
                        var x = dbs.AutoServicePacks.FirstOrDefault(c => c.AutoServicePackId == id);
                        if (x != null)
                            return x.AutoServicePackName;
                        else
                            return "";
                    }
                default:
                    return "";
            }
        }
        public string GetPriceOfCartObject(int id, CartOfProducts.CartType typeofcart)
        {
            switch (typeofcart)
            {
                case CartOfProducts.CartType.Product:
                    {
                        var x = dbs.Products.FirstOrDefault(c => c.ProductId == id);
                        if (x != null)
                            return x.ProductPrices.Last().ProductPrice1.Value.ToString();
                        else
                            return "";
                    }
                case CartOfProducts.CartType.AutoService:
                    {
                        var x = dbs.AutoServices.FirstOrDefault(c => c.AutoServiceId == id);
                        if (x != null)
                            return x.Price;
                        else
                            return "";
                    }
                case CartOfProducts.CartType.AutoServicePack:
                    {
                        var x = dbs.AutoServicePacks.FirstOrDefault(c => c.AutoServicePackId == id);
                        if (x != null)
                            return x.PackPrice;
                        else
                            return "";
                    }
                default:
                    return "";
            }
        }

        public string GetNameofCartType(CartOfProducts.CartType ct)
        {
            switch (ct)
            {
                case CartOfProducts.CartType.Product:
                    return "محصولات";
                case CartOfProducts.CartType.AutoService:
                    return "سرویس ها";
                case CartOfProducts.CartType.AutoServicePack:
                    return "سرویس پک ها";
                default:
                    return "";
            }
        }
    }

    public class CartConfirmBillAndAddressModel : IValidatableObject
    {
        DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public string FullAddress { get; set; }
        public List<Controllers.CartOfProducts> BillingList { get; set; }

        public CartConfirmBillAndAddressModel(DBSEF.User user)
        {
            var prs = dbs.People.FirstOrDefault(c => c.UserId == user.UserId);
            if (prs != null)
                FullAddress = prs.PersonAddress;

            BillingList = new List<CartOfProducts>();

            var lsofbsk = dbs.ToBaskets.Where(c => c.UserId == user.UserId);
            foreach (var item in lsofbsk)
            {
                CartOfProducts crt = new CartOfProducts();
                if (item.ProductId != null)
                {
                    crt.TypeOfProduct = CartOfProducts.CartType.Product;
                    crt.Id = item.ProductId.Value;
                    crt.Count = item.ProductEntity.Value;
                }
                else if (item.AutoServiceId != null)
                {
                    crt.TypeOfProduct = CartOfProducts.CartType.Product;
                    crt.Id = item.AutoServiceId.Value;
                    crt.Count = item.ProductEntity.Value;
                }
                else if (item.AutoServicePackId != null)
                {
                    crt.TypeOfProduct = CartOfProducts.CartType.Product;
                    crt.Id = item.AutoServicePackId.Value;
                    crt.Count = item.ProductEntity.Value;
                }
                BillingList.Add(crt);
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();

            return res;
        }
    }
}