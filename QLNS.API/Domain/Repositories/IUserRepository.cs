using QLNS.API.Application.DTOs.User;
using QLNS.API.Domain.Core.Interfaces;
using QLNS.Domain.Entities;
using System.Threading.Tasks;

namespace QLNS.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByLogin(LoginUserDTO user);
    }
}
