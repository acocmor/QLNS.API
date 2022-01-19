using QLNS.API.Application.DTOs;
using QLNS.API.Application.DTOs.NhanVien;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Application.Interfaces
{
    public interface INhanVienService : IDisposable
    {
        Task<List<GetNhanVienDTO>> GetAllNhanViens();
        Task<GetNhanVienDTO> GetNhanVienById(Guid id);
        Task<GetNhanVienDTO> CreateNhanVien(CreateNhanVienDTO request);
        Task<GetNhanVienDTO> UpdateNhanVien(Guid id, UpdateNhanVienDTO request);
        Task<bool> DeleteNhanVien(Guid id);
        Task<bool> GetUserByEmail(string email);
        Task<bool> GetChucVuById(Guid id);
        Task<bool> GetPhongBanById(Guid id);
    }
}
