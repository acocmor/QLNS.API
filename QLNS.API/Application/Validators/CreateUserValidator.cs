using FluentValidation;
using QLNS.API.Application.DTOs.User;

namespace QLNS.API.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator()
        {
            //validation email
            RuleFor(o => o.Email)
                    .NotEmpty().WithMessage("Hãy nhập địa chỉ email")
                    .EmailAddress().WithMessage("Địa chỉ email nhập vào không đúng định dạng");

            //validation password
            RuleFor(o => o.Password)
                .NotEmpty().WithMessage("Hãy nhập mật khẩu");

            //validation confirm passwod
            RuleFor(o => o.ConfirmPassword)
                .NotEmpty().WithMessage("Hãy xác nhận mật khẩu.")
                .Equal(o => o.Password).WithMessage("Xác nhận mật khẩu không đúng");
        }
    }
}
