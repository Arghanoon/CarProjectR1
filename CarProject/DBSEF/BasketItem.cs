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
    
    public partial class BasketItem
    {
        public int BasketItemId { get; set; }
        public Nullable<int> BasketId { get; set; }
        public Nullable<int> Id { get; set; }
        public Nullable<byte> Type { get; set; }
        public Nullable<int> Count { get; set; }
        public string ProductEachPrice { get; set; }
        public string ProductEachPaidPrice { get; set; }
        public string ToatoalPaidPrice { get; set; }
        public Nullable<byte> PriceFlag { get; set; }
        public Nullable<int> DiscountId { get; set; }
        public Nullable<bool> IsInUser { get; set; }
    
        public virtual Basket Basket { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
