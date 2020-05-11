using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class DevolucionRepository : GenericRepository<Devolucion>, IDevolucionRepository
    {
        public DevolucionRepository(IDbContext context) : base(context)
        {
        }
    }
}