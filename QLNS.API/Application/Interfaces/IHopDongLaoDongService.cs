
using QLNS.API.Application.DTOs;
using QLNS.API.Application.DTOs.HopDongLaoDong;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Application.Interfaces
{
    public interface IHopDongLaoDongService : IDisposable
    {
        Task<List<GetHDLDDTO>> GetAllHDLDs();
        Task<GetHDLDDTO> GetHDLDById(Guid id);
        Task<GetHDLDDTO> CreateHDLD(CreateHDLDDTO request);
        Task<GetHDLDDTO> UpdateHDLD(Guid id, UpdateHDLDDTO request);
        Task<bool> DeleteHDLD(Guid id);
    }
}
