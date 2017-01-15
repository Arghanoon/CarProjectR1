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
    
    public partial class Content
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Content()
        {
            this.ContentUserComments = new HashSet<ContentUserComment>();
            this.ContetComments = new HashSet<ContetComment>();
            this.RootCarUserComments = new HashSet<RootCarUserComment>();
        }
    
        public int ContenstId { get; set; }
        public Nullable<int> ContentsCategoryId { get; set; }
        public string ContentSubject { get; set; }
        public string ContentDescribe { get; set; }
        public string ContentText { get; set; }
        public string VideoUrl { get; set; }
        public string ContentType { get; set; }
        public string tags { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
    
        public virtual ContentPresentation ContentPresentation { get; set; }
        public virtual ContentsCategory ContentsCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentUserComment> ContentUserComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContetComment> ContetComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RootCarUserComment> RootCarUserComments { get; set; }
    }
}
