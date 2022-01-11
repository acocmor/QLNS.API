using QLNS.Domain.Repositories;
using QLNS.API.Infrastructure.Repositories;
using QLNS.Domain.Entities;
using QLNS.Infrastructure.Context;

namespace QLNS.Infrastructure.Repositories
{
    public class QueQuanRepository : Repository<QueQuan>, IQueQuanRepository
    {
        public QueQuanRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
