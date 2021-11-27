using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modulos",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[] { "6", "Agenda" });

            migrationBuilder.InsertData(
                table: "Modulos",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[] { "7", "Perfil" });

            migrationBuilder.InsertData(
                table: "Programas",
                columns: new[] { "Codigo", "IdModulo", "Nombre", "Ruta" },
                values: new object[] { "11", "6", "Consultar Agenda", "/lista-citas" });

            migrationBuilder.InsertData(
                table: "Programas",
                columns: new[] { "Codigo", "IdModulo", "Nombre", "Ruta" },
                values: new object[] { "12", "7", "Consultar Perfil", "/history-paciente" });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Codigo", "Descripcion", "IdPrograma", "Modulo" },
                values: new object[] { "11", "Consulta la agenda del doctor", "11", null });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Codigo", "Descripcion", "IdPrograma", "Modulo" },
                values: new object[] { "12", "Consulta el perfil, donde esta la informacion personal e historia", "12", null });

            migrationBuilder.InsertData(
                table: "PermisoRoles",
                columns: new[] { "Codigo", "PermisoId", "RolId" },
                values: new object[] { "13", "11", "2" });

            migrationBuilder.InsertData(
                table: "PermisoRoles",
                columns: new[] { "Codigo", "PermisoId", "RolId" },
                values: new object[] { "14", "12", "3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermisoRoles",
                keyColumn: "Codigo",
                keyValue: "13");

            migrationBuilder.DeleteData(
                table: "PermisoRoles",
                keyColumn: "Codigo",
                keyValue: "14");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "12");

            migrationBuilder.DeleteData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "11");

            migrationBuilder.DeleteData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "12");

            migrationBuilder.DeleteData(
                table: "Modulos",
                keyColumn: "Codigo",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Modulos",
                keyColumn: "Codigo",
                keyValue: "7");
        }
    }
}
