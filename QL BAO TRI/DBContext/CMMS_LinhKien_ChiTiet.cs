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
    
    public partial class CMMS_LinhKien_ChiTiet
    {
        public long LinhKienChiTietId { get; set; }
        public Nullable<long> BoPhanThietBi_LinhKienThietBiId { get; set; }
        public Nullable<long> DacTinhChiTietId { get; set; }
        public string GiaTri { get; set; }
    
        public virtual CMMS_BoPhanThietBi_LinhKienThietBi CMMS_BoPhanThietBi_LinhKienThietBi { get; set; }
        public virtual CMMS_DacTinhChiTiet CMMS_DacTinhChiTiet { get; set; }
    }
}