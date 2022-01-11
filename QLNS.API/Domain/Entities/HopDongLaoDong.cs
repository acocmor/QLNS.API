using System;
using System.Collections.Generic;


namespace QLNS.Domain.Entities
{
    public class HopDongLaoDong : EntityBase
    {
        public string LoaiHopDong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public NhanVien? NhanVien { get; set; }
    }
}
