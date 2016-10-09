using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarProject.Areas.Admin.Models.Store
{
    public class ServicesModel : IValidatableObject
    {

        public DBSEF.CarAutomationEntities DBS = new DBSEF.CarAutomationEntities();

        public DBSEF.AutoService Service { get; set; }
        public List<DBSEF.Product> Products { get; set; }

        public ServicesModel()
        {
            Service = new DBSEF.AutoService();
            Products = new List<DBSEF.Product>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            return result;
        }
    }
}