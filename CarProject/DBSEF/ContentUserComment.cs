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
    
    public partial class ContentUserComment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContentUserComment()
        {
            this.ContentUserComments1 = new HashSet<ContentUserComment>();
        }
    
        public int ContentUserCommentsId { get; set; }
        public Nullable<int> ContenstId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public Nullable<int> RootContentUserCommentsId { get; set; }
    
        public virtual Content Content { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentUserComment> ContentUserComments1 { get; set; }
        public virtual ContentUserComment ContentUserComment1 { get; set; }
        public virtual User User { get; set; }
    }
}