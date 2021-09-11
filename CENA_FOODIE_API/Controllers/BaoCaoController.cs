using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CENA_FOODIE_API.Model;
using CENA_FOODIE_API.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API2.Controllers
{
    [Authorize]
    [ApiController]
    public class BaoCaoController : ControllerBase
    {
        [HttpGet("api/bao-cao/thang")]
        public JToken BaoCaoThangCanNhap(int month, int year, int org_id)
        {
            return BaoCaoRepository.BAO_CAO_THANG_CAN_NHAP(month, year, org_id);
        }

        [HttpGet("api/bao-cao/quy")]
        public JToken BaoCaoQuyCanNhap(int quarter, int year, int org_id)
        {
            return BaoCaoRepository.BAO_CAO_QUY_CAN_NHAP(quarter, year, org_id);
        }

        [HttpGet("api/bao-cao/6thang")]
        public JToken BaoCao6ThangCanNhap(int year, int org_id)
        {
            return BaoCaoRepository.BAO_CAO_6_THANG_CAN_NHAP(year, org_id);
        }

        [HttpGet("api/bao-cao/nam")]
        public JToken BaoCaoNamCanNhap(int year, int org_id)
        {
            return BaoCaoRepository.BAO_CAO_NAM_CAN_NHAP(year, org_id);
        }

        [HttpGet("api/bao-cao/")]
        public JToken LayChiTietBaoCao(int obj_id, int time_id, int org_id)
        {
            return BaoCaoRepository.LAY_CHI_TIET_BAO_CAO(obj_id, time_id, org_id);
        }

        [HttpPost("api/bao-cao/")]
        public JToken NhapBaoCao(int obj_id, int time_id, int org_id,[FromBody] dynamic[] dataReport)
        {
            return BaoCaoRepository.NHAP_BAO_CAO(obj_id, time_id, org_id, Ultility.MappingDynamicToT<ReportTable>(dataReport));
        }

        [HttpGet("api/bao-cao/tat-ca")]
        public JToken LayTatCaBaoCao()
        {
            return BaoCaoRepository.LAY_TAT_CA_BAO_CAO();
        }

        [HttpPost("api/bao-cao/chinh-sua-trang-thai")]
        public JToken ChinhSuaTrangThai(int obj_id, int org_id, int time_id, int status)
        {
            return BaoCaoRepository.CHINH_SUA_TRANG_THAI_BAO_CAO(obj_id, org_id, time_id, status);
        }

        [HttpPost("api/bao-cao/gui-lanh-dao")]
        public JToken GuiLanhDao(int obj_id, int org_id, int time_id)
        {
            return BaoCaoRepository.GUI_LANH_DAO(obj_id, org_id, time_id);
        }

        [HttpPost("api/bao-cao/phe-duyet")]
        public JToken PheDuyet(int obj_id, int org_id, int time_id)
        {
            return BaoCaoRepository.PHE_DUYET_BAO_CAO(obj_id, org_id, time_id);
        }

        [HttpPost("api/bao-cao/tu-choi")]
        public JToken TuChoi(int obj_id, int org_id, int time_id)
        {
            return BaoCaoRepository.TU_CHOI_BAO_CAO(obj_id, org_id, time_id);
        }

        [HttpGet("api/bao-cao/tat-ca-da-nhap")]
        public JToken LayTatCaBaoCaoDaNhap()
        {
            return BaoCaoRepository.LAY_TAT_CA_BAO_CAO_DA_NHAP();
        }

        [HttpGet("api/bao-cao/kim-ngach-xuat-khau")]
        public JToken ThongKeKNXK(int report_mode, int year, int period, bool is_sct)
        {
            return BaoCaoRepository.THONG_KE_KNXK(report_mode, year, period, is_sct);
        }

        [HttpGet("api/bao-cao/kim-ngach-nhap-khau")]
        public JToken ThongKeKNNK(int report_mode, int year, int period, bool is_sct)
        {
            return BaoCaoRepository.THONG_KE_KNNK(report_mode, year, period, is_sct);
        }

        [HttpGet("api/bao-cao/bao-cao-theo-linh-vuc")]
        public JToken LayBaoCaoTheoLinhVuc(int id_linh_vuc)
        {
            return BaoCaoRepository.LAY_BAO_CAO_THEO_LINH_VUC(id_linh_vuc);
        }

        [HttpGet("api/bao-cao/phan-cong")]
        public JToken LayDanhSachPhanCong(int obj_id)
        {
            return BaoCaoRepository.LAY_DANH_SACH_PHAN_CONG(obj_id);
        }
    }
}
