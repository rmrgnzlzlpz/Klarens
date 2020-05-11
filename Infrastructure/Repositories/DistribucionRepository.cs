using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class DistribucionRepository : GenericRepository<Distribucion>, IDistribucionRepository
    {
        public DistribucionRepository(IDbContext context) : base(context)
        {
        }
    }
}