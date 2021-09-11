using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CENA_FOODIE_API.Repository;
using CENA_FOODIE_API.Entities;
using CENA_FOODIE_API.Services;
using System.Globalization;

namespace CENA_FOODIE_API.Controllers
{
    [Authorize]
    [ApiController]
    public class ThiTruongController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("api/thi-truong/danh-sach-quoc-gia")]
        public JToken LayDanhSachQuocGia()
        {
            return ThiTruongRepository.MARKET_LAY_DANH_SACH_QUOC_GIA();
        }

        [HttpPost("api/thi-truong/gia-ca")]
        public JToken NhapGiaCaTrongNuoc([FromBody] dynamic[] danhSachNhap)
        {
            return ThiTruongRepository.MARKET_NHAP_THONG_TIN_GIA_CA_TRONG_NUOC(Ultility.MappingDynamicToT<GiaCa>(danhSachNhap));
        }

        [AllowAnonymous]
        [HttpGet("api/thi-truong/gia-ca")]
        public JToken LayGiaCaTrongNuoc(string ngay_lay_so_lieu)
        {
            DateTime ngay_chuan = DateTime.ParseExact(ngay_lay_so_lieu, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return ThiTruongRepository.MARKET_LAY_THONG_TIN_GIA_CA_TRONG_NUOC(ngay_chuan.ToString());
        }

        [AllowAnonymous]
        [HttpGet("api/thi-truong/gia-ca-theo-ngay")]
        public JToken LayGiaCaTrongNuocTheoNgay(string ngay_lay_so_lieu)
        {
            DateTime ngay_chuan = DateTime.ParseExact(ngay_lay_so_lieu, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return ThiTruongRepository.MARKET_LAY_THONG_TIN_GIA_CA_TRONG_NUOC_THEO_NGAY(ngay_chuan.ToString());
        }

        [HttpPost("api/thi-truong/gia-ca-quoc-te")]
        public JToken NhapGiaCaQuocTe([FromBody] dynamic[] danhSachNhap)
        {
            return ThiTruongRepository.MARKET_NHAP_THONG_TIN_GIA_CA_QUOC_TE(Ultility.MappingDynamicToT<GiaCa>(danhSachNhap));
        }

        [AllowAnonymous]
        [HttpGet("api/thi-truong/gia-ca-quoc-te")]
        public JToken LayGiaCaQuocTe(string ngay_lay_so_lieu)
        {
            DateTime ngay_chuan = DateTime.ParseExact(ngay_lay_so_lieu, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return ThiTruongRepository.MARKET_LAY_THONG_TIN_GIA_CA_QUOC_TE(ngay_chuan.ToString());
        }

        [AllowAnonymous]
        [HttpGet("api/thi-truong/gia-ca-quoc-te-theo-ngay")]
        public JToken LayGiaCaQuocTeTheoNgay(string ngay_lay_so_lieu)
        {
            DateTime ngay_chuan = DateTime.ParseExact(ngay_lay_so_lieu, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return ThiTruongRepository.MARKET_LAY_THONG_TIN_GIA_CA_QUOC_TE_THEO_NGAY(ngay_chuan.ToString());
        }

        [HttpPost("api/thi-truong/xuat-khau")]
        public JToken NhapThongTinXuatKhau(int thang, int nam, [FromBody] dynamic[] danhSachNhap)
        {
            return ThiTruongRepository.MARKET_NHAP_THONG_TIN_XUAT_KHAU(thang, nam, Ultility.MappingDynamicToT<XuatNhapKhau>(danhSachNhap));
        }
        
        [AllowAnonymous]
        [HttpGet("api/thi-truong/xuat-khau")]
        public JToken LayThongTinXuatKhau(int thang, int nam)
        {
            return ThiTruongRepository.MARKET_LAY_THONG_TIN_XUAT_KHAU(thang, nam);
        }

        [HttpPost("api/thi-truong/nhap-khau")]
        public JToken NhapThongTinNhapKhau(int thang, int nam, [FromBody] dynamic[] danhSachNhap)
        {
            return ThiTruongRepository.MARKET_NHAP_THONG_TIN_NHAP_KHAU(thang, nam, Ultility.MappingDynamicToT<XuatNhapKhau>(danhSachNhap));
        }

        [AllowAnonymous]
        [HttpGet("api/thi-truong/nhap-khau")]
        public JToken LayThongTinNhapKhau(int thang, int nam)
        {
            return ThiTruongRepository.MARKET_LAY_THONG_TIN_NHAP_KHAU(thang, nam);
        }

        [AllowAnonymous]
        [HttpGet("api/thi-truong/gia-ca-mot-san-pham")]
        public JToken LayGiaCaMotSanPham(int id_san_pham, bool trong_nuoc, int so_dong)
        {
            return ThiTruongRepository.MARKET_LAY_GIA_THEO_SAN_PHAM(id_san_pham, trong_nuoc, so_dong);
        }

        [AllowAnonymous]
        [HttpPost("api/thi-truong/gia-ca-tong-hop")]
        public JToken LayGiaCaTongHopTheoDong(int so_dong, [FromBody] dynamic[] danh_sach_ma_san_pham)
        {
            return ThiTruongRepository.MARKET_LAY_THONG_TIN_GIA_CA_TONG_HOP_THEO_DONG(so_dong, Ultility.MappingDynamicToT<DanhSachSanPham>(danh_sach_ma_san_pham));
        }

        [AllowAnonymous]
        [HttpGet("api/thi-truong/san-xuat")]
        public JToken LayThongTinSanXuat(int thang, int nam)
        {
            return ThiTruongRepository.MARKET_LAY_THONG_TIN_SAN_XUAT(thang, nam);
        }

        [HttpPost("api/thi-truong/san-xuat")]
        public JToken NhapThongTinSanXuat(int thang, int nam , [FromBody] dynamic[] danhSachNhap)
        {
            return ThiTruongRepository.MARKET_NHAP_THONG_TIN_SAN_XUAT(thang, nam, Ultility.MappingDynamicToT<SanXuat>(danhSachNhap));
        }

        [HttpPost("api/thi-truong/san-xuat/{id_san_xuat}")]
        public JToken NhapDoanhNghiepSanXuat(int id_san_xuat,[FromBody] dynamic[] danhSachNhap)
        {
            return ThiTruongRepository.BUSINESS_NHAP_DOANH_NGHIEP_SAN_XUAT(id_san_xuat, Ultility.MappingDynamicToT<ThongTinDoanhNghiep>(danhSachNhap));
        }

        [HttpPost("api/thi-truong/nhap-khau/{id_nhap_khau}")]
        public JToken NhapDoanhNghiepNhapKhau(int id_nhap_khau, [FromBody] dynamic[] danhSachNhap)
        {
            return ThiTruongRepository.BUSINESS_NHAP_DOANH_NGHIEP_NHAP_KHAU(id_nhap_khau, Ultility.MappingDynamicToT<ThongTinDoanhNghiep>(danhSachNhap));
        }

        [HttpPost("api/thi-truong/xuat-khau/{id_xuat_khau}")]
        public JToken NhapDoanhNghiepXuatKhau(int id_xuat_khau, [FromBody] dynamic[] danhSachNhap)
        {
            return ThiTruongRepository.BUSINESS_NHAP_DOANH_NGHIEP_XUAT_KHAU(id_xuat_khau, Ultility.MappingDynamicToT<ThongTinDoanhNghiep>(danhSachNhap));
        }

        [AllowAnonymous]
        [HttpPost("api/thi-truong/gia-ca-trong-khoang-thoi-gian")]
        public JToken LayGiaCaTongHopTrongKhoangThoiGian([FromBody] dynamic[] danh_sach_ma_san_pham, string tu_ngay, string den_ngay)
         {
            return ThiTruongRepository.MARKET_LAY_THONG_TIN_GIA_CA_TONG_HOP_TRONG_KHOANG_THOI_GIAN(Ultility.MappingDynamicToT<DanhSachSanPham>(danh_sach_ma_san_pham), tu_ngay, den_ngay);
        }
    }
}