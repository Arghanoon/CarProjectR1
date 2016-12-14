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
    
    public partial class Basket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Basket()
        {
            this.BasketItems = new HashSet<BasketItem>();
        }
    
        public int BasketId { get; set; }
        public Nullable<byte> State { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<System.DateTime> DelivaryDate { get; set; }
        public Nullable<byte> PaymentType { get; set; }
        public Nullable<int> DelivaryTypeId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string BankCode { get; set; }
        public string LocalCode { get; set; }
        public Nullable<int> DiscountId { get; set; }
        public string ReciverFullname { get; set; }
        public string ReciverTell { get; set; }
        public string ReciverMobile { get; set; }
        public string ReciverAddress { get; set; }
        public string ReciverWorkplace { get; set; }
        public Nullable<int> DaysOfWeekId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BasketItem> BasketItems { get; set; }
        public virtual ProductsOrServicesDeliveryType ProductsOrServicesDeliveryType { get; set; }
        public virtual DaysOfWeek DaysOfWeek { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual User User { get; set; }
    }
}
