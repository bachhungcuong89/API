using Microsoft.AspNetCore.Mvc;
using CENA_FOODIE_API.Model;
using CENA_FOODIE_API.Model.Response;
using CENA_FOODIE_API.Repository;
using CENA_FOODIE_API.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace API2.Repository
{
    public class BaoCaoRepository
    {
        public static JToken BAO_CAO_THANG_CAN_NHAP(int month, int year, int org_id)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_MONTH", month);
                param.Add("P_YEAR", year);
                param.Add("P_ORG_ID", org_id);
                var response = baseSQL.GetList("REPORT_BAO_CAO_THANG_CAN_NHAP", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BAO_CAO_QUY_CAN_NHAP(int quarter, int year, int org_id)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_QUARTER", quarter);
                param.Add("P_YEAR", year);
                param.Add("P_ORG_ID", org_id);
                var response = baseSQL.GetList("REPORT_BAO_CAO_QUY_CAN_NHAP", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BAO_CAO_6_THANG_CAN_NHAP(int year, int org_id)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_YEAR", year);
                param.Add("P_ORG_ID", org_id);
                var response = baseSQL.GetList("REPORT_BAO_CAO_6_THANG_CAN_NHAP", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken BAO_CAO_NAM_CAN_NHAP(int year, int org_id)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_YEAR", year);
                param.Add("P_ORG_ID", org_id);
                var response = baseSQL.GetList("REPORT_BAO_CAO_NAM_CAN_NHAP", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken LAY_CHI_TIET_BAO_CAO(int obj_id, int time_id, int org_id)
        {
            using (var baseSQL = new BaseSQL())
            {
                var stores = new String[] { "REPORT_LAY_TEN", "REPORT_LAY_THUOC_TINH", "REPORT_LAY_CHI_TIEU", "REPORT_LAY_DU_LIEU" };
                var param = new SQLDynamicParameters();
                param.Add("P_OBJ_ID", obj_id);
                param.Add("P_TIME_ID", time_id);
                param.Add("P_ORG_ID", org_id);
                var response = baseSQL.QueryMultipleTable(stores, param);
                return JsonHelper.ToJson(response);
            }
        }
        public static JToken NHAP_BAO_CAO(int obj_id, int time_id, int org_id, ReportTable[] dataReport)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_OBJ_ID", obj_id);
                param.Add("P_TIME_ID", time_id);
                param.Add("P_ORG_ID", org_id);
                param.Add("P_DATA", Ultility.CreateDataTable<ReportTable>(dataReport), SqlDbType.Structured);
                var response = baseSQL.Execute("REPORT_NHAP_BAO_CAO", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken LAY_TAT_CA_BAO_CAO()
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                var response = baseSQL.GetList("REPORT_LAY_DANH_SACH_TAT_CA", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken CHINH_SUA_TRANG_THAI_BAO_CAO(int obj_id, int org_id, int time_id, int status)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_OBJ_ID", obj_id);
                param.Add("P_TIME_ID", time_id);
                param.Add("P_ORG_ID", org_id);
                param.Add("P_STATUS", status);
                var response = baseSQL.GetList("REPORT_CHINH_SUA_TRANG_THAI_BAO_CAO", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken GUI_LANH_DAO(int obj_id, int org_id, int time_id)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_OBJ_ID", obj_id);
                param.Add("P_TIME_ID", time_id);
                param.Add("P_ORG_ID", org_id);
                var response = baseSQL.GetList("REPORT_GUI_LANH_DAO", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken PHE_DUYET_BAO_CAO(int obj_id, int org_id, int time_id)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_OBJ_ID", obj_id);
                param.Add("P_TIME_ID", time_id);
                param.Add("P_ORG_ID", org_id);
                var response = baseSQL.Execute("REPORT_PHE_DUYET_BAO_CAO", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken TU_CHOI_BAO_CAO(int obj_id, int org_id, int time_id)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_OBJ_ID", obj_id);
                param.Add("P_TIME_ID", time_id);
                param.Add("P_ORG_ID", org_id);
                var response = baseSQL.Execute("REPORT_TU_CHOI_BAO_CAO", param);
                return JsonHelper.ToJson(response);
            }
        }
        //public static JToken BAO_CAO_THANG(int month, int year, int org_id)
        //{
        //    using (var baseSQL = new BaseSQL())
        //    {
        //        var param = new SQLDynamicParameters();
        //        param.Add("P_MONTH", month);
        //        param.Add("P_YEAR", year);
        //        param.Add("P_ORG_ID", org_id);
        //        var response = baseSQL.GetList("REPORT_BAO_CAO_THANG", param);
        //        return JsonHelper.ToJson(response);
        //    }
        //}

        //public static JToken BAO_CAO_QUY(int quarter, int year, int org_id)
        //{
        //    using (var baseSQL = new BaseSQL())
        //    {
        //        var param = new SQLDynamicParameters();
        //        param.Add("P_QUARTER", quarter);
        //        param.Add("P_YEAR", year);
        //        param.Add("P_ORG_ID", org_id);
        //        var response = baseSQL.GetList("REPORT_BAO_CAO_QUY", param);
        //        return JsonHelper.ToJson(response);
        //    }
        //}

        //public static JToken BAO_CAO_6_THANG(int year, int org_id)
        //{
        //    using (var baseSQL = new BaseSQL())
        //    {
        //        var param = new SQLDynamicParameters();
        //        param.Add("P_YEAR", year);
        //        param.Add("P_ORG_ID", org_id);
        //        var response = baseSQL.GetList("REPORT_BAO_CAO_6_THANG", param);
        //        return JsonHelper.ToJson(response);
        //    }
        //}

        //public static JToken BAO_CAO_NAM(int year, int org_id)
        //{
        //    using (var baseSQL = new BaseSQL())
        //    {
        //        var param = new SQLDynamicParameters();
        //        param.Add("P_YEAR", year);
        //        param.Add("P_ORG_ID", org_id);
        //        var response = baseSQL.GetList("REPORT_BAO_CAO_NAM", param);
        //        return JsonHelper.ToJson(response);
        //    }
        //}

        public static JToken LAY_TAT_CA_BAO_CAO_DA_NHAP()
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                var response = baseSQL.GetList("REPORT_DANH_SACH_BAO_CAO_DA_NHAP", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken THONG_KE_KNXK(int report_mode, int year, int period, bool is_sct)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_REPORT_MODE", report_mode);
                param.Add("P_YEAR", year);
                param.Add("P_PERIOD", period);
                param.Add("P_IS_SCT", is_sct, SqlDbType.Bit);
                var response = baseSQL.GetMultipleTables("STATISTIC_LAY_DANH_SACH_DN_XUAT_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken THONG_KE_KNNK(int report_mode, int year, int period, bool is_sct)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_REPORT_MODE", report_mode);
                param.Add("P_YEAR", year);
                param.Add("P_PERIOD", period);
                param.Add("P_IS_SCT", is_sct, SqlDbType.Bit);
                var response = baseSQL.GetMultipleTables("STATISTIC_LAY_DANH_SACH_DN_NHAP_KHAU", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken LAY_BAO_CAO_THEO_LINH_VUC(int id_linh_vuc)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_ID_LINH_VUC", id_linh_vuc);
                var response = baseSQL.GetList("REPORT_LAY_BAO_CAO_THEO_LINH_VUC", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken LAY_DANH_SACH_PHAN_CONG(int obj_id)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_OBJ_ID", obj_id);
                var response = baseSQL.GetList("REPORT_LAY_DANH_SACH_PHAN_CONG", param);
                return JsonHelper.ToJson(response);
            }
        }
    }
}
