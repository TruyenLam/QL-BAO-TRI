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
    
    public partial class CMMS_ChungLoaiThietBi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CMMS_ChungLoaiThietBi()
        {
            this.CMMS_ThietBi = new HashSet<CMMS_ThietBi>();
        }
    
        public long ChungLoaiThietBiId { get; set; }
        public string MaChungLoai { get; set; }
        public string TenChungLoai { get; set; }
        public string MoTa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMMS_ThietBi> CMMS_ThietBi { get; set; }
    }
}
