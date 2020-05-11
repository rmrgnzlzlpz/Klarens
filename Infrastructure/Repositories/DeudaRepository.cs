using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class DeudaRepository : GenericRepository<Deuda>, IDeudaRepository
    {
        public DeudaRepository(IDbContext context) : base(context)
        {
        }
    }
}