using System;
using System.Collections.Generic;

namespace QLNS.Domain.Entities
{
    public class PhongBan : EntityBase
    {
        public string TenPhongBan { get; set; }
        public IEnumerable<NhanVien> DanhSachNhanVien { get; set; }

        public PhongBan()
        {
            DanhSachNhanVien = new HashSet<NhanVien>();
        }
    }
}
