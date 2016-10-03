using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CarProject.CLS;
using dbs = CarProject.DBSEF;


namespace CarProject.Areas.Admin.Models
{
    public class TroubleshootingClass
    {
        dbs.CarAutomationEntities dbc = new dbs.CarAutomationEntities();

        public dbs.Troubleshooting[] Troubls { get; set; }
        public dbs.Troubleshooting trb { get; set; }
        public TroubleShootModel[] Troubleshootings { get; set; }
        //public dbs.Troubleshooting[] Troubleshootings { get; set; }
        public TroubleShootModel Troubleshooting { get; set; }

        public TroubleshootingClass()
        {
            //Troubleshooting =new TroubleShootModel();
            trb = new dbs.Troubleshooting();
        }
        public TroubleshootingClass(Nullable<int> id)
        {
            trb = dbc.Troubleshootings.FirstOrDefault(t => t.TroubleshootingId == id);
            Troubleshooting = Troubleshootings.FirstOrDefault(t => t.TroubleshootingId == id);
        }

        public void Save()
        {
            //trb = Troubleshooting;
            dbc.Troubleshootings.Add(trb);
            
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