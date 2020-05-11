using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class Distribucion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComprobanteId",
                table: "Ventas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Ventas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Ventas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Impuesto",
                table: "Ventas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pagado",
                table: "Ventas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Ventas",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Descuento",
                table: "VentaDetalles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "VentaDetalles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Subcategorias",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Subcategorias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Subcategorias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contacto",
                table: "Proveedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Proveedores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "ProductosBodegas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Productos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Productos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Productos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Productos",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Productos",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Productos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DireccionId",
                table: "Personas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentoId",
                table: "Personas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Personas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Personas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Personas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Devoluciones",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Devoluciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Devoluciones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Devoluciones",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Devoluciones",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "DevolucionDetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "DevolucionDetalles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Conductores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelada",
                table: "Compras",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ComprobanteId",
                table: "Compras",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Compras",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Impuesto",
                table: "Compras",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pagado",
                table: "Compras",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Compras",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "CompraDetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "CompraDetalles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "CompraDetalles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Categorias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Categorias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Bodegas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Bodegas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Bodegas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Bodegas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Comprobante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<int>(nullable: false),
                    Numero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deudas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonaId = table.Column<int>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    Pagado = table.Column<double>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deudas_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pais = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    Barrio = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    Numero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BodegaId = table.Column<int>(nullable: true),
                    ComprobanteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Bodegas_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodegas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Comprobante_ComprobanteId",
                        column: x => x.ComprobanteId,
                        principalTable: "Comprobante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Distribuciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehiculoId = table.Column<int>(nullable: true),
                    RutaId = table.Column<int>(nullable: true),
                    ConductorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distribuciones_Conductores_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Distribuciones_Rutas_RutaId",
                        column: x => x.RutaId,
                        principalTable: "Rutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Distribuciones_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DistribucionDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DistribucionId = table.Column<int>(nullable: true),
                    VentaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistribucionDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistribucionDetalles_Distribuciones_DistribucionId",
                        column: x => x.DistribucionId,
                        principalTable: "Distribuciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DistribucionDetalles_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DistribucionVendedores",
                columns: table => new
                {
                    DistribucionId = table.Column<int>(nullable: false),
                    VendedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistribucionVendedores", x => new { x.VendedorId, x.DistribucionId });
                    table.ForeignKey(
                        name: "FK_DistribucionVendedores_Distribuciones_DistribucionId",
                        column: x => x.DistribucionId,
                        principalTable: "Distribuciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistribucionVendedores_Vendedores_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ComprobanteId",
                table: "Ventas",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_UsuarioId",
                table: "Ventas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Username",
                table: "Usuarios",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DireccionId",
                table: "Personas",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DocumentoId",
                table: "Personas",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Devoluciones_UsuarioId",
                table: "Devoluciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DevolucionDetalles_ProductoId",
                table: "DevolucionDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ComprobanteId",
                table: "Compras",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuarioId",
                table: "Compras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CompraDetalles_ProductoId",
                table: "CompraDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Deudas_PersonaId",
                table: "Deudas",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribucionDetalles_DistribucionId",
                table: "DistribucionDetalles",
                column: "DistribucionId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribucionDetalles_VentaId",
                table: "DistribucionDetalles",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Distribuciones_ConductorId",
                table: "Distribuciones",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_Distribuciones_RutaId",
                table: "Distribuciones",
                column: "RutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Distribuciones_VehiculoId",
                table: "Distribuciones",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribucionVendedores_DistribucionId",
                table: "DistribucionVendedores",
                column: "DistribucionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_BodegaId",
                table: "Vehiculos",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ComprobanteId",
                table: "Vehiculos",
                column: "ComprobanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompraDetalles_Productos_ProductoId",
                table: "CompraDetalles",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Comprobante_ComprobanteId",
                table: "Compras",
                column: "ComprobanteId",
                principalTable: "Comprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Usuarios_UsuarioId",
                table: "Compras",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DevolucionDetalles_Productos_ProductoId",
                table: "DevolucionDetalles",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Devoluciones_Usuarios_UsuarioId",
                table: "Devoluciones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Direccion_DireccionId",
                table: "Personas",
                column: "DireccionId",
                principalTable: "Direccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Comprobante_DocumentoId",
                table: "Personas",
                column: "DocumentoId",
                principalTable: "Comprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Comprobante_ComprobanteId",
                table: "Ventas",
                column: "ComprobanteId",
                principalTable: "Comprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Usuarios_UsuarioId",
                table: "Ventas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompraDetalles_Productos_ProductoId",
                table: "CompraDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Comprobante_ComprobanteId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Usuarios_UsuarioId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_DevolucionDetalles_Productos_ProductoId",
                table: "DevolucionDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_Devoluciones_Usuarios_UsuarioId",
                table: "Devoluciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Direccion_DireccionId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Comprobante_DocumentoId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Comprobante_ComprobanteId",
                table: "Ventas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Usuarios_UsuarioId",
                table: "Ventas");

            migrationBuilder.DropTable(
                name: "Deudas");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "DistribucionDetalles");

            migrationBuilder.DropTable(
                name: "DistribucionVendedores");

            migrationBuilder.DropTable(
                name: "Distribuciones");

            migrationBuilder.DropTable(
                name: "Rutas");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Comprobante");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_ComprobanteId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_UsuarioId",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Username",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Personas_DireccionId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_DocumentoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Devoluciones_UsuarioId",
                table: "Devoluciones");

            migrationBuilder.DropIndex(
                name: "IX_DevolucionDetalles_ProductoId",
                table: "DevolucionDetalles");

            migrationBuilder.DropIndex(
                name: "IX_Compras_ComprobanteId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_UsuarioId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_CompraDetalles_ProductoId",
                table: "CompraDetalles");

            migrationBuilder.DropColumn(
                name: "ComprobanteId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Impuesto",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Pagado",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Descuento",
                table: "VentaDetalles");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "VentaDetalles");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Subcategorias");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Subcategorias");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Subcategorias");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Contacto",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "ProductosBodegas");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "DireccionId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "DocumentoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Devoluciones");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Devoluciones");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Devoluciones");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Devoluciones");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Devoluciones");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "DevolucionDetalles");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "DevolucionDetalles");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Conductores");

            migrationBuilder.DropColumn(
                name: "Cancelada",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "ComprobanteId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "Impuesto",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "Pagado",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "CompraDetalles");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "CompraDetalles");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "CompraDetalles");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Bodegas");
        }
    }
}
