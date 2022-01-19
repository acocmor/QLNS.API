using QLNS.Domain.Repositories;
using QLNS.API.Infrastructure.Repositories;
using QLNS.Domain.Entities;
using QLNS.Infrastructure.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using QLNS.API.Application.DTOs.User;

namespace QLNS.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task<IEnumerable<User>> GetAll()
        {
            return await DbSet.AsNoTracking()
                                .Include(x => x.NhanVien)
                                .ToListAsync();
        }

        public override async Task<User> GetById(Guid id)
        {
            return await DbSet
                        .AsNoTracking()
                        .Include(x => x.NhanVien)
                        .Include(x => x.NhanVien.QueQuan)
                        .Include(x => x.NhanVien.ChucVu)
                        .Include(x => x.NhanVien.PhongBan)
                        .Include(x => x.NhanVien.HopDongLaoDong)
                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await DbSet
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<User> GetByLogin(LoginUserDTO user)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Email.Equals(user.Email) && e.Password.Equals(user.Password));
        }
    }
}
