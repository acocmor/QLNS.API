using QLNS.API.Application.DTOs.NhanVien;
using System;
using System.Collections.Generic;

namespace QLNS.API.Application.DTOs.PhongBan
{
    public class GetPhongBanDTO
    {
        public Guid Id { get; set; }
        public string TenPhongBan { get; set; }
        public IEnumerable<GetNhanVienDTO>? DanhSachNhanVien { get; set; }
    }
}
