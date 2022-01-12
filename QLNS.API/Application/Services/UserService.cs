using AutoMapper;
using QLNS.API.Application.DTOs.User;
using QLNS.API.Application.Interfaces;
using QLNS.Domain.Entities;
using QLNS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<GetUserDTO> CreateUser(CreateUserDTO request)
        {
            try
            {
                var user = _userRepository.Create(_mapper.Map<User>(request));
                await _userRepository.SaveChangesAsync();
                return _mapper.Map<GetUserDTO>(user);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            await _userRepository.Delete(id);
            return await _userRepository.SaveChangesAsync() > 0;
        }

        public async Task<List<GetUserDTO>> GetAllUsers()
        {
            return _mapper.Map<List<GetUserDTO>>(await _userRepository.GetAll());
        }

        public async Task<GetUserDTO> GetUserById(Guid id)
        {
            return _mapper.Map<GetUserDTO>(await _userRepository.GetById(id));
        }

        public async Task<GetUserDTO> UpdateUser(Guid id, UpdateUserDTO request)
        {
            var original = await _userRepository.GetById(id);
            if (original == null) return null;

            original.Password = request.Password;

            _userRepository.Update(original);
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<GetUserDTO>(original);
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
                _userRepository.Dispose();
            }
        }
    }
}
