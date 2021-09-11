using CENA_FOODIE_API.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Repository
{
    public class HomeRepository
    {
        public static JToken HOME_LAY_DANH_SACH_QUAN_HUYEN()
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                var response = baseSQL.GetList("HOME_LAY_DANH_SACH_QUAN_HUYEN", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken HOME_LAY_DANH_SACH_PHUONG_XA()
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                var response = baseSQL.GetList("HOME_LAY_DANH_SACH_PHUONG_XA", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken HOME_LAY_DANH_SACH_LOAI_HINH()
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                var response = baseSQL.GetList("HOME_LAY_DANH_SACH_LOAI_HINH", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken HOME_LAY_DANH_SACH_NGANH_NGHE()
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                var response = baseSQL.GetList("HOME_LAY_DANH_SACH_NGANH_NGHE", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken HOME_LAY_TEN_XA_HUYEN(int id_xa)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_ID_XA", id_xa);
                var response = baseSQL.GetList("HOME_LAY_TEN_XA_HUYEN", param);
                return JsonHelper.ToJson(response);
            }
        }

        public static JToken HOME_LAY_DANH_SACH_XA_PHUONG_THUOC_QUAN_HUYEN(int id_quan_huyen)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_ID_QUAN_HUYEN", id_quan_huyen);
                var response = baseSQL.GetList("HOME_LAY_DANH_SACH_XA_PHUONG_THUOC_QUAN_HUYEN", param);
                return JsonHelper.ToJson(response);
            }
        }
    }
}
