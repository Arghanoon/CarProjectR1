using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Models.News
{
    public class Newsmodel : IValidatableObject
    {
        DBSEF.CarAutomationEntities DBS = new db.CarAutomationEntities();
        public db.Content Content { get; set; }
        public CategoryModel Category { get; set; }

        [AllowHtml]
        public string ContentHTML
        {
            get { return this.Content.ContentText; }
            set { this.Content.ContentText = value; }
        }

        public Newsmodel()
        {
            Content = new db.Content();
            Category = new CategoryModel();
            Category.DBS = this.DBS;
        }

        public Newsmodel(int? contentsId)
        {
            this.Content = DBS.Contents.FirstOrDefault(c => c.ContenstId == contentsId);
            this.Category = new CategoryModel(Content.ContentsCategoryId);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            return result;
        }

        public void Save()
        {
            this.Content.ContentsCategory = this.Category.Category;
            DBS.Contents.Add(Content);
            this.Content.Date = DateTime.Now;
            DBS.SaveChanges();
        }
        public void Update()
        {
            this.Content.LastUpdateDate = DateTime.Now;
            this.Content.ContentsCategory = this.Category.Category;
            DBS.SaveChanges();
        }
    }
}