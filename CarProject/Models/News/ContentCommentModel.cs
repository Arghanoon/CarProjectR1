using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CarProject.App_extension;

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
            if (Comment.FullName.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("نا و نام خانوادگی وارد نشده است", new string[] { "Comment.FullName" }));
            if (Comment.Email.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("ایمیل وارد نشده است", new string[] { "Comment.Email" }));
            else if (!Comment.Email.String_IsEmail())
                res.Add(new ValidationResult("ایمیل وارد شده صحیح نیست", new string[] { "Comment.Email" }));
            if (Comment.Comment.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("متن پیام وارد نشده است", new string[] { "Comment.Comment" }));
            return res;
        }
    }
}