using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Extensiones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Vendedores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Proveedores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DireccionId",
                table: "Bodegas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendedores_UsuarioId",
                table: "Vendedores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_UsuarioId",
                table: "Proveedores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodegas_DireccionId",
                table: "Bodegas",
                column: "DireccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodegas_Direccion_DireccionId",
                table: "Bodegas",
                column: "DireccionId",
                principalTable: "Direccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_Usuarios_UsuarioId",
                table: "Proveedores",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedores_Usuarios_UsuarioId",
                table: "Vendedores",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bodegas_Direccion_DireccionId",
                table: "Bodegas");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_Usuarios_UsuarioId",
                table: "Proveedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendedores_Usuarios_UsuarioId",
                table: "Vendedores");

            migrationBuilder.DropIndex(
                name: "IX_Vendedores_UsuarioId",
                table: "Vendedores");

            migrationBuilder.DropIndex(
                name: "IX_Proveedores_UsuarioId",
                table: "Proveedores");

            migrationBuilder.DropIndex(
                name: "IX_Bodegas_DireccionId",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "DireccionId",
                table: "Bodegas");
        }
    }
}
