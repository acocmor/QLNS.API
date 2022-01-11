using AutoMapper;
using QLNS.API.Application.DTOs;
using QLNS.API.Application.DTOs.ChucVu;
using QLNS.API.Application.Interfaces;
using QLNS.Domain.Entities;
using QLNS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.API.Application.Services
{
    public class ChucVuService : IChucVuService
    {
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IMapper _mapper;

        public ChucVuService(IChucVuRepository chucVuRepository, IMapper mapper)
        {
            _chucVuRepository = chucVuRepository ?? throw new ArgumentNullException(nameof(chucVuRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetChucVuDTO>> GetAllChucVus()
        {
            return _mapper.Map<List<GetChucVuDTO>>(await _chucVuRepository.GetAll());
        }

        public async Task<GetChucVuDTO> GetChucVuById(Guid id)
        {
            return _mapper.Map<GetChucVuDTO>(await _chucVuRepository.GetById(id));
        }


        public async Task<GetChucVuDTO> CreateChucVu(CreateChucVuDTO request)
        {
            var created = _chucVuRepository.Create(_mapper.Map<ChucVu>(request));
            await _chucVuRepository.SaveChangesAsync();
            return _mapper.Map<GetChucVuDTO>(created);
        }

        public async Task<bool> DeleteChucVu(Guid id)
        {
            await _chucVuRepository.Delete(id);
            return await _chucVuRepository.SaveChangesAsync() > 0;
        }
        public async Task<GetChucVuDTO> UpdateChucVu(Guid id, UpdateChucVuDTO request)
        {
            var original = await _chucVuRepository.GetById(id);
            if (original == null) return null;

            original.TenChucVu = request.TenChucVu;

            _chucVuRepository.Update(original);
            await _chucVuRepository.SaveChangesAsync();
            return _mapper.Map<GetChucVuDTO>(original);
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
                _chucVuRepository.Dispose();
            }
        }
    }
}
