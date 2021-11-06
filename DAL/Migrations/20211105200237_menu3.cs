using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class menu3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Codigo", "Descripcion", "IdPrograma", "Modulo" },
                values: new object[] { "2", "Crear Modulos del menu", "2", null });

            migrationBuilder.InsertData(
                table: "PermisoRoles",
                columns: new[] { "Codigo", "PermisoId", "RolId" },
                values: new object[] { "2", "2", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermisoRoles",
                keyColumn: "Codigo",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "2");
        }
    }
}
