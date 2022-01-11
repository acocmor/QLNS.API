using QLNS.API.Application.DTOs.NhanVien;
using System;
using System.Collections.Generic;

namespace QLNS.API.Application.DTOs.ChucVu
{
    public class GetChucVuDTO
    {
        public Guid Id { get; set; }
        public string TenChucVu { get; set; }
        public IEnumerable<GetNhanVienDTO>? DanhSachNhanVien { get; set; }
    }
}
