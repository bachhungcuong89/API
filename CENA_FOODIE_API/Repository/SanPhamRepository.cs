using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CENA_FOODIE_API.Model;
using CENA_FOODIE_API.Model.Response;

namespace CENA_FOODIE_API.Repository
{
    public class SanPhamRepository
    {

        public static JToken PRODUCT_LAY_DANH_SACH_SAN_PHAM()
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                var response = baseSQL.GetList("PRODUCT_LAY_DANH_SACH_SAN_PHAM", param);
                return JsonHelper.ToJson(response);
            }
        }
        public static JToken PRODUCT_LAY_SAN_PHAM_THEO_MA(int ma_san_pham)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_MA_SAN_PHAM", ma_san_pham);
                var response = baseSQL.GetList("PRODUCT_LAY_SAN_PHAM_THEO_MA", param);
                return JsonHelper.ToJson(response);
            }
        }
        
    }
}
