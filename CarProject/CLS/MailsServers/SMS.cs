using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CarProject.sms_ws;

namespace CarProject.CLS.MailsServers
{
    public class SMS
    {
        public SmsPanelWebservice SmsPanel = new SmsPanelWebservice();
        string smsid = "0";
        int cash = 0;
        public void SendAsync(string username, string password, string src_number, string dst_number, string body)
        {
            smsid = SmsPanel.send_sms(username, password, new string[] { src_number }, new string[] { dst_number }, new string[] { body }, new string[] { "0" }, new string[] { DateTime.Now.Ticks.ToString() }, new string[] { "0" }, "ok")[0];

        }
    }
}