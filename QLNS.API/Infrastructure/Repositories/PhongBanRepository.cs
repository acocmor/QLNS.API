using QLNS.Domain.Repositories;
using QLNS.API.Infrastructure.Repositories;
using QLNS.Domain.Entities;
using QLNS.Infrastructure.Context;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace QLNS.Infrastructure.Repositories
{
    public class PhongBanRepository : Repository<PhongBan>, IPhongBanRepository
    {
        public PhongBanRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<PhongBan>> GetAll()
        {
            return await DbSet.AsNoTracking()
                            .AsNoTracking()
                            .Include(x => x.DanhSachNhanVien)
                            .ThenInclude(x => x.User)
                            .Include(x => x.DanhSachNhanVien)
                            .ThenInclude(x => x.QueQuan)
                            .Include(x => x.DanhSachNhanVien)
                            .ThenInclude(x => x.ChucVu)
                            .ToListAsync();
        }

        public override async Task<PhongBan> GetById(Guid id)
        {
            return await DbSet
                        .AsNoTracking()
                        .Include(x => x.DanhSachNhanVien)
                        .ThenInclude(x => x.User)
                        .Include(x => x.DanhSachNhanVien)
                        .ThenInclude(x => x.QueQuan)
                        .Include(x => x.DanhSachNhanVien)
                        .ThenInclude(x => x.ChucVu)
                        .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
