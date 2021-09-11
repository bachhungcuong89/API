using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CENA_FOODIE_API.Model;
using CENA_FOODIE_API.Model.Response;
using CENA_FOODIE_API.Entities;
using CENA_FOODIE_API.Services;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace CENA_FOODIE_API.Repository
{
    public class ThiTruongRepository
    {
        public static JToken MARKET_LAY_DANH_SACH_QUOC_GIA()
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                var response = baseSQL.GetList("MARKET_LAY_DANH_SACH_QUOC_GIA", param);
                return JsonHelper.ToJson(response);
            }
        }
        public static JToken MARKET_NHAP_THONG_TIN_GIA_CA_TRONG_NUOC(GiaCa[] danhSachNhap)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_DANH_SACH", Ultility.CreateDataTable<GiaCa>(danhSachNhap), SqlDbType.Structured);
                var response = baseSQL.Execute("MARKET_NHAP_GIA_CA_TRONG_NUOC", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_LAY_THONG_TIN_GIA_CA_TRONG_NUOC(string ngay_lay_so_lieu)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_NGAY", ngay_lay_so_lieu, SqlDbType.Date);
                var response = baseSQL.GetList("MARKET_LAY_GIA_CA_TRONG_NUOC", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_LAY_THONG_TIN_GIA_CA_TRONG_NUOC_THEO_NGAY(string ngay_lay_so_lieu)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_NGAY", ngay_lay_so_lieu, SqlDbType.Date);
                var response = baseSQL.GetList("MARKET_LAY_GIA_CA_TRONG_NUOC_DUNG_NGAY", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_NHAP_THONG_TIN_GIA_CA_QUOC_TE(GiaCa[] danhSachNhap)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_DANH_SACH", Ultility.CreateDataTable<GiaCa>(danhSachNhap), SqlDbType.Structured);
                var response = baseSQL.Execute ("MARKET_NHAP_GIA_CA_QUOC_TE", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_LAY_THONG_TIN_GIA_CA_QUOC_TE(string ngay_lay_so_lieu)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_NGAY", ngay_lay_so_lieu, SqlDbType.Date);
                var response = baseSQL.GetList("MARKET_LAY_GIA_CA_QUOC_TE", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_LAY_THONG_TIN_GIA_CA_QUOC_TE_THEO_NGAY(string ngay_lay_so_lieu)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_NGAY", ngay_lay_so_lieu, SqlDbType.Date);
                var response = baseSQL.GetList("MARKET_LAY_GIA_CA_QUOC_TE_DUNG_NGAY", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_NHAP_THONG_TIN_XUAT_KHAU(int thang, int nam, XuatNhapKhau[] danhSachNhap)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_THANG", thang, SqlDbType.Int);
                param.Add("P_NAM", nam, SqlDbType.Int);
                param.Add("P_DANH_SACH", Ultility.CreateDataTable<XuatNhapKhau>(danhSachNhap), SqlDbType.Structured);
                var response = baseSQL.GetList("MARKET_NHAP_THONG_TIN_XUAT_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_LAY_THONG_TIN_XUAT_KHAU(int thang, int nam)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_THANG", thang, SqlDbType.Int);
                param.Add("P_NAM", nam, SqlDbType.Int);
                var response = baseSQL.GetList("MARKET_LAY_THONG_TIN_XUAT_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_NHAP_THONG_TIN_NHAP_KHAU(int thang, int nam, XuatNhapKhau[] danhSachNhap)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_THANG", thang, SqlDbType.Int);
                param.Add("P_NAM", nam, SqlDbType.Int);
                param.Add("P_DANH_SACH", Ultility.CreateDataTable<XuatNhapKhau>(danhSachNhap), SqlDbType.Structured);
                var response = baseSQL.GetList("MARKET_NHAP_THONG_TIN_NHAP_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_LAY_THONG_TIN_NHAP_KHAU(int thang, int nam)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_THANG", thang, SqlDbType.Int);
                param.Add("P_NAM", nam, SqlDbType.Int);
                var response = baseSQL.GetList("MARKET_LAY_THONG_TIN_NHAP_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_LAY_GIA_THEO_SAN_PHAM(int id_san_pham, bool trong_nuoc, int so_dong)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_ID_SAN_PHAM", id_san_pham, SqlDbType.Int);
                param.Add("P_TRONG_NUOC", trong_nuoc);
                param.Add("P_SO_DONG", so_dong, SqlDbType.Int);
                var response = baseSQL.GetList("MARKET_LAY_GIA_THEO_SAN_PHAM", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_LAY_THONG_TIN_GIA_CA_TONG_HOP_THEO_DONG(int so_dong, DanhSachSanPham[] danh_sach_ma_san_phan)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_SO_DONG", so_dong, SqlDbType.Int);
                param.Add("P_DANH_SACH_SAN_PHAM", Ultility.CreateDataTable<DanhSachSanPham>(danh_sach_ma_san_phan), SqlDbType.Structured);
                var response = baseSQL.GetMultipleTables("MARKET_LAY_THONG_TIN_GIA_CA_TONG_HOP_THEO_DONG", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_LAY_THONG_TIN_SAN_XUAT(int thang, int nam)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_THANG", thang, SqlDbType.Int);
                param.Add("P_NAM", nam, SqlDbType.Int);
                var response = baseSQL.GetList("MARKET_LAY_THONG_TIN_SAN_XUAT", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_NHAP_THONG_TIN_SAN_XUAT(int thang, int nam, SanXuat[] danhSachNhap)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_THANG", thang, SqlDbType.Int);
                param.Add("P_NAM", nam, SqlDbType.Int);
                param.Add("P_DANH_SACH", Ultility.CreateDataTable<SanXuat>(danhSachNhap), SqlDbType.Structured);
                var response = baseSQL.GetList("MARKET_NHAP_THONG_TIN_SAN_XUAT", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_NHAP_DOANH_NGHIEP_SAN_XUAT(int id_san_xuat, ThongTinDoanhNghiep[] danhSachNhap)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_ID_SAN_XUAT", id_san_xuat, SqlDbType.Int);
                param.Add("P_DANH_SACH", Ultility.CreateDataTable<ThongTinDoanhNghiep>(danhSachNhap), SqlDbType.Structured);
                var response = baseSQL.GetList("BUSINESS_NHAP_DOANH_NGHIEP_SAN_XUAT", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_NHAP_DOANH_NGHIEP_NHAP_KHAU(int id_nhap_khau, ThongTinDoanhNghiep[] danhSachNhap)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_ID_NHAP_KHAU", id_nhap_khau, SqlDbType.Int);
                param.Add("P_DANH_SACH", Ultility.CreateDataTable<ThongTinDoanhNghiep>(danhSachNhap), SqlDbType.Structured);
                var response = baseSQL.GetList("BUSINESS_NHAP_DOANH_NGHIEP_NHAP_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_NHAP_DOANH_NGHIEP_XUAT_KHAU(int id_xuat_khau, ThongTinDoanhNghiep[] danhSachNhap)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_ID_XUAT_KHAU", id_xuat_khau, SqlDbType.Int);
                param.Add("P_DANH_SACH", Ultility.CreateDataTable<ThongTinDoanhNghiep>(danhSachNhap), SqlDbType.Structured);
                var response = baseSQL.GetList("BUSINESS_NHAP_DOANH_NGHIEP_XUAT_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken MARKET_LAY_THONG_TIN_GIA_CA_TONG_HOP_TRONG_KHOANG_THOI_GIAN(DanhSachSanPham[] danh_sach_ma_san_phan, string tu_ngay, string den_ngay)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_DANH_SACH_SAN_PHAM", Ultility.CreateDataTable<DanhSachSanPham>(danh_sach_ma_san_phan), SqlDbType.Structured);
                param.Add("P_TU_NGAY", tu_ngay, SqlDbType.Date);
                param.Add("P_DEN_NGAY", den_ngay, SqlDbType.Date);
                var response = baseSQL.GetMultipleTables("MARKET_LAY_THONG_TIN_GIA_CA_TONG_HOP_TRONG_KHOANG_THOI_GIAN", param);
                return JsonHelper.ToJson(response);
            }
        }
    }
}
