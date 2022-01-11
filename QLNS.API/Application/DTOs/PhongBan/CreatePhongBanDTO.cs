using System;
using System.ComponentModel.DataAnnotations;

namespace QLNS.API.Application.DTOs.PhongBan
{
    public class CreatePhongBanDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Hãy nhập tên phòng ban")]
        public string TenPhongBan { get; set; }
    }
}
