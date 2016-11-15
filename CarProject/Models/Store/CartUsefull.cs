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
        public int GetPriceOfCartObject_int(int id, CartOfProducts.CartType typeofcart)
        {
            switch (typeofcart)
            {
                case CartOfProducts.CartType.Product:
                    {
                        var x = dbs.Products.FirstOrDefault(c => c.ProductId == id);
                        if (x != null)
                            return x.ProductPrices.Last().ProductPrice1.Value;
                        else
                            return 0;
                    }
                case CartOfProducts.CartType.AutoService:
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
                case CartOfProducts.CartType.AutoServicePack:
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

        public DBSEF.Person PersonInformation { get; set; }
        public List<CartOfProducts> BillingList { get; set; }
        public double TotalPrice { get; set; }

        DBSEF.User User { get; set; }

        public CartConfirmBillAndAddressModel(DBSEF.User user)
        {
            this.User = user;

            var prs = dbs.People.FirstOrDefault(c => c.UserId == user.UserId);
            if (prs != null)
                PersonInformation = prs;

            BasketListGathering();
        }
        public CartConfirmBillAndAddressModel()
        {
            var user = HttpContext.Current.Session["guestUser"] as DBSEF.User;
            this.User = user;

            var prs = dbs.People.FirstOrDefault(c => c.UserId == user.UserId);
            if (prs != null)
                PersonInformation = prs;

            BasketListGathering();
        }

        void BasketListGathering()
        {
            BillingList = new List<CartOfProducts>();
            CartUsefull usf = new CartUsefull();
            TotalPrice = 0;

            var lsofbsk = dbs.ToBaskets.Where(c => c.UserId == User.UserId && c.BasketId == null);
            foreach (var item in lsofbsk)
            {
                CartOfProducts crt = new CartOfProducts();
                if (item.ProductId != null)
                {
                    crt.TypeOfProduct = CartOfProducts.CartType.Product;
                    crt.Id = item.ProductId.Value;
                    crt.Count = item.ProductEntity.Value;

                    TotalPrice += (crt.Count * usf.GetPriceOfCartObject_int(crt.Id, crt.TypeOfProduct));
                }
                else if (item.AutoServiceId != null)
                {
                    crt.TypeOfProduct = CartOfProducts.CartType.AutoService;
                    crt.Id = item.AutoServiceId.Value;
                    crt.Count = item.ProductEntity.Value;

                    TotalPrice += (crt.Count * usf.GetPriceOfCartObject_int(crt.Id, crt.TypeOfProduct));
                }
                else if (item.AutoServicePackId != null)
                {
                    crt.TypeOfProduct = CartOfProducts.CartType.AutoServicePack;
                    crt.Id = item.AutoServicePackId.Value;
                    crt.Count = item.ProductEntity.Value;

                    TotalPrice += (crt.Count * usf.GetPriceOfCartObject_int(crt.Id, crt.TypeOfProduct));
                }
                BillingList.Add(crt);
            }
        }

        public void saveChaneges()
        {
            dbs.SaveChanges();
        }

        public DBSEF.Basket PaymentCartSuccessed(string BankCode, bool OnlineOrInPlace)
        {
            var x = new DBSEF.Basket();

            x.BackCodeFromBank = BankCode;
            x.BasketCode = Guid.NewGuid().ToString();
            x.UserId = User.UserId;
            x.date = DateTime.Now;
            x.TotalPrice = (int)TotalPrice;
            x.OnlineOrInPlace = OnlineOrInPlace;


            dbs.Baskets.Add(x);

            var tbs = dbs.ToBaskets.Where(c => c.UserId == User.UserId && c.BasketId == null);
            foreach (var item in tbs)
            {
                item.Basket = x;
            }

            dbs.SaveChanges();

            return x;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();

            if (PersonInformation.PersonFirtstName.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("نام وارد نشده است", new string[] { "PersonInformation.PersonFirtstName"  }));
            if (PersonInformation.PersonLastName.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("نام خانوادگی وارد نشده است", new string[] { "PersonInformation.PersonLastName" }));

            if (PersonInformation.PersonMobile.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("شماره تلفن همراه وارد نشده است", new string[] { "PersonInformation.PersonMobile" }));
            else if (!PersonInformation.PersonMobile.IsNumber())
                res.Add(new ValidationResult("شماره تلفن همراه وارد شده صحیح نیست", new string[] { "PersonInformation.PersonMobile" }));

            if (PersonInformation.PersonAddressCity.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("استان و شهر وارد نشده است", new string[] { "PersonInformation.PersonAddressCity" }));
            if (PersonInformation.PersonAddress.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("آدرس وارد نشده است", new string[] { "PersonInformation.PersonAddress" }));

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

        public static List<CartOfProducts> GenerateList(HttpSessionStateBase Session, HttpRequestBase Request)
        {
            var list = new List<CartOfProducts>();

            if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
            {
                var user = Session["guestUser"] as DBSEF.User;
                var dbs = new DBSEF.CarAutomationEntities();
                var lsofbsk = dbs.ToBaskets.Where(c => c.UserId == user.UserId && c.BasketId == null);
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
                        crt.TypeOfProduct = CartOfProducts.CartType.AutoService;
                        crt.Id = item.AutoServiceId.Value;
                        crt.Count = item.ProductEntity.Value;
                    }
                    else if (item.AutoServicePackId != null)
                    {
                        crt.TypeOfProduct = CartOfProducts.CartType.AutoServicePack;
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
                if (list == null)
                    list = new List<CartOfProducts>();
            }

            return list;

        }
        public static List<CartOfProducts> GenerateList_BasketDetails(int? basketId, DBSEF.User user)
        {
            var list = new List<CartOfProducts>();

            if (basketId != null)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                var lsofbsk = dbs.ToBaskets.Where(c => c.UserId == user.UserId && c.BasketId == basketId);
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
                        crt.TypeOfProduct = CartOfProducts.CartType.AutoService;
                        crt.Id = item.AutoServiceId.Value;
                        crt.Count = item.ProductEntity.Value;
                    }
                    else if (item.AutoServicePackId != null)
                    {
                        crt.TypeOfProduct = CartOfProducts.CartType.AutoServicePack;
                        crt.Id = item.AutoServicePackId.Value;
                        crt.Count = item.ProductEntity.Value;
                    }
                    list.Add(crt);
                }
            }

            return list;

        }
    }
}