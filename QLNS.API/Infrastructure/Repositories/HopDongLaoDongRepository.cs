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
    public class HopDongLaoDongRepository : Repository<HopDongLaoDong>, IHopDongLaoDongRepository
    {
        public HopDongLaoDongRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<HopDongLaoDong>> GetAll()
        {
            return await DbSet.AsNoTracking()
                                .Include(x => x.NhanVien)
                                .Include(x => x.NhanVien.User)
                                .Include(x => x.NhanVien.QueQuan)
                                .Include(x => x.NhanVien.PhongBan)
                                .Include(x => x.NhanVien.ChucVu)
                                .ToListAsync();
        }

        public override async Task<HopDongLaoDong> GetById(Guid id)
        {
            return await DbSet
                        .AsNoTracking()
                        .Include(x => x.NhanVien)
                        .Include(x => x.NhanVien.User)
                        .Include(x => x.NhanVien.QueQuan)
                        .Include(x => x.NhanVien.PhongBan)
                        .Include(x => x.NhanVien.ChucVu)
                        .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
