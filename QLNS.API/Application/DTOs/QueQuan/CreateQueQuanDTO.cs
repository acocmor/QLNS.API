using System;

namespace QLNS.API.Application.DTOs.QueQuan
{
    public class CreateQueQuanDTO
    {
        public Guid Id { get; set; }
        public string ChiTiet { get; set; }
        public string XaPhuong { get; set; }
        public string QuanHuyen { get; set; }
        public string TinhThanhPho { get; set; }
        public Guid NhanVienId { get; set; }
    }
}
