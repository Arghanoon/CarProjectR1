using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db = CarProject.DBSEF;

namespace CarProject.Areas.Admin.Models.News
{
    public class Newsmodel : db.Content , IValidatableObject
    {
        [AllowHtml]
        public string ContentHTML
        {
            get { return this.ContentText; }
            set { this.ContentText = value; }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            return result;
        }
    }
}