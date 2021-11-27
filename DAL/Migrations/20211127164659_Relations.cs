using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Informes_Historia_HistoriaCodigo",
                table: "Informes");

            migrationBuilder.RenameColumn(
                name: "HistoriaCodigo",
                table: "Informes",
                newName: "IdHistoria");

            migrationBuilder.RenameIndex(
                name: "IX_Informes_HistoriaCodigo",
                table: "Informes",
                newName: "IX_Informes_IdHistoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Informes_Historia_IdHistoria",
                table: "Informes",
                column: "IdHistoria",
                principalTable: "Historia",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Informes_Historia_IdHistoria",
                table: "Informes");

            migrationBuilder.RenameColumn(
                name: "IdHistoria",
                table: "Informes",
                newName: "HistoriaCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_Informes_IdHistoria",
                table: "Informes",
                newName: "IX_Informes_HistoriaCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Informes_Historia_HistoriaCodigo",
                table: "Informes",
                column: "HistoriaCodigo",
                principalTable: "Historia",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
