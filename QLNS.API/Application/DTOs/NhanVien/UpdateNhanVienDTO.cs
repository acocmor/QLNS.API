using QLNS.API.Application.DTOs.ChucVu;
using QLNS.API.Application.DTOs.PhongBan;
using QLNS.API.Application.DTOs.QueQuan;
using System;

namespace QLNS.API.Application.DTOs.NhanVien
{
    public class UpdateNhanVienDTO
    {
        public Guid Id { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public int NgaySinh { get; set; }
        public int ThangSinh { get; set; }
        public int NamSinh { get; set; }
        public int GioiTinh { get; set; }
        public Guid QueQuanId { get; set; }
        public UpdateQueQuanDTO QueQuan { get; set; }
        public Guid? ChucVuId { get; set; }
        public GetChucVuDTO? ChucVu { get; set; }
        public Guid? PhongBanId { get; set; }
        public GetPhongBanDTO? PhongBan { get; set; }
    }
}
