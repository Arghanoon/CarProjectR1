using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarProject.App_extension;
using Newtonsoft.Json;

using System.Net.Mail;
using System.IO;

namespace CarProject.Areas.Users.Controllers
{
    //[UsersCLS.UsersAuthFilter]
    public class profileController : Controller
    {
        //
        // GET: /Users/profile/

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewUserProfile()
        {
            return View();
        }

        public ActionResult UserChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserChangePassword(FormCollection form)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var user = GetCurrentLoginedUser;
            var userfromDb = dbs.Users.FirstOrDefault(c => c.UserId ==  user.UserId);

            if (form["currentPassword"].IsNullOrWhiteSpace() || form["currentPassword"] == null)
                ModelState.AddModelError("currentPassword", "کلمه عبور فعلی وارد نشده است");
            else if (CLS.Usefulls.MD5Passwords(form["currentPassword"]) != userfromDb.Upass)
                ModelState.AddModelError("currentPassword", "کلمه عبور فعلی وارد شده صحیح نیست");

            if (form["newPassword1"].IsNullOrWhiteSpace() || form["newPassword1"] == null)
                ModelState.AddModelError("newPassword1", "کلمه عبور جدید وارد نشده است");
            if (form["newPassword2"].IsNullOrWhiteSpace() || form["newPassword2"] == null)
                ModelState.AddModelError("newPassword2", "تایید کلمه عبور جدید وارد نشده است");

            if (!form["newPassword1"].IsNullOrWhiteSpace() && !form["newPassword2"].IsNullOrWhiteSpace() && form["newPassword1"] != form["newPassword2"])
            {
                ModelState.AddModelError("newPassword2", "کلمه عبور جدید و تایید آن برابر نیستند");
                ModelState.AddModelError("newPassword1", "کلمه عبور جدید و تایید آن برابر نیستند");
            }

            if (ModelState.IsValid)
            {
                userfromDb.Upass = CLS.Usefulls.MD5Passwords(form["newPassword1"]);
                dbs.SaveChanges();

                ModelState.AddModelError("success", "کلمه عبور با موفقیت تغییر یافت");
            }

            return View();
        }

        public ActionResult UserEditePersonInformation()
        {
            return View(GetCurrentLoginPerson);
        }
        [HttpPost]
        public ActionResult UserEditePersonInformation(DBSEF.Person model)
        {
            if (model.PersonFirtstName.IsNullOrWhiteSpace())
                ModelState.AddModelError("PersonFirtstName", "نام کاربر وارد نشده است");
            if (model.PersonLastName.IsNullOrWhiteSpace())
                ModelState.AddModelError("PersonLastName", "نام خانوادگی کاربر وارد نشده است");

            if (model.PersonEmail.IsNullOrWhiteSpace())
                ModelState.AddModelError("PersonEmail", "ایمیل کاربر وارد نشده است");
            else if (!model.PersonEmail.String_IsEmail())
                ModelState.AddModelError("PersonEmail", "ایمیل وارد شده صحیح نیست");

            if (model.PersonMobile.IsNullOrWhiteSpace())
                ModelState.AddModelError("PersonMobile", "همراه وارد نشده است");
            if (!model.PersonMobile.IsNumber())
                ModelState.AddModelError("PersonMobile", "همراه وارد شده صحیح نیست");

            if (!model.PersonPhone.IsNullOrWhiteSpace() && !model.PersonPhone.IsNumber())
                ModelState.AddModelError("PersonPhone", "شماره وارد شده صحیح نیست");

            if (model.PersonAddressCity.IsNullOrWhiteSpace())
                ModelState.AddModelError("PersonAddressCity", "شهر و استان محل اقامت وارد نشده است");

            if (model.PersonAddress.IsNullOrWhiteSpace())
                ModelState.AddModelError("PersonAddress", "آدرس وارد نشده است");

            if (Request.Files.AllKeys.Contains("userImage"))
            {
                if (!Request.Files["userImage"].ContentType.ContentTypeIsImage())
                    ModelState.AddModelError("userImage", "فرمت فایل آپلود شده مورد تایید نیست");
                if (Request.Files["userImage"].ContentLength > (100 * (1024)))
                    ModelState.AddModelError("userImage", "حجم فایل آپلود شده بیشتر از 100 کیلوبایت است");
            }

            if (ModelState.IsValid)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                var currentperson = dbs.People.FirstOrDefault(c => c.PersonId == GetCurrentLoginPerson.PersonId);

                if (Request.Files.AllKeys.Contains("userImage"))
                {
                    var uimgpath = Server.MapPath("".BaseRouts_UserProfileImages());
                    DirectoryInfo dic = new DirectoryInfo(uimgpath);
                    if (!dic.Exists)
                        dic.Create();
                    var OldFile = dic.GetFiles(currentperson.UserId.ToString() + ".*");
                    foreach (var item in OldFile)
                    {
                        item.Delete();
                    }
                    var filext = Request.Files["userImage"].FileName.Split('.').Last();
                    uimgpath = Server.MapPath((currentperson.UserId.ToString() + "." + filext).BaseRouts_UserProfileImages());

                    Request.Files["userImage"].SaveAs(uimgpath);
                }


                TryUpdateModel(currentperson);
                dbs.SaveChanges();

                ModelState.AddModelError("success", "ویرایش اطلاعات کاربر با موفقیت انجام شد");
            }

