using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class BodegaRepository : GenericRepository<Bodega>, IBodegaRepository
    {
        public BodegaRepository(IDbContext context) : base(context)
        {
        }
    }
}