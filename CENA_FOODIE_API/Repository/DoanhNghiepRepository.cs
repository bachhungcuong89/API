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

namespace CENA_FOODIE_API.Repository
{
    public class DoanhNghiepRepository
    {

        public static JToken BUSINESS_LAY_DANH_SACH_DOANH_NGHIEP()
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                var response = baseSQL.GetList("BUSINESS_LAY_DANH_SACH_DOANH_NGHIEP", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_LAY_THONG_TIN_DOANH_NGHIEP(string ma_doanh_nghiep)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_MA_DOANH_NGHIEP", ma_doanh_nghiep);
                var response = baseSQL.GetList("BUSINESS_LAY_THONG_TIN_DOANH_NGHIEP", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_TOP_SAN_XUAT(int ma_san_pham, int thang, int nam)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_MA_SAN_PHAM", ma_san_pham);
                param.Add("P_THANG", thang);
                param.Add("P_NAM", nam);
                var response = baseSQL.GetList("BUSINESS_TOP_SAN_XUAT", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_TOP_NHAP_KHAU(int ma_san_pham, int thang, int nam)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_MA_SAN_PHAM", ma_san_pham);
                param.Add("P_THANG", thang);
                param.Add("P_NAM", nam);
                var response = baseSQL.GetList("BUSINESS_TOP_NHAP_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_TOP_XUAT_KHAU(int ma_san_pham, int thang, int nam)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_MA_SAN_PHAM", ma_san_pham);
                param.Add("P_THANG", thang);
                param.Add("P_NAM", nam);
                var response = baseSQL.GetList("BUSINESS_TOP_XUAT_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_CAP_NHAT_THONG_TIN(string ma_doanh_nghiep, DoanhNghiep doanh_nghiep)
        {
            ResponseExecute response = new ResponseExecute();
            if (ma_doanh_nghiep != doanh_nghiep.mst)
            {
                response.SetError("Lỗi đã xảy ra");
                return JsonHelper.ToJson(response);
            }

            using (var baseSQL = new BaseSQL())
            {
                List<DoanhNghiep> dn = new List<DoanhNghiep>();
                dn.Add(doanh_nghiep);
                var param = new SQLDynamicParameters();
                param.Add("P_MA_DOANH_NGHIEP", ma_doanh_nghiep, SqlDbType.NVarChar);
                param.Add("P_DOANH_NGHIEP", Ultility.CreateDataTable<DoanhNghiep>(dn), SqlDbType.Structured);
                response = baseSQL.Execute("BUSINESS_CAP_NHAT_THONG_TIN", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_LAY_DANH_SACH_CO_SO_TRUC_THUOC(string ma_doanh_nghiep)
        {
            ResponseList response = new ResponseList();
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_MA_DOANH_NGHIEP", ma_doanh_nghiep, SqlDbType.NVarChar);
                response = baseSQL.GetList("BUSINESS_LAY_DANH_SACH_CO_SO_TRUC_THUOC", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_CAP_NHAT_CO_SO_TRUC_THUOC(string ma_doanh_nghiep, List<CoSoTrucThuoc> co_so_truc_thuoc)
        {
            ResponseList response = new ResponseList();
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_MA_DOANH_NGHIEP", ma_doanh_nghiep, SqlDbType.NVarChar);
                param.Add("P_DANH_SACH", Ultility.CreateDataTable<CoSoTrucThuoc>(co_so_truc_thuoc), SqlDbType.Structured);
                response = baseSQL.GetList("BUSINESS_CAP_NHAT_CO_SO_TRUC_THUOC", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken VIEW_THONG_TIN_DOANH_NGHIEP()
        {
            ResponseList response = new ResponseList();
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                response = baseSQL.GetMultipleTables("VIEW_THONG_TIN_DOANH_NGHIEP", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_LAY_KIM_NGACH_NHAP_KHAU(string ma_doanh_nghiep, int report_mode, int year, int period)
        {
            ResponseList response = new ResponseList();
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_MA_DOANH_NGHIEP", ma_doanh_nghiep, SqlDbType.NVarChar);
                param.Add("P_REPORT_MODE", report_mode, SqlDbType.Int);
                param.Add("P_YEAR", year, SqlDbType.Int);
                param.Add("P_PERIOD", period, SqlDbType.Int);
                response = baseSQL.GetList("BUSINESS_LAY_KIM_NGACH_NHAP_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_KHAI_BAO_KN_NHAP_KHAU(string ma_doanh_nghiep, int report_mode, int year, int period, bool is_sct, List<KimNgachXNK> data)
        {
            ResponseExecute response = new ResponseExecute();
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_MST", ma_doanh_nghiep, SqlDbType.NVarChar);
                param.Add("P_REPORT_MODE", report_mode, SqlDbType.Int);
                param.Add("P_YEAR", year, SqlDbType.Int);
                param.Add("P_PERIOD", period, SqlDbType.Int);
                param.Add("P_SCT_NHAP", is_sct, SqlDbType.Bit);
                param.Add("P_DANH_SACH", Ultility.CreateDataTable<KimNgachXNK>(data), SqlDbType.Structured);
                response = baseSQL.Execute("BUSINESS_KHAI_BAO_KN_NHAP_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_LAY_KIM_NGACH_XUAT_KHAU(string ma_doanh_nghiep, int report_mode, int year, int period)
        {
            ResponseList response = new ResponseList();
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_MA_DOANH_NGHIEP", ma_doanh_nghiep, SqlDbType.NVarChar);
                param.Add("P_REPORT_MODE", report_mode, SqlDbType.Int);
                param.Add("P_YEAR", year, SqlDbType.Int);
                param.Add("P_PERIOD", period, SqlDbType.Int);
                response = baseSQL.GetList("BUSINESS_LAY_KIM_NGACH_XUAT_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BUSINESS_KHAI_BAO_KN_XUAT_KHAU(string ma_doanh_nghiep, int report_mode, int year, int period, bool is_sct, List<KimNgachXNK> data)
        {
            ResponseExecute response = new ResponseExecute();
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_MST", ma_doanh_nghiep, SqlDbType.NVarChar);
                param.Add("P_REPORT_MODE", report_mode, SqlDbType.Int);
                param.Add("P_YEAR", year, SqlDbType.Int);
                param.Add("P_PERIOD", period, SqlDbType.Int);
                param.Add("P_SCT_NHAP", is_sct, SqlDbType.Bit);
                param.Add("P_DANH_SACH", Ultility.CreateDataTable<KimNgachXNK>(data), SqlDbType.Structured);
                response = baseSQL.Execute("BUSINESS_KHAI_BAO_KN_XUAT_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }
    }
}
