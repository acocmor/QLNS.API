using QLNS.API.Application.DTOs;
using QLNS.API.Application.DTOs.QueQuan;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Application.Interfaces
{
    public interface IQueQuanService : IDisposable
    {
        Task<List<GetQueQuanDTO>> GetAllQueQuans();
        Task<GetQueQuanDTO> GetQueQuanById(Guid id);
        Task<GetQueQuanDTO> CreateQueQuan(CreateQueQuanDTO request);
        Task<GetQueQuanDTO> UpdateQueQuan(Guid id, UpdateQueQuanDTO request);
        Task<bool> DeleteQueQuan(Guid id);
    }
}
