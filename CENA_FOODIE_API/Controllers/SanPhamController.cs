using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CENA_FOODIE_API.Repository;

namespace CENA_FOODIE_API.Controllers
{
    [Authorize]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("api/san-pham/danh-sach-san-pham")]
        public JToken DanhSachSanPham()
        {
            return SanPhamRepository.PRODUCT_LAY_DANH_SACH_SAN_PHAM();
        }
        [AllowAnonymous]
        [HttpGet("api/san-pham/{ma_san_pham}")]
        public JToken SanPhamTheoMaSanPham(int ma_san_pham)
        {
            return SanPhamRepository.PRODUCT_LAY_SAN_PHAM_THEO_MA(ma_san_pham);
        }
    }
}