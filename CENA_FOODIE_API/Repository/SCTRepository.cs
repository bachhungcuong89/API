using CENA_FOODIE_API.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Repository
{
    public class SCTRepository
    {
        public static JToken SCT_QLTM_TMND_DOANH_NGHIEP_BAN_BUON_THUOC_LA(int time_id)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_TIME_ID", time_id);
                var response = baseSQL.GetMultipleTables("SCT_QLTM_TMND_DOANH_NGHIEP_BAN_BUON_THUOC_LA", param);
                return JsonHelper.ToJson(response);
            }
        }
    }
}
