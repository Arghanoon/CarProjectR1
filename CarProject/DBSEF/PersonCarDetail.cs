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
    
    public partial class PersonCarDetail
    {
        public int PersonCarDetailId { get; set; }
        public Nullable<int> PersonCarId { get; set; }
        public Nullable<System.DateTime> LastOilChange { get; set; }
        public Nullable<System.DateTime> LastOilFiltersChange { get; set; }
        public Nullable<int> LastOilChangeMilage { get; set; }
        public Nullable<int> LastOilFilterChangeMilage { get; set; }
        public Nullable<System.DateTime> LastGearBoxOilChange { get; set; }
        public Nullable<int> LastGearBoxOilChangeMilage { get; set; }
        public Nullable<System.DateTime> LastAirFilterChange { get; set; }
        public Nullable<int> LastAirFilterChangeMilage { get; set; }
        public Nullable<System.DateTime> LastTiresChange { get; set; }
        public Nullable<int> LastTiresChangeMilage { get; set; }
        public Nullable<System.DateTime> LastTimingbeltChange { get; set; }
        public Nullable<int> LastTimingbeltChangeMilage { get; set; }
        public Nullable<System.DateTime> LastOtherBeltsChange { get; set; }
        public Nullable<int> LastOtherBeltsChangeMilage { get; set; }
        public Nullable<System.DateTime> LastFrontBrakePadsChange { get; set; }
        public Nullable<int> LastFrontBrakePadsChangeMilage { get; set; }
        public Nullable<System.DateTime> LastRearBreakePadsChange { get; set; }
        public Nullable<int> LastRearBrakePadsChangeMilage { get; set; }
        public Nullable<System.DateTime> DateSubmited { get; set; }
    
        public virtual PersonCar PersonCar { get; set; }
    }
}
