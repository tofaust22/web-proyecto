using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class menuh2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modulos",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[] { "3", "Paciente" });

            migrationBuilder.InsertData(
                table: "Modulos",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[] { "4", "Producto" });

            migrationBuilder.InsertData(
                table: "Modulos",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[] { "5", "Cita" });

            migrationBuilder.InsertData(
                table: "Programas",
                columns: new[] { "Codigo", "IdModulo", "Nombre", "Ruta" },
                values: new object[,]
                {
                    { "5", "3", "Registro Paciente", "/registro-pacientes" },
                    { "6", "3", "Consultar Pacientes", "/lista-pacientes" },
                    { "7", "4", "Registrar Producto", "/registro-productos" },
                    { "8", "4", "Consultar Productos", "/productosLista" },
                    { "9", "5", "Registrar Cita", "/registro-cita" }
                });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Codigo", "Descripcion", "IdPrograma", "Modulo" },
                values: new object[,]
                {
                    { "5", "Registro Paciente", "5", null },
                    { "6", "Consulta de pacientes", "6", null },
                    { "7", "Registro de productos", "7", null },
                    { "8", "Consulta de productos", "8", null },
                    { "9", "Registro de citas medicas", "9", null }
                });

            migrationBuilder.InsertData(
                table: "PermisoRoles",
                columns: new[] { "Codigo", "PermisoId", "RolId" },
                values: new object[,]
                {
                    { "5", "5", "1" },
                    { "6", "6", "1" },
                    { "7", "7", "1" },
                    { "8", "8", "1" },
                    { "9", "9", "1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermisoRoles",
                keyColumn: "Codigo",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "PermisoRoles",
                keyColumn: "Codigo",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "PermisoRoles",
                keyColumn: "Codigo",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "PermisoRoles",
                keyColumn: "Codigo",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "PermisoRoles",
                keyColumn: "Codigo",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "Modulos",
                keyColumn: "Codigo",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Modulos",
                keyColumn: "Codigo",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Modulos",
                keyColumn: "Codigo",
                keyValue: "5");
        }
    }
}
