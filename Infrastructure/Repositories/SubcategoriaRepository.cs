using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class SubcategoriaRepository : GenericRepository<Subcategoria>, ISubcategoriaRepository
    {
        public SubcategoriaRepository(IDbContext context) : base(context)
        {
        }
    }
}