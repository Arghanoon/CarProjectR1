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
        [AllowHtml]
        public string ContentHTML
        {
            get { return this.Content.ContentText; }
            set { this.Content.ContentText = value; }
        }

        public Newsmodel()
        {
        }

        public Newsmodel(int? contentsId)
        {
            this.Content = DBS.Contents.FirstOrDefault(c => c.ContenstId == contentsId);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            return result;
        }

        public void Save()
        {
            DBS.Contents.Add(Content);
            DBS.SaveChanges();
        }
        public void Update()
        {
            DBS.SaveChanges();
        }
    }
}