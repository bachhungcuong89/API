using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CENA_FOODIE_API.Entities
{
    public class DoanhNghiep
    {
        public int? id { get; set; }
        public string ten_doanh_nghiep { get; set; }
        public string id_nganh_nghe { get; set; }
        public string dia_chi { get; set; }
        public int? id_phuong_xa { get; set; }
        public string nganh_nghe_kd { get; set; }
        public string nguoi_dai_dien { get; set; }
        public string dien_thoai { get; set; }
        public string mst { get; set; }
        public int so_gpgcn { get; set; }
        public DateTime? ngay_cap { get; set; }
        public DateTime? ngay_het_han { get; set; }
        public int? id_loai_hinh { get; set; }
        public long? von_kinh_doanh { get; set; }
        public DateTime? ngay_bat_dau_kd { get; set; }
        public string email { get; set; }
        public int? so_lao_dong { get; set; }
        public string cong_suat_thiet_ke { get; set; }
        public string san_luong { get; set; }
        public string tieu_chuan_san_pham { get; set; }
        public int? id_danh_sach_co_so_truc_thuoc { get; set; }
        public long? doanh_thu { get; set; }
        public long? quy_mo_tai_san { get; set; }
        public long? loi_nhuan { get; set; }
        public string nhu_cau_ban { get; set; }
        public string nhu_cau_mua { get; set; }
        public string nhu_cau_hop_tac { get; set; }
        public string email_sct { get; set; }
        public int? so_lao_dong_sct { get; set; }
        public string cong_suat_thiet_ke_sct { get; set; }
        public string san_luong_sct { get; set; }
    }
}
