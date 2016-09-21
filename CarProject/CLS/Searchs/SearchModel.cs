using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarProject.CLS.Searchs
{
    public class SearchModel
    {
        public string[] brandname { get; set; }
        public string[] enginetype { get; set; }
        public string[] carusage { get; set; }
        public string[] carbodytype { get; set; }
        public string[] gearboxtype { get; set; }
        public string[] gearboxaxle { get; set; }
        public int[] enginecylandr { get; set; }
    }
}