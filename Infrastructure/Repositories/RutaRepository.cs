using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class RutaRepository : GenericRepository<Ruta>, IRutaRepository
    {
        public RutaRepository(IDbContext context) : base(context)
        {
        }
    }
}