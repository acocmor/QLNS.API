using QLNS.API.Application.DTOs;
using QLNS.API.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.API.Application.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<List<GetUserDTO>> GetAllUsers();
        Task<GetUserDTO> GetUserById(Guid id);
        Task<GetUserDTO> CreateUser(CreateUserDTO request);
        Task<GetUserDTO> UpdateUser(Guid id, UpdateUserDTO request);
        Task<bool> DeleteUser(Guid id);
    }
}
