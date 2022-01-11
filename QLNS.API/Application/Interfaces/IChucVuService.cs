using QLNS.API.Application.DTOs;
using QLNS.API.Application.DTOs.ChucVu;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Application.Interfaces
{
    public interface IChucVuService : IDisposable
    {
        Task<List<GetChucVuDTO>> GetAllChucVus();
        Task<GetChucVuDTO> GetChucVuById(Guid id);
        Task<GetChucVuDTO> CreateChucVu(CreateChucVuDTO request);
        Task<GetChucVuDTO> UpdateChucVu(Guid id, UpdateChucVuDTO request);
        Task<bool> DeleteChucVu(Guid id);
    }
}
