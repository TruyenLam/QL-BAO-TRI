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
    
    public partial class CMMS_LoaiTaiLieuKyThuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CMMS_LoaiTaiLieuKyThuat()
        {
            this.CMMS_TaiLieuKyThuat_ThietBi = new HashSet<CMMS_TaiLieuKyThuat_ThietBi>();
        }
    
        public long LoaiTaiLieuKyThuatId { get; set; }
        public string MaLoaiTLKT { get; set; }
        public string TenLoaiTLKT { get; set; }
        public string MoTa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMMS_TaiLieuKyThuat_ThietBi> CMMS_TaiLieuKyThuat_ThietBi { get; set; }
    }
}
