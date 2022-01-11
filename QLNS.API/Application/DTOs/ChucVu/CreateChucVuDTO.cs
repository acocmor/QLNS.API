using System;
using System.ComponentModel.DataAnnotations;

namespace QLNS.API.Application.DTOs.ChucVu
{
    public class CreateChucVuDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Hãy nhập tên chức vụ")]
        public string TenChucVu { get; set; }
    }
}
