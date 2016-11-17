using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarProject.Models.News
{
    public class ContentCommentModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();

        public DBSEF.ContetComment Comment { get; set; }

        public ContentCommentModel()
        {
            Comment = new DBSEF.ContetComment();
        }

        public void Save()
        {
            DBS.ContetComments.Add(Comment);
            DBS.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var res = new List<ValidationResult>();

            return res;
        }
    }
}