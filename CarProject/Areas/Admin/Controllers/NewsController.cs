using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using db = CarProject.DBSEF;
using System.IO;
using CarProject.App_extension;

namespace CarProject.Areas.Admin.Controllers
{
    [CarProject.CLS.AuthFilter]
    public class NewsController : Controller
    {
        //
        // GET: /Admin/News/

        DBSEF.CarAutomationEntities DBS = new db.CarAutomationEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News_Publish()
        {
            var model = new Models.News.Newsmodel();
            return View(model);
        }
        [HttpPost]
        public ActionResult News_Publish(Models.News.Newsmodel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("NewsImagesGallery", new { id = model.Content.ContenstId });
            }
            return View(model);
        }


        public ActionResult NewsImagesGallery(int id)
        {
            ViewBag.images = new List<string>();
            string folder = id.ToString().BaseRouts_NewsImages();
            DirectoryInfo dic = new DirectoryInfo(Server.MapPath(folder));
            if (dic.Exists)
            {
                var imgs = dic.GetFiles();
                List<string> imgPath = new List<string>();
                foreach (var item in imgs)
                {
                    imgPath.Add(Path.Combine(id.ToString(), item.Name).BaseRouts_NewsImages());
                }
                ViewBag.images = imgPath;
            }
            return View();
        }
        [HttpPost, ActionName("NewsImagesGallery")]
        public ActionResult NewsImagesGalleryPost(int id)
        {
            ViewBag.images = new List<string>();

            string folder = id.ToString().BaseRouts_NewsImages();
            DirectoryInfo dic = new DirectoryInfo(Server.MapPath(folder));

            if (ModelState.IsValid)
            {
                if (!dic.Exists)
                    dic.Create();
                long namitem = DateTime.Now.Ticks;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    if (Request.Files[i].ContentType.ContentTypeIsImage())
                    {
                        Request.Files[i].SaveAs(Server.MapPath(Path.Combine(folder, string.Format("{0:000000}{1}", namitem++, Request.Files[i].FileName.Substring(Request.Files[i].FileName.LastIndexOf('.'))))));
                    }
                }
            }

            if (dic.Exists)
            {
                var imgs = dic.GetFiles();
                List<string> imgPath = new List<string>();
                foreach (var item in imgs)
                {
                    imgPath.Add(Path.Combine(id.ToString(), item.Name).BaseRouts_NewsImages());
                }
                ViewBag.images = imgPath;
            }
            return RedirectToAction("NewsImagesGallery", new { id = id });
        }
        public ActionResult NewsImagesGalleryRemove(int id, string filename)
        {
            var file = new FileInfo(Server.MapPath(filename));
            if (file.Exists)
                file.Delete();

            return RedirectToAction("NewsImagesGallery", new { id = id });
        }



        public ActionResult Update_Publish(int? Id)
        {
            var model = new Models.News.Newsmodel(Id);
            Session["ContentsUpdate"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult Update_Publish(Models.News.Newsmodel model)
        {
            if (ModelState.IsValid)
            {
                var m = Session["ContentsUpdate"] as Models.News.Newsmodel;
                TryUpdateModel(m);
                m.Update();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult News_Delete(int id)
        {
            if (id > 0)
            {
                DBS.Contents.Remove(DBS.Contents.FirstOrDefault(c => c.ContenstId == id));
                DBS.SaveChanges();
                string folder = id.ToString().BaseRouts_NewsImages();
                DirectoryInfo dic = new DirectoryInfo(Server.MapPath(folder));
                if (dic.Exists)
                    dic.Delete(true);
            }

            return RedirectToAction("Index", "News");
        }

        public ActionResult Categories(int? Id)
        {
            var model = new Models.News.CategoryModel();
            if (Id != null && Id > 0)
            {
                model.Category.ParentId = Id;
                model.Category.ContentsCategory2 = DBS.ContentsCategories.FirstOrDefault(c => c.ContentsCategoryId == Id);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Categories(Models.News.CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                model.Save();
                return RedirectToAction("Categories");
            }
            return View(model);
        }

        public ActionResult Categories_Update(int? Id)
        {
            var model = new Models.News.CategoryModel(Id);
            TempData["CategoryModelUpdateItem"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult Categories_Update(Models.News.CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var mo = TempData["CategoryModelUpdateItem"] as Models.News.CategoryModel;
                TryUpdateModel(mo);
                mo.DBS.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Categories_delete(int? ContentCategoryId, int? type)
        {
            var node = DBS.ContentsCategories.FirstOrDefault(c => c.ContentsCategoryId == ContentCategoryId);
            if (node != null)
            {
                if (type != null && type == 0)
                {
                    foreach (var item in DBS.ContentsCategories.Where(cc => cc.ParentId == node.ContentsCategoryId))
                    {
                        item.ParentId = node.ParentId;
                    }
                    DBS.ContentsCategories.Remove(node);
                }
                else if (type != null && type == 1)
                {
                    DBS.ContentsCategories.RemoveRange(DBS.ContentsCategories.Where(cc => cc.ParentId == node.ContentsCategoryId));
                    DBS.ContentsCategories.Remove(node);
                }

                DBS.SaveChanges();
            }

            return RedirectToAction("Categories");
        }




        #region ContentUserComments
        public ActionResult ContentUserComments()
        {
            return View();
        }

        public ActionResult ContentUserComments_ShowAndReply(int? id)
        {
            var comment = DBS.ContentUserComments.FirstOrDefault(c => c.ContentUserCommentsId == id);
            if (comment == null)
                return RedirectToAction("ContentUserComments");

            return View(model: comment);
        }
        [HttpPost]
        public ActionResult ContentUserComments_ShowAndReply(int? id, string comment)
        {
            var mdlcomment = DBS.ContentUserComments.FirstOrDefault(c => c.ContentUserCommentsId == id);
            if (mdlcomment == null)
                return RedirectToAction("ContentUserComments");

            if (comment.IsNullOrWhiteSpace())
                ModelState.AddModelError("comment", "پیام نمیتواند خالی باشد");

            if (ModelState.IsValid)
            {
                var newitem = DBS.ContentUserComments.Add(new DBSEF.ContentUserComment
                {
                    Comment = comment,
                    DateTime = DateTime.Now,
                    ContenstId = mdlcomment.ContenstId,
                    RootContentUserCommentsId = id
                });
                DBS.SaveChanges();

                return RedirectToAction("ContentUserComments_ShowAndReply", new { id = newitem.ContentUserCommentsId });
            }

            return View(model: mdlcomment);
        }
        #endregion
    }
}
