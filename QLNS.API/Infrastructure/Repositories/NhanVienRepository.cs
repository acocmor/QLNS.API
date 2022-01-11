using Microsoft.EntityFrameworkCore;
using QLNS.API.Infrastructure.Repositories;
using QLNS.Domain.Entities;
using QLNS.Domain.Repositories;
using QLNS.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLNS.Infrastructure.Repositories
{
    public class NhanVienRepository : Repository<NhanVien>, INhanVienRepository
    {
        public NhanVienRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<NhanVien>> GetAll()
        {
            return await DbSet.AsNoTracking()
                                .Include(x => x.User)
                                .Include(x => x.QueQuan)
                                .Include(x => x.ChucVu)
                                .Include(x => x.PhongBan)
                                .ToListAsync();
        }

        public override async Task<NhanVien> GetById(Guid id)
        {
            return await DbSet
                        .AsNoTracking()
                        .Include(x => x.User)
                        .Include(x => x.QueQuan)
                        .Include(x => x.ChucVu)
                        .Include(x => x.PhongBan)
                        .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
