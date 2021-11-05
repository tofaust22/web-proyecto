using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioUser",
                table: "Persona",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Modulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    User = table.Column<string>(type: "varchar(30)", nullable: false),
                    Password = table.Column<string>(type: "varchar(15)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(25)", nullable: true),
                    Apellidos = table.Column<string>(type: "varchar(25)", nullable: true),
                    Tipo = table.Column<string>(type: "varchar(15)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.User);
                });

            migrationBuilder.CreateTable(
                name: "PermisoRol",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermisoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RolId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisoRol", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_PermisoRol_Permiso_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "Permiso",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermisoRol_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(30)", nullable: true),
                    RolId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsuarioUser = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRol", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "User",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Usuario_UsuarioUser",
                        column: x => x.UsuarioUser,
                        principalTable: "Usuario",
                        principalColumn: "User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[,]
                {
                    { "1", "ADMINISTRADOR" },
                    { "2", "DOCTOR" },
                    { "3", "PACIENTE" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "User", "Apellidos", "Estado", "Nombre", "Password", "Tipo" },
                values: new object[] { "Admin", null, "Activo", null, "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_UsuarioUser",
                table: "Persona",
                column: "UsuarioUser");

            migrationBuilder.CreateIndex(
                name: "IX_PermisoRol_PermisoId",
                table: "PermisoRol",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisoRol_RolId",
                table: "PermisoRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_RolId",
                table: "UsuarioRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_UsuarioId",
                table: "UsuarioRol",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_UsuarioUser",
                table: "UsuarioRol",
                column: "UsuarioUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Usuario_UsuarioUser",
                table: "Persona",
                column: "UsuarioUser",
                principalTable: "Usuario",
                principalColumn: "User",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Usuario_UsuarioUser",
                table: "Persona");

            migrationBuilder.DropTable(
                name: "PermisoRol");

            migrationBuilder.DropTable(
                name: "UsuarioRol");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Persona_UsuarioUser",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "UsuarioUser",
                table: "Persona");
        }
    }
}
