using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class ConductorRepository : GenericRepository<Conductor>, IConductorRepository
    {
        public ConductorRepository(IDbContext context) : base(context)
        {
        }
    }
}