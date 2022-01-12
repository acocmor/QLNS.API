using AutoMapper;
using QLNS.API.Application.DTOs.HopDongLaoDong;
using QLNS.API.Application.Interfaces;
using QLNS.Domain.Entities;
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
        public async Task<GetHDLDDTO> CreateHDLD(CreateHDLDDTO request)
        {
            try
            {
                var hdld = _hopDongLaoDongRepository.Create(_mapper.Map<HopDongLaoDong>(request));
                await _hopDongLaoDongRepository.SaveChangesAsync();
                return _mapper.Map<GetHDLDDTO>(hdld);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<bool> DeleteHDLD(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetHDLDDTO>> GetAllHDLDs()
        {
            return _mapper.Map<List<GetHDLDDTO>>(await _hopDongLaoDongRepository.GetAll());
        }

        public async Task<GetHDLDDTO> GetHDLDById(Guid id)
        {
            return _mapper.Map<GetHDLDDTO>(await _hopDongLaoDongRepository.GetById(id));
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
