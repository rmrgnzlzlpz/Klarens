using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class ProductoBodegaRepository : GenericRepository<ProductoBodega>, IProductoBodegaRepository
    {
        public ProductoBodegaRepository(IDbContext context) : base(context)
        {
        }
    }
}