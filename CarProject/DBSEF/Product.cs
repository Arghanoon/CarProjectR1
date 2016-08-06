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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Baskets = new HashSet<Basket>();
            this.PersonProducts = new HashSet<PersonProduct>();
            this.ProductDiscounts = new HashSet<ProductDiscount>();
            this.ProductPrices = new HashSet<ProductPrice>();
            this.ProductStores = new HashSet<ProductStore>();
            this.TodaysSpecials = new HashSet<TodaysSpecial>();
        }
    
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> CarId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<double> ProductHeight { get; set; }
        public Nullable<double> ProductWidth { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<double> ProductWeight { get; set; }
        public Nullable<double> ProductLength { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual Car Car { get; set; }
        public virtual Category Category { get; set; }
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonProduct> PersonProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductStore> ProductStores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TodaysSpecial> TodaysSpecials { get; set; }
    }
}
