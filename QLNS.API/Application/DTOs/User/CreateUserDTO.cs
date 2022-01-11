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

        [Required(ErrorMessage = "Hãy nhập email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        public string Password { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }
    }

    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserDTOValidator()
        {
            RuleFor(o => o.Email)
                .NotEmpty()
                .EmailAddress()
                .NotEqual(o => o.Email);
            RuleFor(o => o.Password).NotEmpty();
            RuleFor(o => o.ConfirmPassword).NotEmpty().Equal(o => o.Password);
        }
    }
}
