using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdPrograma",
                table: "Permisos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ModuleMenu",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleMenu", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "ProgramaMenu",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdModulo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaMenu", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_ProgramaMenu_ModuleMenu_IdModulo",
                        column: x => x.IdModulo,
                        principalTable: "ModuleMenu",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ModuleMenu",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[] { "1", "Configuracion" });

            migrationBuilder.InsertData(
                table: "ProgramaMenu",
                columns: new[] { "Codigo", "IdModulo", "Nombre" },
                values: new object[] { "1", "1", "/configurarPermisos" });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Codigo", "Descripcion", "IdPrograma", "Modulo" },
                values: new object[] { "1", null, "1", null });

            migrationBuilder.InsertData(
                table: "PermisoRoles",
                columns: new[] { "Codigo", "PermisoId", "RolId" },
                values: new object[] { "1", "1", "1" });

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_IdPrograma",
                table: "Permisos",
                column: "IdPrograma");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaMenu_IdModulo",
                table: "ProgramaMenu",
                column: "IdModulo");

            migrationBuilder.AddForeignKey(
                name: "FK_Permisos_ProgramaMenu_IdPrograma",
                table: "Permisos",
                column: "IdPrograma",
                principalTable: "ProgramaMenu",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permisos_ProgramaMenu_IdPrograma",
                table: "Permisos");

            migrationBuilder.DropTable(
                name: "ProgramaMenu");

            migrationBuilder.DropTable(
                name: "ModuleMenu");

            migrationBuilder.DropIndex(
                name: "IX_Permisos_IdPrograma",
                table: "Permisos");

            migrationBuilder.DeleteData(
                table: "PermisoRoles",
                keyColumn: "Codigo",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "1");

            migrationBuilder.DropColumn(
                name: "IdPrograma",
                table: "Permisos");
        }
    }
}
