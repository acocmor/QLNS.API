using QLNS.API.Application.DTOs.NhanVien;
using System;

namespace QLNS.API.Application.DTOs.User
{
    public class GetUserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public GetNhanVienDTO NhanVien { get; set; }
    }
}
