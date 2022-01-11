using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNS.Domain.Entities
{
    public class NhanVien : EntityBase
    {
        public string Ho { get; set; }
        public string Ten { get; set; }
        public int NgaySinh     { get; set; }
        public int ThangSinh { get; set; }
        public int NamSinh { get; set; }
        public int GioiTinh { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public User User { get; set; }
        public Guid QueQuanId { get; set; }
        public QueQuan QueQuan { get; set; }
        public Guid? HopDongLaoDongId { get; set; }
        public HopDongLaoDong? HopDongLaoDong { get; set; }
        public Guid? ChucVuId { get; set; }
        public ChucVu? ChucVu { get; set; }
        public Guid? PhongBanId { get; set; }
        public PhongBan? PhongBan { get; set; }

    }
}
