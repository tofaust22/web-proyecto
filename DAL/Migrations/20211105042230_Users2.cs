using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Users2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_Usuario_UsuarioUser",
                table: "UsuarioRol");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioRol_UsuarioUser",
                table: "UsuarioRol");

            migrationBuilder.DropColumn(
                name: "UsuarioUser",
                table: "UsuarioRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioUser",
                table: "UsuarioRol",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_UsuarioUser",
                table: "UsuarioRol",
                column: "UsuarioUser");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRol_Usuario_UsuarioUser",
                table: "UsuarioRol",
                column: "UsuarioUser",
                principalTable: "Usuario",
                principalColumn: "User",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
