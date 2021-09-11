using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Model.Response
{
    public class ResponseReport
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string store_name { get; set; }
        public int store_type { get; set; }
        public List<dynamic> data { get; set; }
        public SQLDynamicParameters param { get; set; }
    }
}
