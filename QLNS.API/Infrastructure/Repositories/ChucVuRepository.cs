using QLNS.API.Infrastructure.Repositories;
using QLNS.Domain.Entities;
using QLNS.Domain.Repositories;
using QLNS.Infrastructure.Context;

namespace QLNS.Infrastructure.Repositories
{
    public class ChucVuRepository : Repository<ChucVu>, IChucVuRepository
    {
        public ChucVuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
