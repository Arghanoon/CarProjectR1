﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

using CarProject.App_extension;
using CarProject.Models.Store;

namespace CarProject.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult integratedSearch()
        {
            return View();
        }
        
        #region Cart
        public void AddToCart(int id, Models.Store.CartUsefull.Basket_ItemType type)
        {
            
            if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                var user = Session["guestUser"] as DBSEF.User;
                var cart = dbs.Baskets.FirstOrDefault(c => c.UserId == user.UserId && c.State == (byte)Models.Store.CartUsefull.Basket_State.Openned);
                if (cart == null)
                {
                    cart = new DBSEF.Basket { UserId = user.UserId, State = (byte)Models.Store.CartUsefull.Basket_State.Openned };
                    dbs.Baskets.Add(cart);
                }

                if (cart.BasketItems.Count(c => c.Id == id && c.Type == (byte)type) <= 0)
                    cart.BasketItems.Add(new DBSEF.BasketItem { Id = id, Type = (byte)type, Count = 1 });
                dbs.SaveChanges();
            }
            else
            {
                var cart = new DBSEF.Basket();
                if (Request.Cookies["Basket"] != null && !Request.Cookies["Basket"].Value.IsNullOrWhiteSpace())
                {
                    cart = JsonConvert.DeserializeObject<DBSEF.Basket>(Request.Cookies["Basket"].Value);
                    if (cart == null)
                        cart = new DBSEF.Basket();
                }

                if (cart.BasketItems.Count(c => c.Id == id && c.Type == (byte)type) <= 0)
                    cart.BasketItems.Add(new DBSEF.BasketItem { Id = id, Type = (byte)type, Count = 1 });
                Response.Cookies["Basket"].Value = JsonConvert.SerializeObject(cart);
                Response.Cookies["Basket"].Expires = DateTime.Now.AddMonths(1);

            }
        }
        
        public ActionResult Cart()
        {
            var us = new Models.Store.CartUsefull();
            return View(us.GetCurrentBasket());
        }
        [HttpPost]
        public ActionResult Cart(FormCollection form)
        {
            var us = new Models.Store.CartUsefull();
            var mdl = us.GetCurrentBasket();

            //discount 
            if (form.AllKeys.Contains("InputDiscountCod") && !form["InputDiscountCod"].IsNullOrWhiteSpace())
            {
                var discountcode = form["InputDiscountCod"];
                var discout = us.dbs.Discounts.FirstOrDefault(dis => dis.DiscountCode == discountcode);
                if (discout != null)
                {
                    mdl.DiscountId = discout.DiscountId;
                    mdl.Discount = discout;
                }
                else
                    ModelState.AddModelError("InputDiscountCod", "کد وارد شده صحیح نیست");
            }
            else mdl.DiscountId = null;

            //items
            foreach (var item in mdl.BasketItems)
            {
                string key = "";

                if (item.Type == (byte)Models.Store.CartUsefull.Basket_ItemType.Product)
                {
                    key = string.Format("WithInstallation[{0}][{1}]", item.Id, item.Type);
                    if (form.AllKeys.Contains(key))
                        item.PriceFlag = (byte)Models.Store.CartUsefull.BasketImte_PriceFlag.Product_PricePlusInstallation;
                    else
                        item.PriceFlag = (byte)Models.Store.CartUsefull.BasketImte_PriceFlag.Product_PriceOnly;
                }

                key = string.Format("Count[{0}][{1}]", item.Id, item.Type);
                if (form.AllKeys.Contains(key))
                {
                    int cnt = 1;
                    int.TryParse(form[key], out cnt);
                    item.Count = cnt;
                    
                    item.ProductEachPrice = us.GetPriceOfCartObject(item.Id.Value, (Models.Store.CartUsefull.Basket_ItemType)item.Type.Value);
                    if (item.Type == (byte)CartUsefull.Basket_ItemType.Product && item.PriceFlag == (byte)CartUsefull.BasketImte_PriceFlag.Product_PriceOnly)
                    {
                        item.ProductEachPrice = us.GetPriceOfCartObject_int_WitoutInstallation(item.Id.Value, (Models.Store.CartUsefull.Basket_ItemType)item.Type.Value).ToString();
                    }

                    decimal discountprice = us.GetPriceOfCartObject_withDiscount(item.Id.Value, (Models.Store.CartUsefull.Basket_ItemType)item.Type.Value, mdl.Discount);
                    if (item.Type == (byte)CartUsefull.Basket_ItemType.Product && item.PriceFlag == (byte)CartUsefull.BasketImte_PriceFlag.Product_PriceOnly)
                        discountprice = us.GetPriceOfCartObject_withDiscount_WintoutInstallation(item.Id.Value, (Models.Store.CartUsefull.Basket_ItemType)item.Type.Value, mdl.Discount);
                    
                    item.ProductEachPaidPrice = discountprice.ToString();
                    item.ToatoalPaidPrice = (discountprice * item.Count).ToString();

                }
            }


            if (form.AllKeys.Contains("DelivaryTypeId") && !form["DelivaryTypeId"].IsNullOrWhiteSpace())
            {
                int deliverid = 0;
                int.TryParse(form["DelivaryTypeId"], out deliverid);
                if (deliverid > 0)
                {
                    mdl.DelivaryTypeId = deliverid;
                    mdl.ProductsOrServicesDeliveryType = us.dbs.ProductsOrServicesDeliveryTypes.FirstOrDefault(c => c.DeliverTypeID == deliverid);
                }
            }


            //timming
            if (!form.AllKeys.Contains("radioTimming"))
                ModelState.AddModelError("timmingErrors", "روز و زمان تحویل کالا تعیین نشده است");
            else
            {
                int timeofdayid = 0;
                int.TryParse(form["radioTimming"], out timeofdayid);
                if (timeofdayid > 0)
                {
                    var timming = us.dbs.TimeOfDays.FirstOrDefault(t => t.TimeOfDayId == timeofdayid);
                    if (timming == null || timming.DaysOfWeek.Date < DateTime.Today)
                        ModelState.AddModelError("timmingErrors", "روز و زمان تحویل کالا تعیین نشده است");
                    else
                        mdl.TimeOfDayId = timeofdayid;
                }
                else
                    ModelState.AddModelError("timmingErrors", "روز و زمان تحویل کالا تعیین نشده است");
            }


            us.UpdateBasket(mdl);

            if (ModelState.IsValid)
                return RedirectToAction("Cart_CartConfirmAddress");
            else
                return View(mdl);
        }
        
        [HttpPost]
        public ActionResult Cart_remoSelection(FormCollection form)
        {
            var us = new Models.Store.CartUsefull();
            var mdl = us.GetCurrentBasket();
            var xlst = mdl.BasketItems.ToList();
            foreach (var item in xlst)
            {
                string key = string.Format("RemoveItem[{0}][{1}]", item.Id, item.Type);
                if (form.AllKeys.Contains(key))
                {
                    mdl.BasketItems.Remove(item);
                }
            }
            us.UpdateBasket(mdl);
            
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult Cart_RemoveCopletly(FormCollection form)
        {
            var us = new Models.Store.CartUsefull();
            var mdl = us.GetCurrentBasket();
            mdl.BasketItems.Clear();
            us.UpdateBasket(mdl);

            return RedirectToAction("Cart");
        }

        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult Cart_CartConfirmAddress()
        {
            var model = new Models.Store.CartUsefull().GetCurrentBasket();
            
            var person = Areas.Users.Controllers.profileController.GetCurrentLoginPerson;
            model.ReciverFullname = person.PersonFirtstName + " " + person.PersonLastName;
            model.ReciverMobile = person.PersonMobile;
            model.ReciverTell = person.PersonPhone;
            model.ReciverAddress = person.PersonAddress;

            return View(model);
        }
        [HttpPost]
        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult Cart_CartConfirmAddress(DBSEF.Basket model)
        {
            var crusf = new Models.Store.CartUsefull();

            if (model.ReciverFullname.IsNullOrWhiteSpace())
                ModelState.AddModelError("ReciverFullname", "نام و نام خانوادگی  وارد نشده است");

            if (model.ReciverMobile.IsNullOrWhiteSpace())
                ModelState.AddModelError("ReciverMobile", "همراه وارد نشده است");
            else if (!model.ReciverMobile.IsNumber())
                ModelState.AddModelError("ReciverMobile", "مقدار وارد شده صحیح نیست");

            if (model.ReciverTell.IsNullOrWhiteSpace())
                ModelState.AddModelError("ReciverTell", "تلفن ثابت وارد نشده است");
            else if (!model.ReciverTell.IsNumber())
                ModelState.AddModelError("ReciverTell", "مقدار وارد شده صحیح نیست");
            
            if (model.ReciverAddress.IsNullOrWhiteSpace())
                ModelState.AddModelError("ReciverAddress", "آدرس وارد نشده است");

            if (ModelState.IsValid)
            {
                crusf.UpdateBasket(model);
            }
            return RedirectToAction("SelectePaymentType");
        }

        
        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult SelectePaymentType()
        {
            return View();
        }
        [HttpPost,Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult SelectePaymentType(Nullable<Models.Store.CartUsefull.Basket_PaymentType> PaymentType)
        {
            if (PaymentType == null)
                ModelState.AddModelError("PaymentType", "نوع پرداخت تعیین نشده است");
            else
            {
                var us = new Models.Store.CartUsefull();
                var basket = us.GetCurrentBasket();
                if (PaymentType == Models.Store.CartUsefull.Basket_PaymentType.InLocation)
                {
                    basket.PaymentType = (byte)Models.Store.CartUsefull.Basket_PaymentType.InLocation;
                    us.UpdateBasket(basket);

                    return RedirectToAction("PaymentCart_InLocation");
                }
                else if (PaymentType == Models.Store.CartUsefull.Basket_PaymentType.Online)
                {
                    basket.PaymentType = (byte)Models.Store.CartUsefull.Basket_PaymentType.Online;
                    us.UpdateBasket(basket);

                    return RedirectToAction("PaymentCart_Online");
                }
            }
            return View();
        }
        
        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult PaymentCart_InLocation()
        {
            var us = new Models.Store.CartUsefull();
            var basket = us.GetCurrentBasket();
            basket.State = (byte)Models.Store.CartUsefull.Basket_State.BuyFinished;
            basket.LocalCode = Guid.NewGuid().ToString();
            basket.FinishDate = DateTime.Now;
            us.UpdateBasket(basket);
            InsertPersonServerAndServicepacks(us.dbs, basket);
            return View(basket);
        }

        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult PaymentCart_Online()
        {
            var us = new Models.Store.CartUsefull();
            var basket = us.GetCurrentBasket();
            return View(basket);
        }


        private void InsertPersonServerAndServicepacks(DBSEF.CarAutomationEntities dbs, DBSEF.Basket basket)
        {
            foreach (var item in basket.BasketItems)
            {
                if (item.Type == (byte)Models.Store.CartUsefull.Basket_ItemType.AutoService)
                {
                    var x = dbs.PersonServices.FirstOrDefault(ps => ps.ServicesId == item.Id);
                    if (x != null)
                    {
                        var xint = x.ServicesCurrentEntity.GetValueOrDefault(0);
                        xint += item.Count.GetValueOrDefault(0);
                        x.ServicesCurrentEntity = xint;
                        x.DateAdded = DateTime.Now;
                    }
                    else
                    {
                        dbs.PersonServices.Add(new DBSEF.PersonService
                        {
                            ServicesId = item.Id,
                            UserId = basket.UserId,
                            DateAdded = DateTime.Now,
                            ServicesCurrentEntity = item.Count
                        });
                    }
                }
                if (item.Type == (byte)Models.Store.CartUsefull.Basket_ItemType.AutoServicePack)
                {
                    var x = dbs.PersonServicesPacks.FirstOrDefault(psp => psp.ServicesPackId == item.Id);
                    if (x != null)
                    {
                        var xint = x.ServicesPackCurrentEntity.GetValueOrDefault(0);
                        xint += item.Count.GetValueOrDefault(0);
                        x.ServicesPackCurrentEntity = xint;
                        x.DateAdded = DateTime.Now;
                    }
                    else
                    {
                        dbs.PersonServicesPacks.Add(new DBSEF.PersonServicesPack
                        {
                            ServicesPackId = item.Id,
                            UserId = basket.UserId,
                            DateAdded = DateTime.Now,
                            ServicesPackCurrentEntity = item.Count
                        });
                    }   
                }
            }
            dbs.SaveChanges();
        }

        #endregion

        #region Products
        public ActionResult Products(int id)
        {
            return View(id);
        }
        [HttpPost]
        public ActionResult Products(int id, FormCollection form)
        {
            ViewBag.error = new Dictionary<string, string>();
            if (form.AllKeys.Contains("SendACommentRequest"))
            {
                if (form["fullname"] == "")
                    ViewBag.error["fullname"] = "نام و نام خانوادگی تعیین نشده است";
                if (form["email"] == "")
                    ViewBag.error["email"] = "ایمیل وارد نشده است";
                else if(!form["email"].String_IsEmail())
                    ViewBag.error["email"] = "ایمیل وارد شده صحیح نیست";

                if(form["comment"] == "")
                    ViewBag.error["comment"] = "پیام وارد نشده است";

                if (form["captcha"] == "")
                    ViewBag.error["captcha"] = "کد امنیتی وارد نشده است";
                else if (!DefaultController.ValidationCaptcha(form["captcha"]))
                    ViewBag.error["captcha"] = "کد امنیتی وارد شده صحیح نیست";

                if (((Dictionary<string, string>)ViewBag.error).Count == 0)
                {
                    var dbs = new DBSEF.CarAutomationEntities();
                    dbs.ProductComments.Add(new DBSEF.ProductComment { Comment = form["comment"], Email = form["email"], Fullname = form["fullname"], ProductId = id, datetime = DateTime.Now });
                    dbs.SaveChanges();
                    ViewBag.error["success"] = "پیام شما با موفقیت ثبت شد و پس از تایید به نمایش در خواهد آمد";
                }
            }
            return View(id);
        }
        
        [HttpPost]
        public int Products_makePopular(int id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            int res = 0;
            if (dbs.ProductToViews.Count(p => p.ProductId == id) > 0)
            {
                var x = dbs.ProductToViews.FirstOrDefault(p => p.ProductId == id);
                if (x != null)
                {
                    if (x.Favorite == null || x.Favorite <= 0)
                    { x.Favorite = 1; res = 1; }
                    else
                    { x.Favorite += 1; res = x.Favorite.Value; }
                }
            }

            dbs.SaveChanges();
            return res;
        }
        

        public ActionResult ProductsList(int? id)
        {
            return View(id);
        }

        public ActionResult ProductsRss(int? id)
        {
            return View();
        }

        public ActionResult ProductSitemap(int? id)
        {
            return View();
        }
        #endregion

        #region Services
        public ActionResult ServiceView(int id)
        {
            return View(id);
        }
        [HttpPost]
        public int ServiceView_makePopular(int id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            int res = 0;

            var x = dbs.ServiceToViews.FirstOrDefault(p => p.ServiceId == id);
            if (x != null)
            {
                if (x.Favorite == null || x.Favorite <= 0)
                { x.Favorite = 1; res = 1; }
                else
                { x.Favorite += 1; res = x.Favorite.Value; }
            }


            dbs.SaveChanges();
            return res;
        }



        public ActionResult ServicePackView(int id)
        {
            return View(id);
        }
        [HttpPost]
        public int ServicePackView_makePopular(int id)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            int res = 0;

            var x = dbs.ServicesPackToViews.FirstOrDefault(p => p.ServicesPackId == id);
            if (x != null)
            {
                if (x.Favorite == null || x.Favorite <= 0)
                { x.Favorite = 1; res = 1; }
                else
                { x.Favorite += 1; res = x.Favorite.Value; }
            }


            dbs.SaveChanges();
            return res;
        }
        #endregion

        #region forum
        public ActionResult ProductForum(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductForum(int? id, FormCollection form)
        {
            if (form.AllKeys.Contains("newQuestion") && !string.IsNullOrWhiteSpace(form["newQuestion"]))
            {
                var dbs = new DBSEF.CarAutomationEntities();
                dbs.ProductQnAs.Add(new DBSEF.ProductQnA { ProductId = id, Question = form["newQuestion"], QuestionType = "Q" });
                dbs.SaveChanges();
                ModelState.AddModelError("success", "پرسش شما با موفقیت ثبت شد");
            }
            else
                ModelState.AddModelError("newQuestion", "پرسش وارد نشده است");
            return View();
        }
        public ActionResult ProductForum_Question(int? id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductForum_Question(int? id, DBSEF.ProductQnA model)
        {
            if (model.Question.IsNullOrWhiteSpace())
                ViewData.ModelState.AddModelError("Question", "متن پرسش وارد نشده است");
            if (ModelState.IsValid)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                model.QuestionType = "Q";
                dbs.ProductQnAs.Add(model);
                dbs.SaveChanges();

                return RedirectToAction("ProductForum_Question", new { id = id });
            }
            return View(model);
        }
        #endregion
    }

   
}
