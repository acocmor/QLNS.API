using AutoMapper;
using QLNS.API.Application.DTOs.QueQuan;
using QLNS.API.Application.Interfaces;
using QLNS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Application.Services
{
    public class QueQuanService : IQueQuanService
    {
        private readonly IQueQuanRepository _queQuanRepository;
        private readonly IMapper _mapper;

        public QueQuanService(IQueQuanRepository queQuanRepository, IMapper mapper)
        {
            _queQuanRepository = queQuanRepository;
            _mapper = mapper;
        }
        public Task<GetQueQuanDTO> CreateQueQuan(CreateQueQuanDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteQueQuan(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetQueQuanDTO>> GetAllQueQuans()
        {
            throw new NotImplementedException();
        }

        public Task<GetQueQuanDTO> GetQueQuanById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetQueQuanDTO> UpdateQueQuan(Guid id, UpdateQueQuanDTO request)
        {
            var original = await _queQuanRepository.GetById(id);
            if (original == null) return null;

            original.ChiTiet = request.ChiTiet;
            original.XaPhuong = request.XaPhuong;
            original.QuanHuyen = request.QuanHuyen;
            original.TinhThanhPho = request.TinhThanhPho;

            _queQuanRepository.Update(original);
            await _queQuanRepository.SaveChangesAsync();
            return _mapper.Map<GetQueQuanDTO>(original);
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
                _queQuanRepository.Dispose();
            }
        }
    }
}
