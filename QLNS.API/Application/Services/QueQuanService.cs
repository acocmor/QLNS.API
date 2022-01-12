using AutoMapper;
using QLNS.API.Application.DTOs.QueQuan;
using QLNS.API.Application.Interfaces;
using QLNS.Domain.Entities;
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
        public async Task<GetQueQuanDTO> CreateQueQuan(CreateQueQuanDTO request)
        {
            try
            {
                var queQuan = _queQuanRepository.Create(_mapper.Map<QueQuan>(request));
                await _queQuanRepository.SaveChangesAsync();
                return _mapper.Map<GetQueQuanDTO>(queQuan);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<GetQueQuanDTO>> GetAllQueQuans()
        {
            return _mapper.Map<List<GetQueQuanDTO>>(await _queQuanRepository.GetAll());
        }

        public async Task<GetQueQuanDTO> GetQueQuanById(Guid id)
        {
            return _mapper.Map<GetQueQuanDTO>(await _queQuanRepository.GetById(id));
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

        public async Task<bool> DeleteQueQuan(Guid id)
        {
            await _queQuanRepository.Delete(id);
            return await _queQuanRepository.SaveChangesAsync() > 0;
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
