using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarProject.App_extension;
using System.Net.Mail;

namespace CarProject.Areas.Admin.Models.Dashboard
{
    public class MailsMessage_Marketing_Model : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public List<int> Emails { get; set; }
        public string Subject { get; set; }
        [AllowHtml]
        public string MessageHtml { get; set; }

        public MailsMessage_Marketing_Model()
        {
            Emails = new List<int>();
        }

        public void SaveMessage()
        {
            var mm = new DBSEF.MarketingMail();
            mm.Recivers = string.Join("|", Emails);
            mm.Subject = Subject;
            mm.Body = MessageHtml;
            mm.DateTime = DateTime.Now;

            dbs.MarketingMails.Add(mm);
            dbs.SaveChanges();
        }

        public void SendMessage()
        {
            CLS.MailsServers.Mail_marketing mail = new CLS.MailsServers.Mail_marketing();
            
            foreach (var item in Emails)
            {
                var pr = dbs.People.FirstOrDefault(c => c.PersonId == item);
                if (pr != null && !pr.PersonEmail.IsNullOrWhiteSpace())
                {
                    MailMessage message = new MailMessage();

                    message.From = new MailAddress("marketing@khodroclinic.com");
                    message.To.Add(new MailAddress(pr.PersonEmail));

                    message.Subject = Subject;
                    message.Body = MessageHtml.Replace("\n", "<br />");
                    message.Sender = new MailAddress("marketing@khodroclinic.com", "مدیریت فروش خودروکلینیک");

                    mail.SendMessage(message);
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var res = new List<ValidationResult>();

            if (Emails.Count == 0)
                res.Add(new ValidationResult("دریافت کنندگان تعیین نشده است", new string[] { "Emails" }));
            
            if (Subject.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("موضوع پیام وارد نشده است", new string[] { "Subject" }));

            if (MessageHtml.IsNullOrWhiteSpace())
                res.Add(new ValidationResult("متن پیام وارد نشده است", new string[] { "MessageHtml" }));
            return res;
        }
    }
}