using QLNS.API.Infrastructure.Repositories;
using QLNS.Domain.Entities;
using QLNS.Domain.Repositories;
using QLNS.Infrastructure.Context;

namespace QLNS.Infrastructure.Repositories
{
    public class HopDongLaoDongRepository : Repository<HopDongLaoDong>, IHopDongLaoDongRepository
    {
        public HopDongLaoDongRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
