//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_BAO_TRI.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class CMMS_BoPhanThietBi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CMMS_BoPhanThietBi()
        {
            this.CMMS_CumThietBi_BoPhanThietBi = new HashSet<CMMS_CumThietBi_BoPhanThietBi>();
        }
    
        public long BoPhanThietBiId { get; set; }
        public string MaBoPhanThietBi { get; set; }
        public string TenBoPhanThietBi { get; set; }
        public string MoTa { get; set; }
        public Nullable<long> VatTuId { get; set; }
        public Nullable<System.DateTime> ThoiGianThayThe { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMMS_CumThietBi_BoPhanThietBi> CMMS_CumThietBi_BoPhanThietBi { get; set; }
    }
}
