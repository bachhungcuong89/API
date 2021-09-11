using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CENA_FOODIE_API.Model;
using CENA_FOODIE_API.Repository;
using Newtonsoft.Json.Linq;

namespace CENA_FOODIE_API.Controllers
{
    public class SCTController : Controller
    {
        [HttpGet("api/sct/danh-sach-buon-ban-thuoc-la")]
        public JToken DanhSachBuonBanThuocLa(int time_id)
        {
            return SCTRepository.SCT_QLTM_TMND_DOANH_NGHIEP_BAN_BUON_THUOC_LA(time_id);
        }

    }
}
