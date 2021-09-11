using CENA_FOODIE_API.Entities;
using CENA_FOODIE_API.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Repository
{
    public class LoginRepository
    {
        public static JToken REGISTER(User user)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_USER_NAME", user.user_name);
                param.Add("P_USER_PWD_HASH", user.user_pwd_hash, System.Data.SqlDbType.VarBinary);
                param.Add("P_USER_PWD_SALT", user.user_pwd_salt, System.Data.SqlDbType.VarBinary);
                param.Add("P_NAME", user.full_name);
                param.Add("@P_MST", user.mst);
                param.Add("P_USER_EMAIL", user.email);
                var response = baseSQL.Execute("LOGIN_DANG_KY_MO_TAI_KHOAN", param);
                return JsonHelper.ToJson(response);
            }
        }
        public static bool CHECK_EXIST(string username)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_USER_NAME", username);
                param.Add("P_IS_BUSINESS", true);
                var response = baseSQL.GetList("LOGIN_LAY_THONG_TIN_USER", param);
                return (response.data.Count() == 0);
            }
        }
        public static JToken APPROVE_ACCOUNT(string username)
        {
            using (var baseSQL = new BaseSQL())
            {
                var param = new SQLDynamicParameters();
                param.Add("P_USER_NAME", username);
                var response = baseSQL.Execute("LOGIN_XAC_NHAN_MO_TAI_KHOAN", param);
                return JsonHelper.ToJson(response);
            }
        }
    }
}
