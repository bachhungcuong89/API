using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Model
{
    public class RefreshRequestModel
    {
        public string refresh_token { get; set; }
        public bool isBusiness { get; set; }
    }
}
