using System;
using System.Collections.Generic;

namespace QLNS.Domain.Entities
{
    public class QueQuan : EntityBase
    {
        public string ChiTiet { get; set; }
        public string XaPhuong { get; set; }
        public string QuanHuyen { get; set; }
        public string TinhThanhPho { get; set; }
        public Guid NhanVienId { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
