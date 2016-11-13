using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CarProject.Controllers;

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
}