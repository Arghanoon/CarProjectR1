//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarProject.DBSEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class AirConditioningSystem
    {
        public int AirConditioningSystemId { get; set; }
        public Nullable<int> CarId { get; set; }
        public string ReservedOne { get; set; }
        public string AirConditioningType { get; set; }
        public string column1 { get; set; }
        public string column2 { get; set; }
        public string column3 { get; set; }
        public string column4 { get; set; }
        public string column5 { get; set; }
        public string Details { get; set; }
    
        public virtual Car Car { get; set; }
    }
}