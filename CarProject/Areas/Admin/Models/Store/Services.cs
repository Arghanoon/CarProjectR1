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
        public List<int> Products { get; set; }
        public List<int> CarsId { get; set; }

        public ServicesModel()
        {
            Service = new DBSEF.AutoService();
            Products = new List<int>();
            CarsId = new List<int>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            return result;
        }
    }
}