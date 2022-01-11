using QLNS.API.Application.DTOs.NhanVien;
using System;

namespace QLNS.API.Application.DTOs.HopDongLaoDong
{
    public class CreateHDLDDTO
    {
        public Guid Id { get; set; }
        public string LoaiHopDong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public GetNhanVienDTO NhanVien { get; set; }
    }
}
