using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using System.IO;
using CarProject.App_extension;


namespace CarProject.Areas.Admin.Models.Dashboard
{
    public abstract class Settings_infoBase : IValidatableObject
    {
        public abstract string FileLocation { get; }

        public string ShortDescribe { get; set; }
        [AllowHtml]
        public string Html { get; set; }
        public DateTime LastUpdate { get; set; }

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
        
    }
    public class AboutMe : Settings_infoBase
    {

        public override string FileLocation
        {
            get { return "~/Publics/Files/Settings/AboutMe.xml"; }
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            return result;
        }
    }

    public class ContactUs : Settings_infoBase
    {

        public override string FileLocation
        {
            get { return "~/Publics/Files/Settings/ContactUs.xml"; }
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();


            return result;
        }
    }

    public class MailsMessage_Signup_SendActivationcode : IValidatableObject
    {
        HttpContext Context { get; set; }
        public string FileLocation
        {
            get { return "~/Publics/Files/Settings/MailsMessage_Signup_SendActivationcode.xml"; }
        }

        public MailsMessage_Signup_SendActivationcode()
        {
            Context = HttpContext.Current;

           
        }
        [AllowHtml]
        public string Message { get; set; }

        public void Save()
        {
            MySerializer ms = new MySerializer();
            if (File.Exists(Context.Server.MapPath(FileLocation)))
                File.Delete(Context.Server.MapPath(FileLocation));

            ms.SaveXml(Context.Server.MapPath(FileLocation), this);
        }

        public void Load()
        {
            if (File.Exists(Context.Server.MapPath(FileLocation)))
            {
                MySerializer ms = new MySerializer();
                var obj = (MailsMessage_Signup_SendActivationcode)ms.LoadXml(Context.Server.MapPath(FileLocation), this.GetType());
                if (obj != null)
                {
                    this.Message = obj.Message;
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Message.IsNullOrWhiteSpace())
                yield return new ValidationResult("متن پیام خالی است", new string[] { "Message" });
            else if (!Message.Contains("[codelink]") && !Message.Contains("[codeonly]"))
                yield return new ValidationResult("متن پیام فاقد کد یا لنک فعال سازی است", new string[] { "Message" });
        }
    }

    public class MailsMessage_Signup_RecoveryKey : IValidatableObject
    {
        HttpContext Context { get; set; }
        public string FileLocation
        {
            get { return "~/Publics/Files/Settings/MailsMessage_Signup_RecoveryKey.xml"; }
        }

        public MailsMessage_Signup_RecoveryKey()
        {
            Context = HttpContext.Current;


        }
        [AllowHtml]
        public string Message { get; set; }

        public void Save()
        {
            MySerializer ms = new MySerializer();
            if (File.Exists(Context.Server.MapPath(FileLocation)))
                File.Delete(Context.Server.MapPath(FileLocation));

            ms.SaveXml(Context.Server.MapPath(FileLocation), this);
        }

        public void Load()
        {
            if (File.Exists(Context.Server.MapPath(FileLocation)))
            {
                MySerializer ms = new MySerializer();
                var obj = (MailsMessage_Signup_RecoveryKey)ms.LoadXml(Context.Server.MapPath(FileLocation), this.GetType());
                if (obj != null)
                {
                    this.Message = obj.Message;
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Message.IsNullOrWhiteSpace())
                yield return new ValidationResult("متن پیام خالی است", new string[] { "Message" });
            else if (!Message.Contains("[codelink]") && !Message.Contains("[codeonly]"))
                yield return new ValidationResult("متن پیام فاقد کد یا لنک فعال سازی است", new string[] { "Message" });
        }
    }

    public class MySerializer
    {
        public void SaveXml(string filelocation, object instance)
        {
            if (File.Exists(filelocation))
            {
                File.Delete(filelocation);
            }
           //FileStream fs1 = new FileStream(filelocation, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
            using (FileStream fs = new FileStream(filelocation, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
               // fs.SetLength(0);
                XmlSerializer xml = new XmlSerializer(instance.GetType());
                xml.Serialize(fs, instance);
                fs.Flush();
                fs.Close();
            }
        }

        public object LoadXml(string filelocation, Type objtype)
        {
            object result = null;
            if (System.IO.File.Exists(filelocation))
            {
                using (FileStream fs = new FileStream(filelocation, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    XmlSerializer xml = new XmlSerializer(objtype);
                    result = xml.Deserialize(fs);
                    fs.Flush();
                    fs.Close();
                }
            }
            return result;
        }
    }


    public class SlideShowModel : IValidatableObject
    {
        DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();

        public DBSEF.SlideShow SlideShow { get; set; }

        public SlideShowModel()
        {
            SlideShow = new DBSEF.SlideShow();
        }

        public SlideShowModel(int? Id)
        {
            SlideShow = DBS.SlideShows.FirstOrDefault(m => m.SlideShowId == Id);
        }

        public void Save()
        {
            DBS.SlideShows.Add(this.SlideShow);
            DBS.SaveChanges();
        }

        public void Update()
        {
            DBS.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (SlideShow.Type == null || SlideShow.Type < 1)
                result.Add(new ValidationResult("اسلاید شو تعیین نشده است", new string[] { "SlideShow.Type" }));
           
            return result;
        }
    }

}