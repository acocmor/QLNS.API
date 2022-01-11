using QLNS.API.Application.DTOs.ChucVu;
using QLNS.API.Application.DTOs.PhongBan;
using QLNS.API.Application.DTOs.QueQuan;
using QLNS.API.Application.DTOs.User;
using System;

namespace QLNS.API.Application.DTOs.NhanVien
{
    public class CreateNhanVienDTO
    {
        public Guid Id { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public int NgaySinh { get; set; }
        public int ThangSinh { get; set; }
        public int NamSinh { get; set; }
        public int GioiTinh { get; set; }
        public Guid UserId { get; set; }
        public CreateUserDTO User { get; set; }
        public Guid QueQuanId { get; set; }
        public CreateQueQuanDTO QueQuan { get; set; }
        public Guid? ChucVuId { get; set; }
        public virtual GetChucVuDTO ChucVu { get; set; }
        public Guid? PhongBanId { get; set; }
        public virtual GetPhongBanDTO PhongBan { get; set; }
    }
}
