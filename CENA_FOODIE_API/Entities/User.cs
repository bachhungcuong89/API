using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Entities
{
    public class User
    {
        public int user_id { get; set; }
        public int user_role { get; set; }
        public string full_name { get; set; }
        public string user_name { get; set; }
        public byte[] user_pwd_hash { get; set; }
        public byte[] user_pwd_salt { get; set; }
        public string email { get; set; }
        public string mst { get; set; }
        public string token { get; set; }
        public string password { get; set; }
        public string new_password { get; set; }
        public string org_id { get; set; }
        public string refresh_token { get; set; }
        public DateTime exp_date { get; set; }
    }
}
