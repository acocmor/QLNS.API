using QLNS.API.Application.DTOs.NhanVien;
using System;

namespace QLNS.API.Application.DTOs.QueQuan
{
    public class GetQueQuanDTO
    {
        public Guid Id { get; set; }
        public string ChiTiet { get; set; }
        public string XaPhuong { get; set; }
        public string QuanHuyen { get; set; }
        public string TinhThanhPho { get; set; }
        public GetNhanVienDTO NhanVien { get; set; }
    }
}
