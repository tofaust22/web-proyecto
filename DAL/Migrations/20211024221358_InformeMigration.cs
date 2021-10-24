using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InformeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdCita",
                table: "Informes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Informes_IdCita",
                table: "Informes",
                column: "IdCita");

            migrationBuilder.AddForeignKey(
                name: "FK_Informes_Citas_IdCita",
                table: "Informes",
                column: "IdCita",
                principalTable: "Citas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Informes_Citas_IdCita",
                table: "Informes");

            migrationBuilder.DropIndex(
                name: "IX_Informes_IdCita",
                table: "Informes");

            migrationBuilder.DropColumn(
                name: "IdCita",
                table: "Informes");
        }
    }
}
