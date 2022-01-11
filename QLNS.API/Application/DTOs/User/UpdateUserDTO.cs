﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNS.API.Application.DTOs.User
{
    public class UpdateUserDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
    