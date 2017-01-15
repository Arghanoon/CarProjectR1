using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarProject.App_extension;

namespace CarProject.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/

        DBSEF.CarAutomationEntities dbsobj = DBSEF.SingletoonDBS.GetInstance;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewsShow(int? id)
        {
            var model = new Models.News.ContentCommentModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult NewsShow(int? id, FormCollection form)
        {
            if (Areas.Users.Controllers.profileController.GetCurrentLoginedUser == null)
                return RedirectToAction("NewsShow", new { id = id });

            ViewBag.error = new Dictionary<string, string>();
            if (form.AllKeys.Contains("SendACommentRequest"))
            {
                if (form["comment"] == "")
                    ViewBag.error["comment"] = "پیام وارد نشده است";

                if (form["g-recaptcha-response"] == "")
                    ViewBag.error["g-recaptcha-response"] = "کد امنیتی وارد نشده است";
                else if (!DefaultController.ValidationRecaptcha(form["g-recaptcha-response"]))
                    ViewBag.error["g-recaptcha-response"] = "کد امنیتی وارد شده صحیح نیست";

                if (((Dictionary<string, string>)ViewBag.error).Count == 0)
                {
                    int  rootid =  0;
                    int.TryParse(form["responsecommentid"],out rootid);

                    dbsobj.ContentUserComments.Add(new DBSEF.ContentUserComment
                    {
                        ContenstId = id,
                        UserId = Areas.Users.Controllers.profileController.GetCurrentLoginedUser.UserId,
                        Comment = form["comment"],
                        DateTime = DateTime.Now,
                        RootContentUserCommentsId = ((rootid == 0) ? null : (int?)rootid)
                    });

                    dbsobj.SaveChanges();
                    ViewBag.error["success"] = "پیام شما با موفقیت ثبت شد ";
                }
            }

            
            var model = new Models.News.ContentCommentModel();
            return View(model);
        }

        [HttpPost]
        public int News_Like(int id)
        {
            if (Session["LikedNewsContianerInSessions"] != null && Session["LikedNewsContianerInSessions"] is List<int> && ((List<int>)Session["LikedNewsContianerInSessions"]).Contains(id))
                return -1;
            if (dbsobj.Contents.Count(c => c.ContenstId == id) <= 0)
                return -1;

            int res = 0;
            var pos = dbsobj.ContentPresentations.FirstOrDefault(c => c.ContentId == id);

            if (pos == null)
            {
                pos = dbsobj.ContentPresentations.Add(new CarProject.DBSEF.ContentPresentation
                {
                    ContentId = id,
                    Like = 1,
                    Dislike = 0,
                    ShowCount = 1
                });
                res = 1;
            }
            else
            {
                pos.Like = pos.Like.GetValueOrDefault(0) + 1;
                res = pos.Like.Value;
            }

            dbsobj.SaveChanges();

            if (Session["LikedNewsContianerInSessions"] == null && !(Session["LikedNewsContianerInSessions"] is List<int>))
                Session["LikedNewsContianerInSessions"] = new List<int>();

            ((List<int>)Session["LikedNewsContianerInSessions"]).Add(id);

            return res;
        }

    }

    public class NewsGroupLink
    {
        public MvcHtmlString CreateGroupLink(int? parent, string navclass = "", string linkClass = "", string isroot = "", int datalevel = 1)
        {
            string res = "";
            var DBS = new DBSEF.CarAutomationEntities();

            foreach (DBSEF.ContentsCategory item in DBS.ContentsCategories.Where(cc => cc.ParentId == parent))
            {
                res += "<section>";
                {
                    var tmp = CreateGroupLink(item.ContentsCategoryId, navclass, linkClass, isroot, (datalevel + 1));

                    if (tmp.ToString().IsNullOrWhiteSpace())
                        res += string.Format("<a href=\"{0}\" class=\"{1}\">{2}</a> ", "#", linkClass, item.Name);
                    else
                        res += string.Format("<a href=\"{0}\" class=\"{1}\">{2}</a> ", "#", string.Format("{0} {1}", linkClass, isroot), item.Name);

                    res += tmp;
                }
                res += "</section>";
            }

            if (!res.IsNullOrWhiteSpace())
                res = string.Format("<nav class=\"{0}\" data-level=\"{1}\">{2}</nav>", navclass, datalevel, res);
            return new MvcHtmlString(res);
        }
    }
}
