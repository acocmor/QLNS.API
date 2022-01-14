using FluentValidation;
using QLNS.API.Application.DTOs.NhanVien;

namespace QLNS.API.Application.Validators
{
    public class CreateNhanVienValidator : AbstractValidator<CreateNhanVienDTO>
    {
        public CreateNhanVienValidator()
        {
            RuleFor(x => x.Ho)
                .NotEmpty().WithMessage("Trường Họ không được để trống.")
                .Matches("[a-zA-Z]").WithMessage("Họ nhập vào chứa ký tự không hợp lệ."); 

            RuleFor(x => x.Ten)
                .NotEmpty().WithMessage("Trường Tên không được để trống.")
                .Matches("[a-zA-Z]").WithMessage("Tên nhập vào chứa ký tự không hợp lệ.");

            RuleFor(x => x.NgaySinh)
                .NotEmpty().WithMessage("Ngày sinh không được để trống.");

            RuleFor(x => x.User).SetValidator(new CreateUserValidator());

        }
    }
}
