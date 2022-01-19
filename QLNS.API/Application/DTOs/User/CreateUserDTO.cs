using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNS.API.Application.DTOs.User
{
    
    public class CreateUserDTO
    {
        public Guid Id { get; set; }

        [StringLength(450)]
        
        public string Email { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public Guid NhanVienId { get; set; }
    }
}
