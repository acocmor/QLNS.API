using System.ComponentModel.DataAnnotations;

namespace QLNS.API.Application.DTOs.User
{
    public class LoginUserDTO
    {
        [Required(ErrorMessage = "Tài khoản không được bỏ trống")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không đúng định dạng.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
