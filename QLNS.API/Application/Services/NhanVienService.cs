using AutoMapper;
using QLNS.API.Application.DTOs.NhanVien;
using QLNS.API.Application.DTOs.QueQuan;
using QLNS.API.Application.Interfaces;
using QLNS.Domain.Entities;
using QLNS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Application.Services
{
    public class NhanVienService : INhanVienService
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IQueQuanRepository _queQuanRepository;
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IMapper _mapper;

        public NhanVienService(INhanVienRepository nhanVienRepository, 
                                IQueQuanRepository queQuanRepository, 
                                IPhongBanRepository phongBanRepository,
                                IChucVuRepository chucVuRepository,
                                IMapper mapper)
        {
            _nhanVienRepository = nhanVienRepository;
            _queQuanRepository = queQuanRepository;
            _phongBanRepository = phongBanRepository;
            _chucVuRepository = chucVuRepository;
            _mapper = mapper;
        }
        public async Task<List<GetNhanVienDTO>> GetAllNhanViens()
        {
            return _mapper.Map<List<GetNhanVienDTO>>(await _nhanVienRepository.GetAll());
        }

        public async Task<GetNhanVienDTO> GetNhanVienById(Guid id)
        {
            return _mapper.Map<GetNhanVienDTO>(await _nhanVienRepository.GetById(id));
        }
        public async Task<GetNhanVienDTO> CreateNhanVien(CreateNhanVienDTO request)
        {
            var nhanVien = _nhanVienRepository.Create(_mapper.Map<NhanVien>(request));
            await _nhanVienRepository.SaveChangesAsync();
            return _mapper.Map<GetNhanVienDTO>(nhanVien);
        }

        public async Task<bool> DeleteNhanVien(Guid id)
        {
            var delete = _nhanVienRepository.Delete(id);
            return await _nhanVienRepository.SaveChangesAsync() > 0;
        }

        public async Task<GetNhanVienDTO> UpdateNhanVien(Guid id, UpdateNhanVienDTO request)
        {
            var original = await _nhanVienRepository.GetById(id);
            if (original == null) return null;

            original.Ho = request.Ho;
            original.Ten = request.Ten;
            original.NgaySinh = request.NgaySinh;
            original.ThangSinh = request.ThangSinh;
            original.NamSinh = request.NamSinh;
            original.GioiTinh = request.GioiTinh;

            var oQueQuan = _queQuanRepository.GetById(request.QueQuanId);
            if (oQueQuan == null) 
                return null;
            oQueQuan.ChiTiet = oQueQuan.ChiTiet;
            _chucVuRepository.Update(original);
            await _chucVuRepository.SaveChangesAsync();
            original.QueQuan = ;

            _nhanVienRepository.Update(original);
            await _nhanVienRepository.SaveChangesAsync();
            return _mapper.Map<GetNhanVienDTO>(original);
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
                _nhanVienRepository.Dispose();
            }
        }
    }
}
