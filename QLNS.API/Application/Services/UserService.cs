using AutoMapper;
using QLNS.API.Application.DTOs.User;
using QLNS.API.Application.Interfaces;
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
        public Task<GetUserDTO> CreateUser(CreateUserDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetUserDTO>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<GetUserDTO> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserDTO> UpdateUser(Guid id, UpdateUserDTO request)
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
                _userRepository.Dispose();
            }
        }
    }
}
