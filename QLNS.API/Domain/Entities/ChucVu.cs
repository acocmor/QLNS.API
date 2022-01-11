using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace QLNS.Domain.Entities
{
    public class ChucVu : EntityBase
    {
        [Required]
        public string TenChucVu { get; set; }
        public IEnumerable<NhanVien> DanhSachNhanVien { get; set; }

        public ChucVu()
        {
            DanhSachNhanVien = new HashSet<NhanVien>();
        }
    }
}
