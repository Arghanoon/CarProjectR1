using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarProject.DBSEF;

namespace CarProject.CLS
{
    public class TroubleShootModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TroubleShootModel()
        {
            this.Troubleshooting1 = new HashSet<Troubleshooting>();
        }

        public int TroubleshootingId { get; set; }
        public string Question { get; set; }
        public string QQuestion { get; set; }
        public string AnswerYes { get; set; }
        public string AnswerNo { get; set; }
        public string Answer { get; set; }
        public Nullable<bool> AnswerYesOrNo { get; set; }
        public Nullable<bool> HasFather { get; set; }
        public Nullable<int> FatherId { get; set; }
        public Nullable<bool> HasProduct { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> ServicePrice { get; set; }

        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Troubleshooting> Troubleshooting1 { get; set; }
        public virtual Troubleshooting Troubleshooting2 { get; set; }
    }
}