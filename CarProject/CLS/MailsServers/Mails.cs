using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace CarProject.CLS.MailsServers
{
    public interface IMails
    {
        SmtpClient Client { get; }
        void SendMessage(MailMessage message);

    }

    public class Mail_info : IMails
    {
        private SmtpClient client = new SmtpClient();
        public Mail_info()
        {
            client = new SmtpClient("mail.khodroclinic.com");
            client.Credentials = new NetworkCredential("noreply@khodroclinic.com", "yT9=')FKFxNet!6`");
        }
        public SmtpClient Client
        {
            get { return client; }
        }

        public void SendMessage(MailMessage message)
        {
            client.Send(message);
        }
    }

    public class Mail_noreply : IMails
    {
        private SmtpClient client = new SmtpClient();
        public Mail_noreply()
        {
            client = new SmtpClient("mail.khodroclinic.com");
            client.Credentials = new NetworkCredential("noreply@khodroclinic.com", "yT9=')FKFxNet!6`");
        }
        public SmtpClient Client
        {
            get { return client; }
        }

        public void SendMessage(MailMessage message)
        {
            client.Send(message);
        }

        public void SendUserActivationMail(Models.User.UserInfo model, UrlHelper Url, HttpRequestBase Request)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress(model.Person.PersonEmail));
                message.IsBodyHtml = true;

                var ActivationEmailContent = new Areas.Admin.Models.Dashboard.MailsMessage_Signup_SendActivationcode();
                ActivationEmailContent.Load();
                string messageBody = ActivationEmailContent.Message.Replace("[codeonly]", model.Person.User.ActiveRecoveryCode);
                messageBody = messageBody.Replace("[codelink]", string.Format("<a href=\"{0}\">{1}</a>", Url.Action("userActivation", "profile", new { ActiveCode = model.Person.User.ActiveRecoveryCode, User = model.Person.User.Uname }, Request.Url.Scheme), "لینک فعال سازی حساب کاربری"));
                messageBody = messageBody.Replace("[urlLink]", string.Format("{0}", Url.Action("userActivation", "profile", new { ActiveCode = model.Person.User.ActiveRecoveryCode, User = model.Person.User.Uname }, Request.Url.Scheme)));

                messageBody = messageBody.Replace("[userfullname]", model.Person.PersonFirtstName + " " + model.Person.PersonLastName);
                messageBody = messageBody.Replace("[username]", model.Person.User.Uname);
                messageBody = messageBody.Replace("[password]", model.Password);

                messageBody = string.Format("<html><body>{0}</body></html>", messageBody);
                message.Subject = "ایمیلی از طرف سایت خودرو کلینیک";
                    
                message.Body = messageBody.Replace("\n", "<br />");
                message.From = new MailAddress("noreply@khodroclinic.com", "خودرو کلینیک");

                message.BodyEncoding = System.Text.Encoding.UTF8;
                
                this.SendMessage(message);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void SendUserRecoveryMail(Models.User.UserInfo model, UrlHelper Url, HttpRequestBase Request)
        {
            try
            {

                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress(model.Person.PersonEmail));
                message.IsBodyHtml = true;

                var ActivationEmailContent = new Areas.Admin.Models.Dashboard.MailsMessage_Signup_RecoveryKey();
                ActivationEmailContent.Load();
                string messageBody = ActivationEmailContent.Message.Replace("[codeonly]", model.Person.User.ActiveRecoveryCode);
                messageBody = messageBody.Replace("[codelink]", string.Format("<a href=\"{0}\">{1}</a>", Url.Action("UserRecoveryPassword", "profile", new { activeationcode = model.Person.User.ActiveRecoveryCode, user = model.Person.User.Uname }, Request.Url.Scheme), "لینک فعال سازی حساب کاربری"));
                messageBody = messageBody.Replace("[urlLink]", string.Format("{0}", Url.Action("UserRecoveryPassword", "profile", new { activeationcode = model.Person.User.ActiveRecoveryCode, user = model.Person.User.Uname }, Request.Url.Scheme)));

                messageBody = messageBody.Replace("[userfullname]", model.Person.PersonFirtstName + " " + model.Person.PersonLastName);
                messageBody = messageBody.Replace("[username]", model.Person.User.Uname);
                messageBody = messageBody.Replace("[password]", model.Password);

                messageBody = string.Format("<html><body>{0}</body></html>", messageBody);
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Body = messageBody.Replace("\n", "<br />");
                message.From = new MailAddress("noreply@khodroclinic.com", "خودرو کلینیک");
                message.Subject = "ایمیلی از طرف سایت خودرو کلینیک";

                this.SendMessage(message);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public class Mail_marketing : IMails
    {
        private SmtpClient client = new SmtpClient();
        public Mail_marketing()
        {
            client = new SmtpClient("mail.khodroclinic.com");
            client.Credentials = new NetworkCredential("marketing@khodroclinic.com", "'>F<>p%~f44U@suJ");
        }
        public SmtpClient Client
        {
            get { return client; }
        }

        public void SendMessage(MailMessage message)
        {
            client.Send(message);
        }
    }
}