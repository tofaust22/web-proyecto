using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class menu1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permisos_ProgramaMenu_IdPrograma",
                table: "Permisos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaMenu_ModuleMenu_IdModulo",
                table: "ProgramaMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramaMenu",
                table: "ProgramaMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleMenu",
                table: "ModuleMenu");

            migrationBuilder.RenameTable(
                name: "ProgramaMenu",
                newName: "Programas");

            migrationBuilder.RenameTable(
                name: "ModuleMenu",
                newName: "Modulos");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramaMenu_IdModulo",
                table: "Programas",
                newName: "IX_Programas_IdModulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programas",
                table: "Programas",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modulos",
                table: "Modulos",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Permisos_Programas_IdPrograma",
                table: "Permisos",
                column: "IdPrograma",
                principalTable: "Programas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programas_Modulos_IdModulo",
                table: "Programas",
                column: "IdModulo",
                principalTable: "Modulos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permisos_Programas_IdPrograma",
                table: "Permisos");

            migrationBuilder.DropForeignKey(
                name: "FK_Programas_Modulos_IdModulo",
                table: "Programas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programas",
                table: "Programas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modulos",
                table: "Modulos");

            migrationBuilder.RenameTable(
                name: "Programas",
                newName: "ProgramaMenu");

            migrationBuilder.RenameTable(
                name: "Modulos",
                newName: "ModuleMenu");

            migrationBuilder.RenameIndex(
                name: "IX_Programas_IdModulo",
                table: "ProgramaMenu",
                newName: "IX_ProgramaMenu_IdModulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramaMenu",
                table: "ProgramaMenu",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleMenu",
                table: "ModuleMenu",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Permisos_ProgramaMenu_IdPrograma",
                table: "Permisos",
                column: "IdPrograma",
                principalTable: "ProgramaMenu",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaMenu_ModuleMenu_IdModulo",
                table: "ProgramaMenu",
                column: "IdModulo",
                principalTable: "ModuleMenu",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
