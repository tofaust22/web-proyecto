using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class menu5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ruta",
                table: "Programas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "1",
                columns: new[] { "Nombre", "Ruta" },
                values: new object[] { "Configurar Permisos", "/configurarPermisos" });

            migrationBuilder.UpdateData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "2",
                columns: new[] { "Nombre", "Ruta" },
                values: new object[] { "Crear Modulo", "/crearModulo" });

            migrationBuilder.UpdateData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "3",
                columns: new[] { "Nombre", "Ruta" },
                values: new object[] { "Registro Doctor", "/registro-doctor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ruta",
                table: "Programas");

            migrationBuilder.UpdateData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "1",
                column: "Nombre",
                value: "/configurarPermisos");

            migrationBuilder.UpdateData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "2",
                column: "Nombre",
                value: "/crearModulo");

            migrationBuilder.UpdateData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "3",
                column: "Nombre",
                value: "/registro-doctor");
        }
    }
}
