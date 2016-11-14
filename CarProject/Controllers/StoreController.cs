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
        public void AddToCart(int id, CartOfProducts.CartType type)
        {
            if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
            {
                var user = Session["guestUser"] as DBSEF.User;
                var dbs = new DBSEF.CarAutomationEntities();
                var tobasket = new DBSEF.ToBasket();
                tobasket.UserId = user.UserId;

                bool istrue = true;
                switch (type)
                {
                    case CartOfProducts.CartType.Product:
                        if (dbs.ToBaskets.Count(c => c.UserId == user.UserId && c.ProductId == id) <= 0)
                            tobasket.ProductId = id;
                        else
                            istrue = false;
                        break;
                    case CartOfProducts.CartType.AutoService:
                        if (dbs.ToBaskets.Count(c => c.UserId == user.UserId && c.AutoServiceId == id) <= 0)
                            tobasket.AutoServiceId = id;
                        else
                            istrue = false;
                        break;
                    case CartOfProducts.CartType.AutoServicePack:
                        if (dbs.ToBaskets.Count(c => c.UserId == user.UserId && c.AutoServicePackId == id) <= 0)
                            tobasket.AutoServicePackId = id;
                        else
                            istrue = false;
                        break;
                    default:
                        istrue = false;
                        break;
                }

                if (istrue)
                {
                    tobasket.ProductEntity = 1;
                    dbs.ToBaskets.Add(tobasket);
                    dbs.SaveChanges();
                }
                
            }
            else
            {
                var list = new List<CartOfProducts>();
                var cartobje = new CartOfProducts { Id = id, TypeOfProduct = type };

                if (Request.Cookies["UserCart"] != null && Request.Cookies["UserCart"].Value != "")
                {
                    list = JsonConvert.DeserializeObject<List<CartOfProducts>>(Request.Cookies["UserCart"].Value);
                }

                if (!list.Contains(cartobje))
                    list.Add(cartobje);


                Response.Cookies["UserCart"].Value = JsonConvert.SerializeObject(list);
                Response.Cookies["UserCart"].Expires = DateTime.Today.AddMonths(1);
            }
        }
        public ActionResult Cart()
        {
            var list = new List<CartOfProducts>();

            if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
            {
                var user = Session["guestUser"] as DBSEF.User;
                var dbs = new DBSEF.CarAutomationEntities();
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
                    list.Add(crt);
                }
            }
            else
            {
                if (Request.Cookies["UserCart"] != null && Request.Cookies["UserCart"].Value != "")
                    list = JsonConvert.DeserializeObject<List<CartOfProducts>>(Request.Cookies["UserCart"].Value);
            }

            return View(list);
        }
        [HttpPost]
        public ActionResult Cart(List<CartOfProducts> list,bool clearForm)
        {
            if (clearForm)
            {
                list = new List<CartOfProducts>();

                if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
                {
                    var user = Session["guestUser"] as DBSEF.User;
                    var dbs = new DBSEF.CarAutomationEntities();
                    dbs.ToBaskets.RemoveRange(dbs.ToBaskets.Where(c => c.UserId == user.UserId));
                    dbs.SaveChanges();
                }
                else
                {
                    Response.Cookies["UserCart"].Value = JsonConvert.SerializeObject(list);
                    Response.Cookies["UserCart"].Expires = DateTime.Today.AddMonths(1);
                }
            }
            return View(list);
        }
        #endregion

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
    }

    public class CartOfProducts
    {
        public enum CartType
        {
            Product = 1,
            AutoService = 2,
            AutoServicePack = 3
        };

        public int Id { get; set; }
        public CartType TypeOfProduct { get; set; }
        public int Count { get; set; }

        public CartOfProducts()
        {
            Count = 1;
        }

        public override bool Equals(object obj)
        {
            return (obj is CartOfProducts && ((CartOfProducts)obj) == this);
        }
        public override int GetHashCode()
        {
            return Id * (int)TypeOfProduct;
        }
        public static bool operator ==(CartOfProducts value1, CartOfProducts value2)
        {
            return value1.Id == value2.Id && value1.TypeOfProduct == value2.TypeOfProduct;
        }
        public static bool operator !=(CartOfProducts value1, CartOfProducts value2)
        {
            return value1.Id != value2.Id || value1.TypeOfProduct != value2.TypeOfProduct;
        }
    }
}
