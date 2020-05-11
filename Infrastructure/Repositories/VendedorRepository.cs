using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class VendedorRepository : GenericRepository<Vendedor>, IVendedorRepository
    {
        public VendedorRepository(IDbContext context) : base(context)
        {
        }
    }
}