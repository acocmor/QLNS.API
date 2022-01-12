using QLNS.Domain.Repositories;
using QLNS.API.Infrastructure.Repositories;
using QLNS.Domain.Entities;
using QLNS.Infrastructure.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

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
    }
}
