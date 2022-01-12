using QLNS.Domain.Repositories;
using QLNS.API.Infrastructure.Repositories;
using QLNS.Domain.Entities;
using QLNS.Infrastructure.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace QLNS.Infrastructure.Repositories
{
    public class QueQuanRepository : Repository<QueQuan>, IQueQuanRepository
    {
        public QueQuanRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<QueQuan>> GetAll()
        {
            return await DbSet.AsNoTracking()
                                .Include(x => x.NhanVien)
                                .Include(x => x.NhanVien.User)
                                .Include(x => x.NhanVien.PhongBan)
                                .Include(x => x.NhanVien.ChucVu)
                                .ToListAsync();
        }

        public override async Task<QueQuan> GetById(Guid id)
        {
            return await DbSet
                        .AsNoTracking()
                        .Include(x => x.NhanVien)
                        .Include(x => x.NhanVien.User)
                        .Include(x => x.NhanVien.PhongBan)
                        .Include(x => x.NhanVien.ChucVu)
                        .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
