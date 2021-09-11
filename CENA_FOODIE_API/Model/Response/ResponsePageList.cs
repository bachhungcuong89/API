using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Model.Response
{
    public class ResponsePageList : ResponseList
    {
        public int total_page { get; set; }
        public int total_row { get; set; }
    }
}
