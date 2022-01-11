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
    public class ChucVuRepository : Repository<ChucVu>, IChucVuRepository
    {
        public ChucVuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<ChucVu>> GetAll()
        {
            return await DbSet.AsNoTracking().Include(x => x.DanhSachNhanVien).ToListAsync();
        }

        public override async Task<ChucVu> GetById(Guid id)
        {
            return await DbSet
                        .AsNoTracking()
                        .Include(x => x.DanhSachNhanVien)
                        .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
