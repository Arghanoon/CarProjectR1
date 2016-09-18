using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using dbs = CarProject.DBSEF;


namespace CarProject.Areas.Admin.Models
{
    public class TroubleshootingClass
    {
        dbs.CarAutomationEntities dbc = new dbs.CarAutomationEntities();

        public dbs.Troubleshooting[] Troubleshootings { get; set; }
        public dbs.Troubleshooting Troubleshooting { get; set; }

        public TroubleshootingClass()
        {
            Troubleshooting = new dbs.Troubleshooting();
        }
        public TroubleshootingClass(Nullable<int> id)
        {
            Troubleshooting = dbc.Troubleshootings.FirstOrDefault(t => t.TroubleshootingId == id);
        }

        public void Save()
        {
            dbc.Troubleshootings.Add(Troubleshooting);
            var id = dbc.SaveChanges();
            
        }
        public void Update()
        {
            dbc.SaveChanges();
        }
        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Troubleshooting.Question))
                yield return new ValidationResult("سوال وارد نشده است", new string[] { "Troubleshooting.Question" });
            //if (string.IsNullOrWhiteSpace(Troubleshooting.Answer))
            //    yield return new ValidationResult("جواب وارد نشده است", new string[] { "Troubleshooting.Answer" });

            if (Troubleshooting.ServicePrice != null && Troubleshooting.ServicePrice > 0 && !(Troubleshooting.ProductId != null && Troubleshooting.ProductId > 0))
                yield return new ValidationResult("فقط در صورت تعیین قطعه امکان تعیین قیمت وجود دارد", new string[] { "Troubleshooting.ServicePrice" });
        }
    }
}