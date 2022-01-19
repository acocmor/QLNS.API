using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLNS.API.Application.DTOs.ChucVu;
using QLNS.API.Application.DTOs.NhanVien;
using QLNS.API.Application.DTOs.QueQuan;
using QLNS.API.Application.Interfaces;
using QLNS.Domain.Entities;
using QLNS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.API.Application.Services
{
    public class NhanVienService : INhanVienService
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IQueQuanRepository _queQuanRepository;
        private readonly IUserRepository _userRepository;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly IMapper _mapper;

        public NhanVienService(INhanVienRepository nhanVienRepository,
                                IQueQuanRepository queQuanRepository,
                                IUserRepository userRepository,
                                IChucVuRepository chucVuRepository,
                                IPhongBanRepository phongBanRepository,
                                IMapper mapper)
        {
            _nhanVienRepository = nhanVienRepository;
            _queQuanRepository = queQuanRepository;
            _userRepository = userRepository;;
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

            try
            {
                var nhanVien = _nhanVienRepository.Create(_mapper.Map<NhanVien>(request));
                await _nhanVienRepository.SaveChangesAsync();
                return _mapper.Map<GetNhanVienDTO>(nhanVien);
            } catch (Exception)
            {
                throw new Exception("Email bị trùng");
            }

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

            var queQuan = await _queQuanRepository.GetById(original.QueQuan.Id);
            if (queQuan == null) return null;
            queQuan.ChiTiet = request.QueQuan.ChiTiet;
            queQuan.XaPhuong = request.QueQuan.XaPhuong;
            queQuan.QuanHuyen = request.QueQuan.QuanHuyen;
            queQuan.TinhThanhPho = request.QueQuan.TinhThanhPho;
            _queQuanRepository.Update(queQuan);
            await _queQuanRepository.SaveChangesAsync();

            if (request.ChucVuId != null)
                original.ChucVuId = request.ChucVuId;
            if (request.PhongBanId != null)
                original.PhongBanId = request.PhongBanId;

            _nhanVienRepository.Update(original);
            await _nhanVienRepository.SaveChangesAsync();
            return _mapper.Map<GetNhanVienDTO>(original);
        }

        public async Task<bool> DeleteNhanVien(Guid id)
        {
            await _nhanVienRepository.Delete(id);
            return await _nhanVienRepository.SaveChangesAsync() > 0;
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

        public async Task<bool> GetUserByEmail(string email)
        {
            return await _userRepository.GetByEmail(email) != null ? true : false;
        }

        public async Task<bool> GetChucVuById(Guid id)
        {
            return await _chucVuRepository.GetById(id) != null ? true : false;
        }

        public async Task<bool> GetPhongBanById(Guid id)
        {
            return await _phongBanRepository.GetById(id) != null ? true : false;
        }
    }
}
