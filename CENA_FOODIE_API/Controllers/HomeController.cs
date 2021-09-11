using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CENA_FOODIE_API.Repository;
using Newtonsoft.Json.Linq;

namespace CENA_FOODIE_API.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return Redirect("index.html");
        //}

        [AllowAnonymous]
        [HttpGet("api/quan-huyen")]
        public JToken LayDanhSachQuanHuyen()
        {
            return HomeRepository.HOME_LAY_DANH_SACH_QUAN_HUYEN();
        }

        [AllowAnonymous]
        [HttpGet("api/phuong-xa")]
        public JToken LayDanhSachPhuongXa()
        {
            return HomeRepository.HOME_LAY_DANH_SACH_PHUONG_XA();
        }

        [AllowAnonymous]
        [HttpGet("api/loai-hinh")]
        public JToken LayDanhSachLoaiHinhDN()
        {
            return HomeRepository.HOME_LAY_DANH_SACH_LOAI_HINH();
        }

        [AllowAnonymous]
        [HttpGet("api/nganh-nghe")]
        public JToken LayDanhSachNganhNghe()
        {
            return HomeRepository.HOME_LAY_DANH_SACH_NGANH_NGHE();
        }

        [AllowAnonymous]
        [HttpGet("api/xa-huyen")]
        public JToken LayXaHuyen(int id_xa)
        {
            return HomeRepository.HOME_LAY_TEN_XA_HUYEN(id_xa);
        }

        [AllowAnonymous]
        [HttpGet("api/phuong-thuoc-huyen")]
        public JToken LayXaPhuongThuocQuanHuyen(int id_quan_huyen)
        {
            return HomeRepository.HOME_LAY_DANH_SACH_XA_PHUONG_THUOC_QUAN_HUYEN(id_quan_huyen);
        }
    }
}