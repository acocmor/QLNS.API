using Microsoft.EntityFrameworkCore;
using QLNS.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLNS.Domain.Entities
{
    [Index(nameof(Email), IsUnique = true, Name = "IX_EMAIL_OF_USER")]
    public class User : EntityBase
    {
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public Guid NhanVienId { get; set; }
        public NhanVien NhanVien { get; set; }

    }
}
