using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Entities
{
    public class CoSoTrucThuoc
    {
        public int id { get; set; }
        public string so_gpgcn { get; set; }
        public string ngay_cap { get; set; }
        public string ngay_het_han { get; set; }
        public int id_dscstt { get; set; }
    }
}
