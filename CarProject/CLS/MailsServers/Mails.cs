using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Mail;

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
    }
}