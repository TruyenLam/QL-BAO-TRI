﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class THT_LEANERPEntities : DbContext
    {
        public THT_LEANERPEntities()
            : base("name=THT_LEANERPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CMMS_BaoCaoTonThatThoiGian> CMMS_BaoCaoTonThatThoiGian { get; set; }
        public virtual DbSet<CMMS_BoPhan_ChiTiet> CMMS_BoPhan_ChiTiet { get; set; }
        public virtual DbSet<CMMS_BoPhanThietBi> CMMS_BoPhanThietBi { get; set; }
        public virtual DbSet<CMMS_BoPhanThietBi_LinhKienThietBi> CMMS_BoPhanThietBi_LinhKienThietBi { get; set; }
        public virtual DbSet<CMMS_ChiTietPhieuBaoTri> CMMS_ChiTietPhieuBaoTri { get; set; }
        public virtual DbSet<CMMS_ChungLoaiThietBi> CMMS_ChungLoaiThietBi { get; set; }
        public virtual DbSet<CMMS_ChungLoaiThietBi_DacTinhThongSo> CMMS_ChungLoaiThietBi_DacTinhThongSo { get; set; }
        public virtual DbSet<CMMS_CongTyDichVu> CMMS_CongTyDichVu { get; set; }
        public virtual DbSet<CMMS_CumThietBi> CMMS_CumThietBi { get; set; }
        public virtual DbSet<CMMS_CumThietBi_BoPhanThietBi> CMMS_CumThietBi_BoPhanThietBi { get; set; }
        public virtual DbSet<CMMS_DacTinhChiTiet> CMMS_DacTinhChiTiet { get; set; }
        public virtual DbSet<CMMS_DacTinhThongSo> CMMS_DacTinhThongSo { get; set; }
        public virtual DbSet<CMMS_DanhMuCThongSoGiamSat> CMMS_DanhMuCThongSoGiamSat { get; set; }
        public virtual DbSet<CMMS_GiaiPhapBaoTri> CMMS_GiaiPhapBaoTri { get; set; }
        public virtual DbSet<CMMS_HienTuong> CMMS_HienTuong { get; set; }
        public virtual DbSet<CMMS_KetQuaDo_BoPhan> CMMS_KetQuaDo_BoPhan { get; set; }
        public virtual DbSet<CMMS_KhauHaoThietBi> CMMS_KhauHaoThietBi { get; set; }
        public virtual DbSet<CMMS_KhuVuc> CMMS_KhuVuc { get; set; }
        public virtual DbSet<CMMS_KhuVuc_ThietBi> CMMS_KhuVuc_ThietBi { get; set; }
        public virtual DbSet<CMMS_LinhKien_ChiTiet> CMMS_LinhKien_ChiTiet { get; set; }
        public virtual DbSet<CMMS_LinhKienThietBi> CMMS_LinhKienThietBi { get; set; }
        public virtual DbSet<CMMS_LoaiDichVu> CMMS_LoaiDichVu { get; set; }
        public virtual DbSet<CMMS_LoaiKhauHao> CMMS_LoaiKhauHao { get; set; }
        public virtual DbSet<CMMS_LoaiKhiemKhuyet> CMMS_LoaiKhiemKhuyet { get; set; }
        public virtual DbSet<CMMS_LoaiTaiLieuKyThuat> CMMS_LoaiTaiLieuKyThuat { get; set; }
        public virtual DbSet<CMMS_NguyenNhan> CMMS_NguyenNhan { get; set; }
        public virtual DbSet<CMMS_NhomThietBi> CMMS_NhomThietBi { get; set; }
        public virtual DbSet<CMMS_PhieuBaoTri> CMMS_PhieuBaoTri { get; set; }
        public virtual DbSet<CMMS_TaiLieuKyThuat_ThietBi> CMMS_TaiLieuKyThuat_ThietBi { get; set; }
        public virtual DbSet<CMMS_TheKhiemKhuyet> CMMS_TheKhiemKhuyet { get; set; }
        public virtual DbSet<CMMS_ThietBi> CMMS_ThietBi { get; set; }
        public virtual DbSet<CMMS_ThietBi_BoPhanQuanLy> CMMS_ThietBi_BoPhanQuanLy { get; set; }
        public virtual DbSet<CMMS_ThietBi_CongTyDichVu> CMMS_ThietBi_CongTyDichVu { get; set; }
        public virtual DbSet<CMMS_ThietBi_CumThietBi> CMMS_ThietBi_CumThietBi { get; set; }
        public virtual DbSet<CMMS_ThongSoBoPhan> CMMS_ThongSoBoPhan { get; set; }
        public virtual DbSet<CMMS_ThongSoDichVu> CMMS_ThongSoDichVu { get; set; }
        public virtual DbSet<CMMS_TrangThaiThietBi> CMMS_TrangThaiThietBi { get; set; }
    }
}
