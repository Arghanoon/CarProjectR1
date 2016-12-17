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
            client.Credentials = new NetworkCredential("info@khodroclinic.com", "rrfh7jzwqEpc4`D-");
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
            client.Credentials = new NetworkCredential("noreply@khodroclinic.com", "_e79G'$)/%wMuSK5");
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
            MailMessage message = new MailMessage();
            message.To.Add(new MailAddress(model.Person.PersonEmail));
            message.IsBodyHtml = true;

            var ActivationEmailContent = new Areas.Admin.Models.Dashboard.MailsMessage_Signup_SendActivationcode();
            ActivationEmailContent.Load();
            string messageBody = ActivationEmailContent.Message.Replace("[codeonly]", model.Person.User.ActiveRecoveryCode);
            messageBody = messageBody.Replace("[codelink]", string.Format("<a href=\"{0}\">{1}</a>", Url.Action("userActivation", "profile", new { ActiveCode = model.Person.User.ActiveRecoveryCode, User = model.Person.User.Uname }, Request.Url.Scheme), "لینک فعال سازی حساب کاربری"));

            messageBody = messageBody.Replace("[userfullname]", model.Person.PersonFirtstName + " " + model.Person.PersonLastName);
            messageBody = messageBody.Replace("[username]", model.Person.User.Uname);
            messageBody = messageBody.Replace("[password]", model.Password);

            messageBody = string.Format("<html><body>{0}</body></html>", messageBody);

            message.Body = messageBody.Replace("\n", "<br />");
            message.From = new MailAddress("info@khodroclinic.com", "خودرو کلینیک");


            this.SendMessage(message);
        }
    }
}