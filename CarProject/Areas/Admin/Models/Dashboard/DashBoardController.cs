using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using System.IO;


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

    public class MySerializer
    {
        public void SaveXml(string filelocation, object instance)
        {
            using (FileStream fs = new FileStream(filelocation, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
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


        public void Save()
        {
            DBS.SlideShows.Add(this.SlideShow);
            DBS.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();


            return result;
        }
    }

}