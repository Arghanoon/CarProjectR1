using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CarProject.Controllers;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
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
            BuyFinished = 2,
            SendToCustomer = 3,
            Delivered = 4,
            Return = 5,
            SendAgain = 6,
            Cancel = 7
        };
        public string Basket_State_ToString(byte? BasketState)
        {
            var bskst = (Basket_State)BasketState.GetValueOrDefault(00);
            string res = "";
            switch (bskst)
            {
                case Basket_State.Openned:
                    res = "در حال خرید";
                    break;
                case Basket_State.BuyFinished:
                    res = "پایان خرید";
                    break;
                case Basket_State.SendToCustomer:
                    res = "ارسال کالا برای مشتری - تحویل به پست";
                    break;
                case Basket_State.Delivered:
                    res = "تحویل کالا به مشتری";
                    break;
                case Basket_State.Return:
                    res = "بازگشت کالا";
                    break;
                case Basket_State.SendAgain:
                    res = "ارسال مجدد کالا";
                    break;
                case Basket_State.Cancel:
                    res = "انصراف";
                    break;
                default:
                    break;
            }

            return res;
        }

        public enum Basket_PaymentType
        {
            Online = 1,
            InLocation = 2
        };
        public string Basket_PaymentType_ToString(byte? PaymentType)
        {
            string res = "";

            var bpt = (Basket_PaymentType)PaymentType.Value;
            switch (bpt)
            {
                case Basket_PaymentType.Online:
                    res = "پرداخت آنلاین";
                    break;
                case Basket_PaymentType.InLocation:
                    res = "پرداخت در محل";
                    break;
                default:
                    break;
            }

            return res;
        }

        public enum BasketImte_PriceFlag
        {
            UnKnown = 0,
            Product_PricePlusInstallation = 1,
            Product_PriceOnly = 2
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
                var us = new Models.Store.CartUsefull();
                var cart = dbs.Baskets.FirstOrDefault(c => c.UserId == user.UserId && c.State == (byte)Models.Store.CartUsefull.Basket_State.Openned);

                if (basket.BasketItems != null)
                    cart.BasketItems = basket.BasketItems;
                if (basket.State != null)
                    cart.State = basket.State;
                if (basket.FinishDate != null)
                    cart.FinishDate = basket.FinishDate;
                if (basket.DelivaryDate != null)
                    cart.DelivaryDate = basket.DelivaryDate;
                if (basket.PaymentType != null)
                    cart.PaymentType = basket.PaymentType;
                if (basket.DelivaryTypeId != null)
                    cart.DelivaryTypeId = basket.DelivaryTypeId;
                if (basket.UserId != null)
                    cart.UserId = basket.UserId;
                if (basket.BankCode != null)
                    cart.BankCode = basket.BankCode;
                if (basket.LocalCode != null)
                    cart.LocalCode = basket.LocalCode;
                if (basket.DiscountId != null)
                    cart.DiscountId = basket.DiscountId;
                if (basket.ReciverAddress != null)
                    cart.ReciverAddress = basket.ReciverAddress;
                if (basket.ReciverFullname != null)
                    cart.ReciverFullname = basket.ReciverFullname;
                if (basket.ReciverMobile != null)
                    cart.ReciverMobile = basket.ReciverMobile;
                if (basket.ReciverTell != null)
                    cart.ReciverTell = basket.ReciverTell;
                if (basket.ReciverWorkplace != null)
                    cart.ReciverWorkplace = basket.ReciverWorkplace;

                if (basket.TimeOfDayId != null)
                    cart.TimeOfDayId = basket.TimeOfDayId;

                foreach (var item in basket.BasketItems)
                {
                    if (item.DiscountId != null && UserUseCode(item.DiscountId.GetValueOrDefault()))
                    {
                        item.DiscountId = null;
                        item.Discount = null;
                    }

                    DBSEF.Discount itemDiscount = null;
                    if (item.DiscountId != null)
                        itemDiscount = dbs.Discounts.FirstOrDefault(dis => dis.DiscountId == item.DiscountId);

                    item.ProductEachPrice = us.GetPriceOfCartObject(item.Id.Value, (Models.Store.CartUsefull.Basket_ItemType)item.Type.Value);
                    if (item.Type == (byte)CartUsefull.Basket_ItemType.Product && item.PriceFlag == (byte)CartUsefull.BasketImte_PriceFlag.Product_PriceOnly)
                    {
                        item.ProductEachPrice = us.GetPriceOfCartObject_int_WitoutInstallation(item.Id.Value, (Models.Store.CartUsefull.Basket_ItemType)item.Type.Value).ToString();
                    }

                    decimal discountprice = us.GetPriceOfCartObject_withDiscount(item.Id.Value, (Models.Store.CartUsefull.Basket_ItemType)item.Type.Value, itemDiscount);
                    if (item.Type == (byte)CartUsefull.Basket_ItemType.Product && item.PriceFlag == (byte)CartUsefull.BasketImte_PriceFlag.Product_PriceOnly)
                        discountprice = us.GetPriceOfCartObject_withDiscount_WintoutInstallation(item.Id.Value, (Models.Store.CartUsefull.Basket_ItemType)item.Type.Value, itemDiscount);

                    item.ProductEachPaidPrice = discountprice.ToString();
                    item.ToatoalPaidPrice = (discountprice * item.Count).ToString();
                }

                dbs.SaveChanges();

                dbs.BasketItems.RemoveRange(dbs.BasketItems.Where(c => c.BasketId == null));
                dbs.SaveChanges();
            }
            else
            {
                try
                {
                    basket.ProductsOrServicesDeliveryType = null;
                    Context.Response.Cookies["Basket"].Value = JsonConvert.SerializeObject(basket);
                    Context.Response.Cookies["Basket"].Expires = DateTime.Now.AddMonths(1);
                }
                catch { }
            }
        }

        public bool UserUseCode(int discountCode)
        {
            var user = Context.Session["guestUser"] as DBSEF.User;
            var disocuts = dbs.BasketItems.Count(bi => bi.Basket.UserId == user.UserId && bi.DiscountId == discountCode && bi.Basket.State > 1);
            return disocuts > 0;
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

        public string GetPriceOfCartObject(int id, Basket_ItemType typeofcart)
        {
            switch (typeofcart)
            {
                case Basket_ItemType.Product:
                    {
                        var x = dbs.Products.FirstOrDefault(c => c.ProductId == id);
                        if (x != null && x.ProductPrices.Count > 0)
                            return (x.ProductPrices.Last().ProductPrice1.GetValueOrDefault(0) + x.ProductPrices.Last().InstallPrice.GetValueOrDefault(0)).ToString();
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
                            return x.ProductPrices.Last().ProductPrice1.GetValueOrDefault(0) + x.ProductPrices.Last().InstallPrice.GetValueOrDefault(0);
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
        public int GetPriceOfCartObject_int_WitoutInstallation(int id, Basket_ItemType typeofcart)
        {
            switch (typeofcart)
            {
                case Basket_ItemType.Product:
                    {
                        var x = dbs.Products.FirstOrDefault(c => c.ProductId == id);
                        if (x != null && x.ProductPrices.Count > 0)
                            return x.ProductPrices.Last().ProductPrice1.GetValueOrDefault(0);
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

        public decimal GetPriceOfCartObject_withDiscount(int id, Basket_ItemType typeofcart,DBSEF.Discount discount = null)
        {
            switch (typeofcart)
            {
                case Basket_ItemType.Product:
                    {
                        decimal res = 0;
                        var x = dbs.Products.FirstOrDefault(c => c.ProductId == id);
                        if (x != null && x.ProductPrices.Count > 0)
                        {
                            var lastpric = x.ProductPrices.Last();
                            res = lastpric.InstallPrice.GetValueOrDefault(0) + lastpric.ProductPrice1.GetValueOrDefault(0);

                            if (discount != null)
                            {
                                decimal rate = 0;
                                decimal.TryParse(discount.Discount1, out rate);
                                decimal discountprice = decimal.Ceiling((res * rate) / 100);
                                res = res - discountprice;
                            }
                        }

                        return res;
                    }
                case Basket_ItemType.AutoService:
                    {
                        decimal res = 0;
                        var x = dbs.AutoServices.FirstOrDefault(c => c.AutoServiceId == id);
                        if (x != null && Convert.ToInt32(x.Price) > 0)
                        {
                            var lastpric = Convert.ToInt32(x.Price);
                            res = lastpric;

                            if (discount != null)
                            {
                                decimal rate = 0;
                                decimal.TryParse(discount.Discount1, out rate);
                                decimal discountprice = decimal.Ceiling((res * rate) / 100);
                                res = res - discountprice;
                            }
                        }

                        return res;
                        //if (x != null)
                        //{
                        //    int r = 0;
                        //    int.TryParse(x.Price, out r);
                        //    return r;
                        //}
                        //else
                        //    return 0;
                    }
                case Basket_ItemType.AutoServicePack:
                    {
                        decimal res = 0;
                        var x = dbs.AutoServicePacks.FirstOrDefault(c => c.AutoServicePackId == id);
                        if (x != null)
                        {
                            res = Convert.ToDecimal(x.PackPrice);

                            if (discount != null)
                            {
                                decimal rate = 0;
                                decimal.TryParse(discount.Discount1, out rate);
                                decimal discountprice = decimal.Ceiling((res * rate) / 100);
                                res = res - discountprice;
                            }
                        }

                        return res;
                        
                    }
                default:
                    return 0;
            }
        }
        public decimal GetPriceOfCartObject_withDiscount_WintoutInstallation(int id, Basket_ItemType typeofcart, DBSEF.Discount discount = null)
        {
            switch (typeofcart)
            {
                case Basket_ItemType.Product:
                    {
                        decimal res = 0;
                        var x = dbs.Products.FirstOrDefault(c => c.ProductId == id);
                        if (x != null && x.ProductPrices.Count > 0)
                        {
                            var lastpric = x.ProductPrices.Last();
                            res = lastpric.ProductPrice1.GetValueOrDefault(0);

                            if (discount != null)
                            {
                                decimal rate = 0;
                                decimal.TryParse(discount.Discount1, out rate);
                                decimal discountprice = decimal.Ceiling((res * rate) / 100);
                                res = res - discountprice;
                            }
                        }

                        return res;
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

        
    }

    public static class CartUsefullStatics
    {
        public static string Basket_State_ToString(this CartUsefull.Basket_State value)
        {
            var ctusf = new CartUsefull();
            return ctusf.Basket_State_ToString((byte)value);
        }
    }
   
}