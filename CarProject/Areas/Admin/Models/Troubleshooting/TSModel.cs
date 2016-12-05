using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CarProject.App_extension;

namespace CarProject.Areas.Admin.Models.Troubleshooting
{
    public class TSModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();
        public DBSEF.Troubleshooting Troubleshooting { get; set; }

        public enum TroubleshootingType { Question = 0, Answer = 1 };

        public TroubleshootingType ModelType { get; set; }

        public List<int> Products { get; set; }

        public TSModel()
        {
            Troubleshooting = new DBSEF.Troubleshooting();
            ModelType = TroubleshootingType.Question;
            Products = new List<int>();
        }

        public TSModel(int? id)
        {
            Troubleshooting = dbs.Troubleshootings.FirstOrDefault(t => t.TroubleshootingId == id);
            if (Troubleshooting == null)
                Troubleshooting = new DBSEF.Troubleshooting();

            Products = new List<int>();
            if (Troubleshooting.Products != null)
            {
                foreach (var item in Troubleshooting.Products)
                {
                    Products.Add(item.ProductId);
                }
            }
        }

        public void Save()
        {
            foreach (var item in Products)
            {
                Troubleshooting.Products.Add(dbs.Products.FirstOrDefault(p => p.ProductId == item));
            }
            dbs.Troubleshootings.Add(Troubleshooting);
            dbs.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var res = new List<ValidationResult>();

            if (ModelType == TroubleshootingType.Question)
            {
                if (Troubleshooting.Subject.IsNullOrWhiteSpace())
                    res.Add(new ValidationResult("عنوان سوال تعیین نشده است", new string[] { "Troubleshooting.Subject" }));

            }
            else
            {
                if (Troubleshooting.Subject.IsNullOrWhiteSpace())
                    res.Add(new ValidationResult("جواب مختصر تعیین نشده است", new string[] { "Troubleshooting.Subject" }));
                if (Troubleshooting.Price.IsNullOrWhiteSpace())
                    res.Add(new ValidationResult("هزینه تعمیرات / رفغ عیب تعیین نشده است", new string[] { "Troubleshooting.Price" }));
                if(!Troubleshooting.Price.IsNumber())
                    res.Add(new ValidationResult("مقدار وارد شده صحیح نیست", new string[] { "Troubleshooting.Price" }));
            }
            return res;
        }
    }
}