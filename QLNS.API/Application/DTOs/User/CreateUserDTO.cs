using QLNS.API.Application.DTOs.NhanVien;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNS.API.Application.DTOs.User
{
    public class CreateUserDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Hãy nhập email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
