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
    
    public partial class CMMS_ChiTietPhieuBaoTri
    {
        public long MaSoPhieu { get; set; }
        public long ThietBi_CumThietBiId { get; set; }
        public long CumThietBi_BoPhanThietBiId { get; set; }
        public long BoPhanThietBi_LinhKienThietBiId { get; set; }
        public Nullable<long> HienTuongId { get; set; }
        public Nullable<long> NguyenNhanId { get; set; }
        public string GhiChuNguyenNhan { get; set; }
        public Nullable<long> GiaiPhapId { get; set; }
        public Nullable<long> NhanVienThucHienId { get; set; }
        public long ID { get; set; }
    }
}