            return View(model);
        }


        #region Login and Logout and Current User
        [HttpPost]
        public ActionResult LogoutRequest()
        {
            Session["guestUser"] = null;
            Session.Remove("guestUser");
            return Redirect("/");
        }

        [UsersCLS.Users_DontAuthFilter]
        public ActionResult Signup()
        {
            var model = new CarProject.Models.User.UserInfo();
            return View(model);
        }
        [HttpPost]
        [UsersCLS.Users_DontAuthFilter]
        public ActionResult Signup(CarProject.Models.User.UserInfo model, string captcha)
        {
            if (captcha.IsNullOrWhiteSpace())
                ModelState.AddModelError("captcha", "کد امنیتی وارد نشده است");
            else if (!CarProject.Controllers.DefaultController.ValidationCaptcha(captcha))
                ModelState.AddModelError("captcha", "کد امنیتی وارد شده صحیح نست");

            if (ModelState.IsValid)
            {
                //model.Person.User.IsActive = true;
                model.Person.User.ActiveRecoveryCode = Guid.NewGuid().ToString();
                model.Person.User.ActiveORecovery = (byte)DBSEF.User.Enum_ActiveORecoveryEnum.Activation;

                model.Person.User.UserRoleId = 2;
                model.Save();

                //{//Send Activation Email to User
                //    MailMessage message = new MailMessage();
                //    message.To.Add(new MailAddress(model.Person.PersonEmail));
                //    message.IsBodyHtml = true;

                //    var ActivationEmailContent = new Areas.Admin.Models.Dashboard.MailsMessage_Signup_SendActivationcode();
                //    ActivationEmailContent.Load();
                //    string messageBody = ActivationEmailContent.Message.Replace("[codeonly]", model.Person.User.ActiveRecoveryCode);
                //    messageBody = messageBody.Replace("[codelink]", string.Format("<a href=\"{0}\">{0}</a>", model.Person.User.ActiveRecoveryCode));

                //    messageBody = messageBody.Replace("[userfullname]", model.Person.PersonFirtstName + " " + model.Person.PersonLastName);
                //    messageBody = messageBody.Replace("[username]", model.Person.User.Uname);
                //    messageBody = messageBody.Replace("[password]", model.Password);


                //    message.Body = messageBody;
                //    message.From = new MailAddress("info@khodroclinic.com", "خودرو کلینیک");


                //    SmtpClient smtp = new SmtpClient();
                //    smtp.Send(message);
                //}

                return RedirectToAction("Login");
            }
            return View(model);
        }

        [UsersCLS.Users_DontAuthFilter]
        public ActionResult Login()
        {
            if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
                return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
        [UsersCLS.Users_DontAuthFilter]
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
                    if (Request.Cookies["Basket"] != null && !Request.Cookies["Basket"].Value.IsNullOrWhiteSpace())
                    {
                        var basket = JsonConvert.DeserializeObject<DBSEF.Basket>(Request.Cookies["Basket"].Value);
                        if (basket != null)
                        {
                            var userbasket = dbs.Baskets.FirstOrDefault(c => c.UserId == user.UserId && c.State == (byte)CarProject.Models.Store.CartUsefull.Basket_State.Openned);
                            if (userbasket == null)
                            {
                                basket.UserId = user.UserId;
                                basket.ProductsOrServicesDeliveryType = null;
                                basket.State = (byte)CarProject.Models.Store.CartUsefull.Basket_State.Openned;
                                dbs.Baskets.Add(basket);
                            }
                            else
                            {
                                userbasket.DelivaryTypeId = basket.DelivaryTypeId;
                                foreach (var item in basket.BasketItems)
                                {
                                    var itm = userbasket.BasketItems.FirstOrDefault(c => c.Id == item.Id && c.Type == item.Type);
                                    if (itm == null)
                                        userbasket.BasketItems.Add(item);
                                    else
                                        itm.Count = item.Count;
                                }
                            }
                        }

                        dbs.SaveChanges();


                        Response.Cookies["Basket"].Expires = DateTime.Now.AddMonths(-1);
                    }
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


        public static DBSEF.User GetCurrentLoginedUser
        {
            get
            {
                //var Session = System.Web.HttpContext.Current.Session;
                //if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
                //{
                //    return Session["guestUser"] as DBSEF.User;
                //}
                //else
                //    return null;

                var dbs = new DBSEF.CarAutomationEntities();
                return dbs.Users.FirstOrDefault(u => u.UserRoleId == 2);
            }
        }
        public static DBSEF.Person GetCurrentLoginPerson
        {
            get
            {
                var dbs = new DBSEF.CarAutomationEntities();
                return dbs.People.FirstOrDefault(p => p.UserId == GetCurrentLoginedUser.UserId);
            }
        }
        public static string GetCurrentUserImage
        {
            get
            {
                string result = "/Publics/Files/Images/generic.png";

                var path = "".BaseRouts_UserProfileImages();
                var dinf = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath(path));
                if (dinf.Exists)
                {
                    var files = dinf.GetFiles(GetCurrentLoginedUser.UserId + ".*");
                    if (files.Length > 0)
                    {
                        result = files[0].Name.BaseRouts_UserProfileImages();
                    }
                }


                return result;
            }
        }
        #endregion
    }
}
