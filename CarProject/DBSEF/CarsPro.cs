﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;

namespace CarProject.DBSEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarsPro
    {
        public int CarPsId { get; set; }
        
        public Nullable<int> CarsId { get; set; }
        public Nullable<bool> CarsProOrCro { get; set; }
        [DisplayName("محاسن است یا معایب ؟")]
        public string CarProCro { get; set; }
        [DisplayName("محاسن/معایب")]

        public virtual Car Car { get; set; }
    }
}
