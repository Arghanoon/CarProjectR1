using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db = CarProject.DBSEF;
using CarProject.App_extension;

namespace CarProject.Areas.Admin.Models.News
{
    public class Newsmodel : IValidatableObject
    {
        DBSEF.CarAutomationEntities DBS = new db.CarAutomationEntities();
        public db.Content Content { get; set; }
        public db.ContentPresentation ContentPresentation { get; set; }
        public db.ContentsCategory ContentsCategory { get; set; }
        public db.ContentsCategory Category { get { return DBS.ContentsCategories.FirstOrDefault(cc => cc.ContentsCategoryId == Content.ContentsCategoryId); } }

        [AllowHtml]
        public string ContentHTML
        {
            get { return this.Content.ContentText; }
            set { this.Content.ContentText = value; }
        }

        public Newsmodel()
        {
            Content = new db.Content();
            ContentsCategory = new db.ContentsCategory();
            ContentPresentation = new db.ContentPresentation();
        }

        public Newsmodel(int? contentsId)
        {
            this.Content = DBS.Contents.FirstOrDefault(c => c.ContenstId == contentsId);
            this.ContentPresentation = DBS.ContentPresentations.FirstOrDefault(c => c.ContentId == contentsId);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (Content.ContentSubject.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("موضوع تعیین نشده است", new string[] { "Content.ContentSubject" }));
            return result;
        }

        public void Save()
        {
            DBS.Contents.Add(Content);
            this.Content.Date = DateTime.Now;
            DBS.SaveChanges();
        }
        public void Update()
        {
            this.Content.LastUpdateDate = DateTime.Now;
            DBS.SaveChanges();
        }
    }
}