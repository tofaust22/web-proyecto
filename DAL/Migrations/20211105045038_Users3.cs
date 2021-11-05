using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Users3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermisoRol_Permiso_PermisoId",
                table: "PermisoRol");

            migrationBuilder.DropForeignKey(
                name: "FK_PermisoRol_Rol_RolId",
                table: "PermisoRol");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Usuario_UsuarioUser",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_Rol_RolId",
                table: "UsuarioRol");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRol_Usuario_UsuarioId",
                table: "UsuarioRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioRol",
                table: "UsuarioRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermisoRol",
                table: "PermisoRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permiso",
                table: "Permiso");

            migrationBuilder.RenameTable(
                name: "UsuarioRol",
                newName: "UsuarioRoles");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "PermisoRol",
                newName: "PermisoRoles");

            migrationBuilder.RenameTable(
                name: "Permiso",
                newName: "Permisos");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioRol_UsuarioId",
                table: "UsuarioRoles",
                newName: "IX_UsuarioRoles_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioRol_RolId",
                table: "UsuarioRoles",
                newName: "IX_UsuarioRoles_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_PermisoRol_RolId",
                table: "PermisoRoles",
                newName: "IX_PermisoRoles_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_PermisoRol_PermisoId",
                table: "PermisoRoles",
                newName: "IX_PermisoRoles_PermisoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioRoles",
                table: "UsuarioRoles",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermisoRoles",
                table: "PermisoRoles",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permisos",
                table: "Permisos",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_PermisoRoles_Permisos_PermisoId",
                table: "PermisoRoles",
                column: "PermisoId",
                principalTable: "Permisos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermisoRoles_Roles_RolId",
                table: "PermisoRoles",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Usuarios_UsuarioUser",
                table: "Persona",
                column: "UsuarioUser",
                principalTable: "Usuarios",
                principalColumn: "User",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRoles_Roles_RolId",
                table: "UsuarioRoles",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRoles_Usuarios_UsuarioId",
                table: "UsuarioRoles",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "User",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermisoRoles_Permisos_PermisoId",
                table: "PermisoRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PermisoRoles_Roles_RolId",
                table: "PermisoRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Usuarios_UsuarioUser",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRoles_Roles_RolId",
                table: "UsuarioRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRoles_Usuarios_UsuarioId",
                table: "UsuarioRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioRoles",
                table: "UsuarioRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permisos",
                table: "Permisos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermisoRoles",
                table: "PermisoRoles");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "UsuarioRoles",
                newName: "UsuarioRol");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Rol");

            migrationBuilder.RenameTable(
                name: "Permisos",
                newName: "Permiso");

            migrationBuilder.RenameTable(
                name: "PermisoRoles",
                newName: "PermisoRol");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioRoles_UsuarioId",
                table: "UsuarioRol",
                newName: "IX_UsuarioRol_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioRoles_RolId",
                table: "UsuarioRol",
                newName: "IX_UsuarioRol_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_PermisoRoles_RolId",
                table: "PermisoRol",
                newName: "IX_PermisoRol_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_PermisoRoles_PermisoId",
                table: "PermisoRol",
                newName: "IX_PermisoRol_PermisoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioRol",
                table: "UsuarioRol",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permiso",
                table: "Permiso",
                column: "Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermisoRol",
                table: "PermisoRol",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_PermisoRol_Permiso_PermisoId",
                table: "PermisoRol",
                column: "PermisoId",
                principalTable: "Permiso",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PermisoRol_Rol_RolId",
                table: "PermisoRol",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Usuario_UsuarioUser",
                table: "Persona",
                column: "UsuarioUser",
                principalTable: "Usuario",
                principalColumn: "User",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRol_Rol_RolId",
                table: "UsuarioRol",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRol_Usuario_UsuarioId",
                table: "UsuarioRol",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "User",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
