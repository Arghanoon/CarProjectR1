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
    
    public partial class ProductComment
    {
        public int ProductCommentId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<bool> canshow { get; set; }
        public Nullable<System.DateTime> datetime { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}