using AutoMapper;
using QLNS.API.Application.DTOs.HopDongLaoDong;
using QLNS.API.Application.Interfaces;
using QLNS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Application.Services
{
    public class HopDongLaoDongService : IHopDongLaoDongService
    {
        private readonly IHopDongLaoDongRepository _hopDongLaoDongRepository;
        private readonly IMapper _mapper;

        public HopDongLaoDongService(IHopDongLaoDongRepository hopDongLaoDongRepository, IMapper mapper)
        {
            _hopDongLaoDongRepository = hopDongLaoDongRepository;
            _mapper = mapper;
        }
        public Task<GetHDLDDTO> CreateHDLD(CreateHDLDDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteHDLD(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetHDLDDTO>> GetAllHDLDs()
        {
            throw new NotImplementedException();
        }

        public Task<GetHDLDDTO> GetHDLDById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GetHDLDDTO> UpdateHDLD(Guid id, UpdateHDLDDTO request)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _hopDongLaoDongRepository.Dispose();
            }
        }
    }
}
