using Domain.Contracts;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _dbContext;
        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }
        #region PrivateRepositories
        private IBodegaRepository _bodegaRepository;
        private ICategoriaRepository _categoriaRepository;
        private ICompraRepository _compraRepository;
        private IConductorRepository _conductorRepository;
        private IDeudaRepository _deudaRepository;
        private IDevolucionRepository _devolucionRepository;
        private IDistribucionRepository _distribucionRepository;
        private IDistribucionVendedorRepository _distribucionVendedorRepository;
        private IPersonaRepository _personaRepository;
        private IProductoBodegaRepository _productoBodegaRepository;
        private IProductoRepository _productoRepository;
        private IProveedorRepository _proveedorRepository;
        private IRolRepository _rolRepository;
        private IRutaRepository _rutaRepository;
        private ISubcategoriaRepository _subcategoriaRepository;
        private IUsuarioRepository _usuarioRepository;
        private IVehiculoRepository _vehiculoRepository;
        private IVendedorRepository _vendedorRepository;
        private IVentaRepository _ventaRepository;
        #endregion
        public IBodegaRepository BodegaRepository { 
            get { return _bodegaRepository ?? (_bodegaRepository = new BodegaRepository(_dbContext)); }
        }
        public ICategoriaRepository CategoriaRepository
        {
            get { return _categoriaRepository ?? (_categoriaRepository = new CategoriaRepository(_dbContext)); }
        }
        public ICompraRepository CompraRepository
        {
            get { return _compraRepository ?? (_compraRepository = new CompraRepository(_dbContext)); }
        }
        public IConductorRepository ConductorRepository
        {
            get { return _conductorRepository ?? (_conductorRepository = new ConductorRepository(_dbContext)); }
        }
        public IDeudaRepository DeudaRepository
        {
            get { return _deudaRepository ?? (_deudaRepository = new DeudaRepository(_dbContext)); }
        }
        public IDevolucionRepository DevolucionRepository
        {
            get { return _devolucionRepository ?? (_devolucionRepository = new DevolucionRepository(_dbContext)); }
        }
        public IDistribucionRepository DistribucionRepository
        {
            get { return _distribucionRepository ?? (_distribucionRepository = new DistribucionRepository(_dbContext)); }
        }
        public IDistribucionVendedorRepository DistribucionVendedorRepository
        {
            get { return _distribucionVendedorRepository ?? (_distribucionVendedorRepository = new DistribucionVendedorRepository(_dbContext)); }
        }
        public IPersonaRepository PersonaRepository
        {
            get { return _personaRepository ?? (_personaRepository = new PersonaRepository(_dbContext)); }
        }
        public IProductoBodegaRepository ProductoBodegaRepository
        {
            get { return _productoBodegaRepository ?? (_productoBodegaRepository = new ProductoBodegaRepository(_dbContext)); }
        }
        public IProductoRepository ProductoRepository
        {
            get { return _productoRepository ?? (_productoRepository = new ProductoRepository(_dbContext)); }
        }
        public IProveedorRepository ProveedorRepository
        {
            get { return _proveedorRepository ?? (_proveedorRepository = new ProveedorRepository(_dbContext)); }
        }
        public IRolRepository RolRepository
        {
            get { return _rolRepository ?? (_rolRepository = new RolRepository(_dbContext)); }
        }
        public IRutaRepository RutaRepository
        {
            get { return _rutaRepository ?? (_rutaRepository = new RutaRepository(_dbContext)); }
        }
        public ISubcategoriaRepository SubcategoriaRepository
        {
            get { return _subcategoriaRepository ?? (_subcategoriaRepository = new SubcategoriaRepository(_dbContext)); }
        }
        public IUsuarioRepository UsuarioRepository
        {
            get { return _usuarioRepository ?? (_usuarioRepository = new UsuarioRepository(_dbContext)); }
        }
        public IVehiculoRepository VehiculoRepository
        {
            get { return _vehiculoRepository ?? (_vehiculoRepository = new VehiculoRepository(_dbContext)); }
        }
        public IVendedorRepository VendedorRepository
        {
            get { return _vendedorRepository ?? (_vendedorRepository = new VendedorRepository(_dbContext)); }
        }
        public IVentaRepository VentaRepository
        {
            get { return _ventaRepository ?? (_ventaRepository = new VentaRepository(_dbContext)); }
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                ((DbContext)_dbContext).Dispose();
                _dbContext = null;
            }
        }
    }
}
