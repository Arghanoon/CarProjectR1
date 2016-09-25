using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using db = CarProject.DBSEF;
using CarProject.App_extension;

namespace CarProject.Models.Home
{
    public class ContactUsMessageModel : IValidatableObject
    {
        db.CarAutomationEntities DBS = new db.CarAutomationEntities();
        public db.ContactUsMessage Message { get; set; }

        public ContactUsMessageModel()
        {
            Message = new db.ContactUsMessage();
        }

        public void Save()
        {
            this.Message.Date = DateTime.Now;
            DBS.ContactUsMessages.Add(this.Message);

            //Action For Send Email

            DBS.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (Message.FullName.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام و نام خانوادگی وارد نشده است", new string[] { "Message.FullName" }));

            if (Message.Subject.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("موضوع وارد نشده است", new string[] { "Message.Subject" }));

            if (Message.Message.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("پیام وارد نشده است", new string[] { "Message.Message" }));

            if (Message.Email.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("ایمیل وارد شده صحیح نیست", new string[] { "Message.Email" }));
            else if (!Message.Email.String_IsEmail())
                result.Add(new ValidationResult("ایمیل وارد شده صحیح نیست", new string[] { "Message.Email" }));

            return result;
        }
    }
}