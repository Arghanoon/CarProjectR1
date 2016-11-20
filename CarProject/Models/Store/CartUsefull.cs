using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CarProject.Controllers;
using System.ComponentModel.DataAnnotations;
using CarProject.App_extension;
using Newtonsoft.Json;

namespace CarProject.Models.Store
{
    public class CartUsefull
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();
        HttpContext Context { get; set; }

        public CartUsefull()
        {
            Context = HttpContext.Current;
        }


        public enum Basket_ItemType
        {
            Product = 1,
            AutoService = 2,
            AutoServicePack = 3
        };

        public enum Basket_State
        {
            Openned = 1,
            Finished = 2,
            Delivered = 3
        };

        public enum Basket_PaymentType
        {
            Online = 1,
            InLocation = 2
        };


        public DBSEF.Basket GetCurrentBasket()
        {
            var res = new DBSEF.Basket();
            if (Context.Session["guestUser"] != null && Context.Session["guestUser"] is DBSEF.User)
            {
                var user = Context.Session["guestUser"] as DBSEF.User;
                var cart = dbs.Baskets.FirstOrDefault(c => c.UserId == user.UserId && c.State == (byte)Models.Store.CartUsefull.Basket_State.Openned);
                if (cart == null)
                {
                    cart = new DBSEF.Basket { UserId = user.UserId, State = (byte)Models.Store.CartUsefull.Basket_State.Openned };
                    dbs.Baskets.Add(cart);
                    dbs.SaveChanges();
                }
                res = cart;
            }
            else
            {
                if (Context.Request.Cookies["Basket"] != null && !Context.Request.Cookies["Basket"].Value.IsNullOrWhiteSpace())
                {
                    res = JsonConvert.DeserializeObject<DBSEF.Basket>(Context.Request.Cookies["Basket"].Value);
                    if (res == null)
                        res = new DBSEF.Basket();
                }
            }

            return res;
        }

        public void UpdateBasket(DBSEF.Basket basket)
        {
            if (Context.Session["guestUser"] != null && Context.Session["guestUser"] is DBSEF.User)
            {
                var user = Context.Session["guestUser"] as DBSEF.User;                
                var cart = dbs.Baskets.FirstOrDefault(c => c.UserId == user.UserId && c.State == (byte)Models.Store.CartUsefull.Basket_State.Openned);
                cart = basket;
                dbs.SaveChanges();

                dbs.BasketItems.RemoveRange(dbs.BasketItems.Where(c => c.BasketId == null));
                dbs.SaveChanges();
            }
            else
            {
                try
                {
                    Context.Response.Cookies["Basket"].Value = JsonConvert.SerializeObject(basket);
                    Context.Response.Cookies["Basket"].Expires = DateTime.Now.AddMonths(1);
                }
                catch { }
            }
        }


        public string GetNameOfCartObject(int id, Basket_ItemType typeofcart)
        {
            switch (typeofcart)
            {
                case Basket_ItemType.Product:
                    {
                        var x = dbs.Products.FirstOrDefault(c => c.ProductId == id);
                        if (x != null)
                            return x.ProductName;
                        else
                            return "";
                    }
                case Basket_ItemType.AutoService:
                    {
                        var x = dbs.AutoServices.FirstOrDefault(c => c.AutoServiceId == id);
                        if (x != null)
                            return x.AutoServiceName;
                        else
                            return "";
                    }
                case Basket_ItemType.AutoServicePack:
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
        public string GetPriceOfCartObject(int id, Basket_ItemType typeofcart)
        {
            switch (typeofcart)
            {
                case Basket_ItemType.Product:
                    {
                        var x = dbs.Products.FirstOrDefault(c => c.ProductId == id);
                        if (x != null && x.ProductPrices.Count > 0)
                            return x.ProductPrices.Last().ProductPrice1.Value.ToString();
                        else
                            return "";
                    }
                case Basket_ItemType.AutoService:
                    {
                        var x = dbs.AutoServices.FirstOrDefault(c => c.AutoServiceId == id);
                        if (x != null)
                            return x.Price;
                        else
                            return "";
                    }
                case Basket_ItemType.AutoServicePack:
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
        public int GetPriceOfCartObject_int(int id, Basket_ItemType typeofcart)
        {
            switch (typeofcart)
            {
                case Basket_ItemType.Product:
                    {
                        var x = dbs.Products.FirstOrDefault(c => c.ProductId == id);
                        if (x != null && x.ProductPrices.Count > 0)
                            return x.ProductPrices.Last().ProductPrice1.Value;
                        else
                            return 0;
                    }
                case Basket_ItemType.AutoService:
                    {
                        var x = dbs.AutoServices.FirstOrDefault(c => c.AutoServiceId == id);
                        if (x != null)
                        {
                            int r = 0;
                            int.TryParse(x.Price, out r);
                            return r;
                        }
                        else
                            return 0;
                    }
                case Basket_ItemType.AutoServicePack:
                    {
                        var x = dbs.AutoServicePacks.FirstOrDefault(c => c.AutoServicePackId == id);
                        if (x != null)
                        {
                            int r = 0;
                            int.TryParse(x.PackPrice, out r);
                            return r;
                        }
                        else
                            return 0;
                    }
                default:
                    return 0;
            }
        }
        public string GetNameofCartType(Basket_ItemType ct)
        {
            switch (ct)
            {
                case Basket_ItemType.Product:
                    return "محصولات";
                case Basket_ItemType.AutoService:
                    return "سرویس ها";
                case Basket_ItemType.AutoServicePack:
                    return "سرویس پک ها";
                default:
                    return "";
            }
        }


        
    }

   
}