using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class menu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "1",
                column: "Descripcion",
                value: "Configuracion de permisos");

            migrationBuilder.InsertData(
                table: "Programas",
                columns: new[] { "Codigo", "IdModulo", "Nombre" },
                values: new object[] { "2", "1", "/crearModulo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "1",
                column: "Descripcion",
                value: null);
        }
    }
}
