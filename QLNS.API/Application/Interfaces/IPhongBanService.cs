using QLNS.API.Application.DTOs;
using QLNS.API.Application.DTOs.PhongBan;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Application.Interfaces
{
    public interface IPhongBanService : IDisposable
    {
        Task<List<GetPhongBanDTO>> GetAllPhongBans();
        Task<GetPhongBanDTO> GetNhanPhongBanId(Guid id);
        Task<GetPhongBanDTO> CreatePhongBan(CreatePhongBanDTO request);
        Task<GetPhongBanDTO> UpdatePhongBan(Guid id, UpdatePhongBanDTO request);
        Task<bool> DeletePhongBan(Guid id);
    }
}
