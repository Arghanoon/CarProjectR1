using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

using CarProject.App_extension;


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
        
        #region Cart
        public void AddToCart(int id, Models.Store.CartUsefull.Basket_ItemType type)
        {
            
            if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                var user = Session["guestUser"] as DBSEF.User;
                var cart = dbs.Baskets.FirstOrDefault(c => c.UserId == user.UserId && c.PaymentType == (byte)Models.Store.CartUsefull.Basket_PaymentType.Openned);
                if (cart == null)
                {
                    cart = new DBSEF.Basket { UserId = user.UserId, PaymentType = (byte)Models.Store.CartUsefull.Basket_PaymentType.Openned };
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
            foreach (var item in mdl.BasketItems)
            {
                string key = string.Format("Count[{0}][{1}]", item.Id, item.Type);
                if (form.AllKeys.Contains(key))
                {
                    int cnt = 1;
                    int.TryParse(form[key], out cnt);
                    item.Count = cnt;
                }
            }
            us.UpdateBasket(mdl);

            return View(mdl);
        }
        /*
        [HttpPost]
        public ActionResult Cart_remoSelection(string RemoveList)
        {
            
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public ActionResult Cart_RemoveCopletly()
        {
           
            return RedirectToAction("Cart");
        }

        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult Cart_CartConfirmAddress()
        {
           
            return View(model);
        }
        [HttpPost]
        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult Cart_CartConfirmAddress(Models.Store.CartConfirmBillAndAddressModel model)
        {
            
        }

        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult SelectePaymentType()
        {
            return View();
        }

        [Areas.Users.UsersCLS.UsersAuthFilter]
        public ActionResult PaymentCart(int? id)
        {
            if (id == null)
            {
                var x = new Models.Store.CartConfirmBillAndAddressModel();
                if (x.BillingList.Count > 0)
                {
                    var bs = x.PaymentCartSuccessed(DateTime.Now.Ticks.ToString(), true);
                    return View(bs);
                }
                else
                    return RedirectToAction("Cart");
            }
            else
            {
                var dbs = new DBSEF.CarAutomationEntities();
                var user = Session["guestUser"] as DBSEF.User;
                var bs2 = dbs.Baskets.FirstOrDefault(bs => bs.BasketId == id && bs.UserId == user.UserId);

                if (bs2 != null)
                    return View(bs2);
                else
                    return RedirectToAction("Cart");
            }
        }*/
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
