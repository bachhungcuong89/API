using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Entities
{
    public class SanXuat
    {
        public int id_san_pham { get; set; }
        public float san_luong { get; set; }
        public float tri_gia { get; set; }
        public int thang { get; set; }
        public int nam { get; set; }
        public string don_vi_tinh { get; set; }
    }
}
