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
    [UsersCLS.UsersAuthFilter]
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
            var userfromDb = dbs.Users.FirstOrDefault(c => c.UserId == user.UserId);

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
            var dbs = new DBSEF.CarAutomationEntities();
            var currentperson = dbs.People.FirstOrDefault(c => c.PersonId == GetCurrentLoginPerson.PersonId);

            if (model.PersonFirtstName.IsNullOrWhiteSpace())
                ModelState.AddModelError("PersonFirtstName", "نام کاربر وارد نشده است");
            if (model.PersonLastName.IsNullOrWhiteSpace())
                ModelState.AddModelError("PersonLastName", "نام خانوادگی کاربر وارد نشده است");

            if (model.PersonEmail.IsNullOrWhiteSpace())
                ModelState.AddModelError("PersonEmail", "ایمیل کاربر وارد نشده است");
            else if (!model.PersonEmail.String_IsEmail())
                ModelState.AddModelError("PersonEmail", "ایمیل وارد شده صحیح نیست");
            else if (dbs.People.Count(p => p.PersonEmail == model.PersonEmail && p.UserId != currentperson.UserId) > 0)
                ModelState.AddModelError("PersonEmail", "ایمیل وارد شده تکراری است");

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

            if (Request.Files.AllKeys.Contains("userImage") && Request.Files["userImage"].ContentLength > 0)
            {
                if (!Request.Files["userImage"].ContentType.ContentTypeIsImage())
                    ModelState.AddModelError("userImage", "فرمت فایل آپلود شده مورد تایید نیست");
                if (Request.Files["userImage"].ContentLength > (100 * (1024)))
                    ModelState.AddModelError("userImage", "حجم فایل آپلود شده بیشتر از 100 کیلوبایت است");
            }

            if (ModelState.IsValid)
            {
                if (Request.Files.AllKeys.Contains("userImage") && Request.Files["userImage"].ContentLength > 0)
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

        public ActionResult UserNotifications()
        {
            return View();
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

                {//Send Activation Email to User
                    var nr = new CLS.MailsServers.Mail_noreply();
                    nr.SendUserActivationMail(model, Url, Request);
                }

                //saveChanges if Allthin be correct
                model.Save();
                ModelState.AddModelError("successSignUp", "ثبت نام با موفقیت انجام پذیرفت");

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
                var user = dbs.Users.FirstOrDefault(u => u.Uname.ToLower() == username && u.Upass == pass && u.UserRoleId == 2);
                if (user != null && user.IsActive == true)
                {
                    user.ActiveRecoveryCode = null;
                    user.ActiveORecovery = null;
                    dbs.SaveChanges();

                    Session["guestUser"] = user;

                    //cart redirect
                    try
                    {
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
                    }
                    catch { }
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
                        return RedirectToRoute(new { area = "", controller = "Home", action = "Index" });
                }
                else if (user != null && user.IsActive == null)
                {
                    var userperson = dbs.People.FirstOrDefault(p => p.UserId == user.UserId);
                    error.Add(string.Format("نام کاربری شما هنوز فعال نشده است. <br /><a href='/users/profile/UserResendUserActivationCode?User={0}'>ارسال مجدد ایمیل فعالسازی به {1}</a><br /> <a href=\"/users/profile/UserResendUserActivationCodeToNewEmail?User={0}\">ویرایش ایمیل و ارسال مجدد ایمیل فعال سازی</a>", user.Uname, userperson.PersonEmail));
                }
                else
                {
                    error.Add("کاربری با مشخصات وارد شده یافت نشد");
                }
            }


            ViewBag.loginerror = error;
            return View();
        }

        [UsersCLS.Users_DontAuthFilter]
        public ActionResult userActivation(string ActiveCode, string User)
        {
            if (ActiveCode.IsNullOrWhiteSpace() || User.IsNullOrWhiteSpace())
                return Redirect("/");
            return View(model: new Tuple<string, string>(ActiveCode, User));
        }
        [UsersCLS.Users_DontAuthFilter]
        public ActionResult UserResendUserActivationCode(string User)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var userid = dbs.People.FirstOrDefault(p => p.User.Uname == User);
            if (userid == null)
                Redirect("/");
            var model = new CarProject.Models.User.UserInfo(userid.User.UserId);

            {//Send Activation Email to User                
                var nr = new CLS.MailsServers.Mail_noreply();
                nr.SendUserActivationMail(model, Url, Request);
            }
            return View(model);
        }
        [UsersCLS.Users_DontAuthFilter]
        public ActionResult UserResendUserActivationCodeToNewEmail(string User)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var person = dbs.People.FirstOrDefault(p => p.User.Uname == User);
            if (person == null)
                Redirect("/");

            return View(model: person.PersonEmail);
        }
        [HttpPost, UsersCLS.Users_DontAuthFilter]
        public ActionResult UserResendUserActivationCodeToNewEmail(string User, FormCollection form)
        {
            var dbs = new DBSEF.CarAutomationEntities();
            var person = dbs.People.FirstOrDefault(p => p.User.Uname == User);
            if (person == null)
                Redirect("/");


            if (!form.AllKeys.Contains("email") || form["email"].IsNullOrWhiteSpace())
                ModelState.AddModelError("email", "ایمیل وارد نشده است");
            else if (!form["email"].String_IsEmail())
                ModelState.AddModelError("email", "ایمیل وارد شده صحیح نیست");


            if (ModelState.IsValid)
            {//Send Activation Email to User  
                person.PersonEmail = form["email"];
                person.User.ActiveRecoveryCode = Guid.NewGuid().ToString();
                dbs.SaveChanges();
                var model = new CarProject.Models.User.UserInfo(person.User.UserId);
                var nr = new CLS.MailsServers.Mail_noreply();
                nr.SendUserActivationMail(model, Url, Request);
                ModelState.AddModelError("successSendMessage", "ایمیل فعال سازی با موفقیت ارسال شد");
            }

            return View(model: person.PersonEmail);
        }

        [UsersCLS.Users_DontAuthFilter]
        public ActionResult UserPasswordRecovery()
        {
            return View();
        }
        [HttpPost, UsersCLS.Users_DontAuthFilter]
        public ActionResult UserPasswordRecovery(FormCollection form)
        {
            try
            {
                var dbs = new DBSEF.CarAutomationEntities();
                var email = "";
                if (form.AllKeys.Contains("email"))
                    email = form["email"];

                if (!form.AllKeys.Contains("email") || form["email"].IsNullOrWhiteSpace())
                    ModelState.AddModelError("email", "ایمیل وارد نشده است");
                else if (!form["email"].String_IsEmail())
                    ModelState.AddModelError("email", "ایمیل وارد شده صحیح نیست");
                else if (dbs.People.Count(p => p.PersonEmail.ToLower() == email.ToLower() && p.User.IsActive == true) <= 0)
                    ModelState.AddModelError("email", "کابری با ایمیل وارد شده یافت نشد");


                if (!form.AllKeys.Contains("captcha") || form["captcha"].IsNullOrWhiteSpace())
                    ModelState.AddModelError("captcha", "کد امنیتی وارد نشده است");
                else if (!CarProject.Controllers.DefaultController.ValidationCaptcha(form["captcha"]))
                    ModelState.AddModelError("captcha", "کد امنیتی وارد شده صحیح نیست");

                if (ModelState.IsValid)
                {
                    var people = dbs.People.FirstOrDefault(p => p.PersonEmail.ToLower() == email.ToLower());
                    people.User.ActiveORecovery = 1;
                    people.User.ActiveRecoveryCode = Guid.NewGuid().ToString();
                    dbs.SaveChanges();

                    CLS.MailsServers.Mail_noreply m = new CLS.MailsServers.Mail_noreply();
                    m.SendUserRecoveryMail(new CarProject.Models.User.UserInfo(people.UserId.Value), Url, Request);

                    ModelState.AddModelError("success", "ایمیل بازیابی کلمه عبور با موفقیت ارسال شد");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("success", ex.Message);
                throw;
            }
            return View();
        }

        [UsersCLS.Users_DontAuthFilter]
        public ActionResult UserRecoveryPassword(string user, string activeationcode)
        {
            var dbs = new DBSEF.CarAutomationEntities();

            if (user.IsNullOrWhiteSpace() ||
                activeationcode.IsNullOrWhiteSpace())
                ModelState.AddModelError("nullrequest", "کاربر و یا کد بازیابی کلمه عبور تعیین نشده است");
            else if (dbs.Users.FirstOrDefault(u => u.IsActive == true && u.Uname.ToLower() == user.ToLower()) == null)
                ModelState.AddModelError("usernotexist", "کاربری با نام کاربری وارد شده وجود ندارد");
            else if (dbs.Users.FirstOrDefault(u => u.IsActive == true && u.Uname.ToLower() == user.ToLower() && u.ActiveRecoveryCode.ToLower() == activeationcode.ToLower()) == null)
                ModelState.AddModelError("recoverycodeincorrect", "کد فعال سازی صحیح نیست");

            return View();
        }
        [HttpPost, UsersCLS.Users_DontAuthFilter]
        public ActionResult UserRecoveryPassword(string user, string activeationcode, FormCollection form)
        {
            if (!form.AllKeys.Contains("password1") || form["password1"].IsNullOrWhiteSpace())
                ModelState.AddModelError("password1", "کلمه عبور جدید وارد نشده است");
            if (!form.AllKeys.Contains("password2") || form["password2"].IsNullOrWhiteSpace())
                ModelState.AddModelError("password2", "تایید کلمه عبور جدید وارد نشده است");

            if (form.AllKeys.Contains("password1") &&
                form.AllKeys.Contains("password2") &&
                !form["password1"].IsNullOrWhiteSpace() &&
                !form["password2"].IsNullOrWhiteSpace() &&
                form["password2"] != form["password1"])
            {
                ModelState.AddModelError("password1", "کلمه عبور وتایید آن برابر نیست");
                ModelState.AddModelError("password2", "کلمه عبور وتایید آن برابر نیست");
            }

            if (ModelState.IsValid)
            {
                var dbs = new DBSEF.CarAutomationEntities();
                var person = dbs.People.FirstOrDefault(p => p.User.Uname.ToLower() == user.ToLower());
                if (person != null)
                {
                    person.User.ActiveRecoveryCode = null;
                    person.User.ActiveORecovery = null;
                    person.User.Upass = CLS.Usefulls.MD5Passwords(form["password1"]);
                    dbs.SaveChanges();
                }

                ModelState.AddModelError("seccess", "عملیات با موفقیت انجام شد");
            }


            return View();

        }


        public static DBSEF.User GetCurrentLoginedUser
        {
            get
            {
                var Session = System.Web.HttpContext.Current.Session;
                if (Session["guestUser"] != null && Session["guestUser"] is DBSEF.User)
                {
                    return Session["guestUser"] as DBSEF.User;
                }
                else
                    return null;

                //var dbs = new DBSEF.CarAutomationEntities();
                //return dbs.Users.FirstOrDefault(u => u.UserId == 3);
            }
        }
        public static DBSEF.Person GetCurrentLoginPerson
        {
            get
            {
                if (GetCurrentLoginedUser == null)
                    return null;
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
