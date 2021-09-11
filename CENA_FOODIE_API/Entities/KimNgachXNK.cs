using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Entities
{
    public class KimNgachXNK
    {
        public int id_san_pham { get; set; }
        public float san_luong { get; set; }
        public float tri_gia { get; set; }
        public string thi_truong { get; set; }
        public int id_kn_xuat_nhap_khau { get; set; }
    }
}
