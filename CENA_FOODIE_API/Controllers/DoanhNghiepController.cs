using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CENA_FOODIE_API.Repository;
using Microsoft.Extensions.Primitives;
using CENA_FOODIE_API.Entities;

namespace CENA_FOODIE_API.Controllers
{
    [Authorize]
    [ApiController]
    public class DoanhNghiepController : ControllerBase
    {

        [AllowAnonymous]
        [HttpGet("api/doanh-nghiep/danh-sach-doanh-nghiep")]
        public JToken DanhSachDoanhNghiep()
        {
            return DoanhNghiepRepository.BUSINESS_LAY_DANH_SACH_DOANH_NGHIEP();
        }

        [AllowAnonymous]
        [HttpGet("api/doanh-nghiep/thong-tin-doanh-nghiep")]
        public JToken ThongTinDoanhNghiep(string ma_doanh_nghiep)
        {
            return DoanhNghiepRepository.BUSINESS_LAY_THONG_TIN_DOANH_NGHIEP(ma_doanh_nghiep);
        }

        [AllowAnonymous]
        [HttpGet("api/doanh-nghiep/top-xuat-khau")]
        public JToken DoanhNghiepTopXuatKhau(int ma_san_pham, int thang, int nam)
        {
            return DoanhNghiepRepository.BUSINESS_TOP_XUAT_KHAU(ma_san_pham, thang, nam);
        }

        [AllowAnonymous]
        [HttpGet("api/doanh-nghiep/top-nhap-khau")]
        public JToken DoanhNghiepTopNhauKhau(int ma_san_pham, int thang, int nam)
        {
            return DoanhNghiepRepository.BUSINESS_TOP_NHAP_KHAU(ma_san_pham, thang, nam);
        }

        [AllowAnonymous]
        [HttpGet("api/doanh-nghiep/top-san-xuat")]
        public JToken DoanhNghiepTopSanXuat(int ma_san_pham, int thang, int nam)
        {
            return DoanhNghiepRepository.BUSINESS_TOP_SAN_XUAT(ma_san_pham, thang, nam);
        }

        [AllowAnonymous]
        [HttpPost("api/doanh-nghiep/thong-tin-doanh-nghiep")]
        public JToken SuaThongTinDoanhNghiep(string ma_doanh_nghiep, [FromBody] DoanhNghiep doanh_nghiep)
        {
            return DoanhNghiepRepository.BUSINESS_CAP_NHAT_THONG_TIN(ma_doanh_nghiep, doanh_nghiep);
        }

        [AllowAnonymous]
        [HttpGet("api/doanh-nghiep/co-so-truc-thuoc")]
        public JToken CoSoTrucThuoc(string ma_doanh_nghiep)
        {
            return DoanhNghiepRepository.BUSINESS_LAY_DANH_SACH_CO_SO_TRUC_THUOC(ma_doanh_nghiep);
        }

        [HttpPost("api/doanh-nghiep/co-so-truc-thuoc")]
        public JToken CapNhatCoSoTrucThuoc(string ma_doanh_nghiep, [FromBody] List<CoSoTrucThuoc> co_so_truc_thuoc)
        {
            return DoanhNghiepRepository.BUSINESS_CAP_NHAT_CO_SO_TRUC_THUOC(ma_doanh_nghiep, co_so_truc_thuoc);
        }

        [AllowAnonymous]
        [HttpGet("api/doanh-nghiep/kim-ngach-nhap-khau")]
        public JToken LayKimNgachNhapKhau(string ma_doanh_nghiep, int report_mode, int year, int period)
        {
            return DoanhNghiepRepository.BUSINESS_LAY_KIM_NGACH_NHAP_KHAU(ma_doanh_nghiep, report_mode,year, period);
        }

        [HttpPost("api/doanh-nghiep/kim-ngach-nhap-khau")]
        public JToken NhapKimNgachNhapKhau(string ma_doanh_nghiep, int report_mode, int year, int period, bool is_sct, [FromBody] List<KimNgachXNK> kim_ngach_nhap_khau)
        {
            return DoanhNghiepRepository.BUSINESS_KHAI_BAO_KN_NHAP_KHAU(ma_doanh_nghiep, report_mode, year, period, is_sct , kim_ngach_nhap_khau);
        }

        [AllowAnonymous]
        [HttpGet("api/doanh-nghiep/kim-ngach-xuat-khau")]
        public JToken LayKimNgachXuatKhau(string ma_doanh_nghiep, int report_mode, int year, int period)
        {
            return DoanhNghiepRepository.BUSINESS_LAY_KIM_NGACH_XUAT_KHAU(ma_doanh_nghiep, report_mode, year, period);
        }

        [HttpPost("api/doanh-nghiep/kim-ngach-xuat-khau")]
        public JToken NhapKimNgachXuatKhau(string ma_doanh_nghiep, int report_mode, int year, int period, bool is_sct, [FromBody] List<KimNgachXNK> kim_ngach_xuat_khau)
        {
            return DoanhNghiepRepository.BUSINESS_KHAI_BAO_KN_XUAT_KHAU(ma_doanh_nghiep, report_mode, year, period, is_sct, kim_ngach_xuat_khau);
        }

        [AllowAnonymous]
        [HttpGet("api/doanh-nghiep/thong-tin-hien-thi")]
        public JToken LayThongTinHienThi()
        {
            return DoanhNghiepRepository.VIEW_THONG_TIN_DOANH_NGHIEP();
        }
    }
}