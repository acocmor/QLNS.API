using QLNS.Domain.Repositories;
using QLNS.API.Infrastructure.Repositories;
using QLNS.Domain.Entities;
using QLNS.Infrastructure.Context;

namespace QLNS.Infrastructure.Repositories
{
    public class PhongBanRepository : Repository<PhongBan>, IPhongBanRepository
    {
        public PhongBanRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
