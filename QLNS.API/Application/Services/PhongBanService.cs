using AutoMapper;
using QLNS.API.Application.DTOs.PhongBan;
using QLNS.API.Application.Interfaces;
using QLNS.Domain.Entities;
using QLNS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Application.Services
{
    public class PhongBanService : IPhongBanService
    {
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly IMapper _mapper;

        public PhongBanService(IPhongBanRepository phongBanRepository, IMapper mapper)
        {
            _phongBanRepository = phongBanRepository;
            _mapper = mapper;
        }
        public async Task<List<GetPhongBanDTO>> GetAllPhongBans()
        {
            return _mapper.Map<List<GetPhongBanDTO>>(await _phongBanRepository.GetAll());
        }

        public async Task<GetPhongBanDTO> GetNhanPhongBanId(Guid id)
        {
            return _mapper.Map<GetPhongBanDTO>(await _phongBanRepository.GetById(id));
        }
        public async Task<GetPhongBanDTO> CreatePhongBan(CreatePhongBanDTO request)
        {
            var created = _phongBanRepository.Create(_mapper.Map<PhongBan>(request));
            await _phongBanRepository.SaveChangesAsync();
            return _mapper.Map<GetPhongBanDTO>(created);
        }

        public async Task<bool> DeletePhongBan(Guid id)
        {
            await _phongBanRepository.Delete(id);
            return await _phongBanRepository.SaveChangesAsync() > 0;
        }

        public async Task<GetPhongBanDTO> UpdatePhongBan(Guid id, UpdatePhongBanDTO request)
        {
            var original = await _phongBanRepository.GetById(id);
            if (original == null) return null;

            original.TenPhongBan = request.TenPhongBan;

            _phongBanRepository.Update(original);
            await _phongBanRepository.SaveChangesAsync();
            return _mapper.Map<GetPhongBanDTO>(original);
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
                _phongBanRepository.Dispose();
            }
        }
    }
}
