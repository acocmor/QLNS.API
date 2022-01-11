using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLNS.Domain.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
