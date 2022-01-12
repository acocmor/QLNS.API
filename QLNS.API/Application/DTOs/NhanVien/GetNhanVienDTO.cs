using QLNS.API.Application.DTOs.ChucVu;
using QLNS.API.Application.DTOs.HopDongLaoDong;
using QLNS.API.Application.DTOs.PhongBan;
using QLNS.API.Application.DTOs.QueQuan;
using QLNS.API.Application.DTOs.User;
using System;
using System.ComponentModel.DataAnnotations;

namespace QLNS.API.Application.DTOs.NhanVien
{
    public class GetNhanVienDTO
    {
        public Guid Id { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public int NgaySinh { get; set; }
        public int ThangSinh { get; set; }
        public int NamSinh { get; set; }
        public int GioiTinh { get; set; }
        public string SDT { get; set; }
        public virtual GetUserDTO User { get; set; }
        public virtual GetQueQuanDTO QueQuan { get; set; }
        public virtual GetHDLDDTO HopDongLaoDong { get; set; }
        public virtual GetChucVuNoListDTO ChucVu { get; set; }
        public virtual GetPhongBanNoListDTO PhongBan { get; set; }
    }
}
