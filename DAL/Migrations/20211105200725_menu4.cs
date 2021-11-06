using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class menu4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modulos",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[] { "2", "Doctor" });

            migrationBuilder.InsertData(
                table: "Programas",
                columns: new[] { "Codigo", "IdModulo", "Nombre" },
                values: new object[] { "3", "2", "/registro-doctor" });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Codigo", "Descripcion", "IdPrograma", "Modulo" },
                values: new object[] { "3", "Registro de Doctores", "3", null });

            migrationBuilder.InsertData(
                table: "PermisoRoles",
                columns: new[] { "Codigo", "PermisoId", "RolId" },
                values: new object[] { "3", "3", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermisoRoles",
                keyColumn: "Codigo",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Modulos",
                keyColumn: "Codigo",
                keyValue: "2");
        }
    }
}
