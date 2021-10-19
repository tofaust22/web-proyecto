using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleProducto_Producto_IdProducto",
                table: "DetalleProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
                table: "Producto");

            migrationBuilder.RenameTable(
                name: "Producto",
                newName: "Productos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleProducto_Productos_IdProducto",
                table: "DetalleProducto",
                column: "IdProducto",
                principalTable: "Productos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleProducto_Productos_IdProducto",
                table: "DetalleProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Producto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                table: "Producto",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleProducto_Producto_IdProducto",
                table: "DetalleProducto",
                column: "IdProducto",
                principalTable: "Producto",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
