using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleProducto_Informe_InformeCodigo",
                table: "DetalleProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_Informe_Historia_HistoriaCodigo",
                table: "Informe");

            migrationBuilder.DropForeignKey(
                name: "FK_Informe_Persona_IdDoctor",
                table: "Informe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Informe",
                table: "Informe");

            migrationBuilder.RenameTable(
                name: "Informe",
                newName: "Informes");

            migrationBuilder.RenameIndex(
                name: "IX_Informe_IdDoctor",
                table: "Informes",
                newName: "IX_Informes_IdDoctor");

            migrationBuilder.RenameIndex(
                name: "IX_Informe_HistoriaCodigo",
                table: "Informes",
                newName: "IX_Informes_HistoriaCodigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Informes",
                table: "Informes",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleProducto_Informes_InformeCodigo",
                table: "DetalleProducto",
                column: "InformeCodigo",
                principalTable: "Informes",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Informes_Historia_HistoriaCodigo",
                table: "Informes",
                column: "HistoriaCodigo",
                principalTable: "Historia",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Informes_Persona_IdDoctor",
                table: "Informes",
                column: "IdDoctor",
                principalTable: "Persona",
                principalColumn: "Identificacion",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleProducto_Informes_InformeCodigo",
                table: "DetalleProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_Informes_Historia_HistoriaCodigo",
                table: "Informes");

            migrationBuilder.DropForeignKey(
                name: "FK_Informes_Persona_IdDoctor",
                table: "Informes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Informes",
                table: "Informes");

            migrationBuilder.RenameTable(
                name: "Informes",
                newName: "Informe");

            migrationBuilder.RenameIndex(
                name: "IX_Informes_IdDoctor",
                table: "Informe",
                newName: "IX_Informe_IdDoctor");

            migrationBuilder.RenameIndex(
                name: "IX_Informes_HistoriaCodigo",
                table: "Informe",
                newName: "IX_Informe_HistoriaCodigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Informe",
                table: "Informe",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleProducto_Informe_InformeCodigo",
                table: "DetalleProducto",
                column: "InformeCodigo",
                principalTable: "Informe",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Informe_Historia_HistoriaCodigo",
                table: "Informe",
                column: "HistoriaCodigo",
                principalTable: "Historia",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Informe_Persona_IdDoctor",
                table: "Informe",
                column: "IdDoctor",
                principalTable: "Persona",
                principalColumn: "Identificacion",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
