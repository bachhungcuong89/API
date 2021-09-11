using Microsoft.AspNetCore.Razor.Language.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Entities
{
    public class GiaCa
    {
        public int id_san_pham { get; set; }
        public float gia { get; set; }
        public string nguon_so_lieu { get; set; }
        public string ngay_cap_nhat { get; set; }
        public int ma_nguoi_cap_nhat { get; set; }
        public string thi_truong { get; set; }
        public int id { get; set; }
    }
}
