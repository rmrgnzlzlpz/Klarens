using Domain.Repositories;
using System;

namespace Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repositories
        IBodegaRepository BodegaRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        ICompraRepository CompraRepository { get; }
        IConductorRepository ConductorRepository { get; }
        IDeudaRepository DeudaRepository { get; }
        IDevolucionRepository DevolucionRepository { get; }
        IDistribucionRepository DistribucionRepository { get; }
        IDistribucionVendedorRepository DistribucionVendedorRepository { get; }
        IPersonaRepository PersonaRepository { get; }
        IProductoBodegaRepository ProductoBodegaRepository {get;}
        IProductoRepository ProductoRepository { get; }
        IProveedorRepository ProveedorRepository { get; }
        IRolRepository RolRepository { get; }
        IRutaRepository RutaRepository { get; }
        ISubcategoriaRepository SubcategoriaRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IVehiculoRepository VehiculoRepository { get; }
        IVendedorRepository VendedorRepository { get; }
        IVentaRepository VentaRepository { get; }
        #endregion

        int Commit();
    }
}
