using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarProject.App_extension;
using Newtonsoft.Json;

namespace CarProject.Areas.Users.Controllers
{
    public class profileController : Controller
    {
        //
        // GET: /Users/profile/

        [UsersCLS.UsersAuthFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup()
        {
            var model = new Models.User.UserInfo();
            return View(model);
        }
        [HttpPost]
        public ActionResult Signup(Models.User.UserInfo model)
        {
            if (ModelState.IsValid)
            {
                model.Person.User.IsActive = true;
                model.Person.User.UserRoleId = 2;
                model.Save();

                return RedirectToAction("Login");
            }
            return View(model);
        }

        public ActionResult Login()
        {
            if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
                return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var error = new List<string>();

            if (form["username"].IsNullOrWhiteSpace())
                error.Add("نام کاربری تعیین نشده است");
            if (form["password"].IsNullOrWhiteSpace())
                error.Add("کمله عبور تعیین نشده است");

            if (error.Count == 0)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                var username = form["username"].ToLower();
                var pass = CLS.Usefulls.MD5Passwords(form["password"]);
                var user = dbs.Users.FirstOrDefault(u => u.Uname.ToLower() == username && u.Upass == pass && u.IsActive == true && u.UserRoleId == 2);
                if (user != null)
                {
                    Session["guestUser"] = user;

                    //cart redirect
                    var list = new List<CarProject.Controllers.CartOfProducts>();
                    if (Request.Cookies["UserCart"] != null && Request.Cookies["UserCart"].Value != "")
                    {
                        list = JsonConvert.DeserializeObject<List<CarProject.Controllers.CartOfProducts>>(Request.Cookies["UserCart"].Value);
                        if (list is List<CarProject.Controllers.CartOfProducts>)
                        {
                            foreach (var item in list)
                            {
                                DBSEF.ToBasket tbsk = new DBSEF.ToBasket();
                                tbsk.UserId = user.UserId;

                                bool istrue = true;

                                switch (item.TypeOfProduct)
                                {
                                    case CarProject.Controllers.CartOfProducts.CartType.Product:
                                        if (dbs.ToBaskets.Count(c => c.UserId == user.UserId && c.ProductId == item.Id && c.BasketId == null) <= 0)
                                        {
                                            tbsk.ProductEntity = item.Count;
                                            tbsk.ProductId = item.Id;
                                        }
                                        else
                                        {
                                            var itm = dbs.ToBaskets.FirstOrDefault(c => c.UserId == user.UserId && c.ProductId == item.Id && c.BasketId == null);
                                            if (itm != null)
                                                itm.ProductEntity = item.Count;
                                            istrue = false;
                                        }
                                        break;
                                    case CarProject.Controllers.CartOfProducts.CartType.AutoService:
                                        if (dbs.ToBaskets.Count(c => c.UserId == user.UserId && c.AutoServiceId == item.Id && c.BasketId == null) <= 0)
                                        {
                                            tbsk.ProductEntity = item.Count;
                                            tbsk.AutoServiceId = item.Id;
                                        }
                                        else
                                        {
                                            var itm = dbs.ToBaskets.FirstOrDefault(c => c.UserId == user.UserId && c.AutoServiceId == item.Id && c.BasketId == null);
                                            if (itm != null)
                                                itm.ProductEntity = item.Count;
                                            istrue = false;
                                        }
                                        break;
                                    case CarProject.Controllers.CartOfProducts.CartType.AutoServicePack:
                                        if (dbs.ToBaskets.Count(c => c.UserId == user.UserId && c.AutoServicePackId == item.Id && c.BasketId == null) <= 0)
                                        {
                                            tbsk.ProductEntity = item.Count;
                                            tbsk.AutoServicePackId = item.Id;
                                        }
                                        else
                                        {
                                            var itm = dbs.ToBaskets.FirstOrDefault(c => c.UserId == user.UserId && c.AutoServicePackId == item.Id && c.BasketId == null);
                                            if (itm != null)
                                                itm.ProductEntity = item.Count;
                                            istrue = false;
                                        }
                                        break;
                                    default:
                                        istrue = false;
                                        break;
                                }

                                if (istrue)
                                {
                                    dbs.ToBaskets.Add(tbsk);
                                }
                            }

                            dbs.SaveChanges();
                        }
                    }

                    
                    Response.Cookies["UserCart"].Expires = DateTime.Today.AddMonths(-2);
                    //end redirect cart


                    if (Session["guestRedirect"] != null && Session["guestRedirect"] is System.Web.Routing.RouteData)
                    {
                        var x = ((System.Web.Routing.RouteData)Session["guestRedirect"]);
                        if (x.DataTokens.Keys.Contains("area"))
                            x.Values.Add("area", x.DataTokens["area"]);
                        else
                            x.Values.Add("area", "");
                        return RedirectToRoute(x.Values);
                    }
                    else
                        return RedirectToAction("Index");
                }
                else
                {
                    error.Add("کاربری با مشخصات وارد شده یافت نشد");
                }
            }
            

            ViewBag.loginerror = error;
            return View();
        }
    }
}
