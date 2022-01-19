using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QLNS.API.Application.DTOs.User;
using QLNS.API.Application.Interfaces;
using QLNS.Domain.Entities;
using QLNS.Domain.Repositories;
using QLNS.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.API.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration config)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _config = config;
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

            if(original.Password.Equals(request.OldPassword))
            {
                original.Password = request.Password;
            } else
            {
                return null;
            }

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

        public async Task<GetUserDTO> Authencate(LoginUserDTO login)
        {
            var user = await _userRepository.GetByLogin(login);
            if (user == null) return null;
            return _mapper.Map<GetUserDTO>(user);
        }

        public async Task<string> Generate(GetUserDTO user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                //new Claim(ClaimTypes.NameIdentifier, user.Email),
                //new Claim(ClaimTypes.GivenName, user.NhanVien.Ten),
                //new Claim(ClaimTypes.Surname, user.NhanVien.Ho),
                //new Claim(ClaimTypes.Role, user?.NhanVien?.ChucVu.TenChucVu)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issure"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

    

