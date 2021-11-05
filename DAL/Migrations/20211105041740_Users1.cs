using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Users1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UsuarioRol",
                columns: new[] { "Codigo", "RolId", "UsuarioId", "UsuarioUser" },
                values: new object[] { "1", "1", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsuarioRol",
                keyColumn: "Codigo",
                keyValue: "1");
        }
    }
}
