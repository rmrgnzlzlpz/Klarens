using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class DistribucionVendedorRepository : GenericRepository<DistribucionVendedor>, IDistribucionVendedorRepository
    {
        public DistribucionVendedorRepository(IDbContext context) : base(context)
        {
        }
    }
}