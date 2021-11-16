using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreateCe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Agenda_CodigoAgenda",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Agenda_AgendaCodigo",
                table: "Persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agenda",
                table: "Agenda");

            migrationBuilder.RenameTable(
                name: "Agenda",
                newName: "Agendas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas",
                column: "Codigo");

            migrationBuilder.InsertData(
                table: "Programas",
                columns: new[] { "Codigo", "IdModulo", "Nombre", "Ruta" },
                values: new object[] { "10", "5", "Consulta Citas", "/citas-paciente" });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Codigo", "Descripcion", "IdPrograma", "Modulo" },
                values: new object[] { "10", "Consulta de citas pacientes", "10", null });

            migrationBuilder.InsertData(
                table: "PermisoRoles",
                columns: new[] { "Codigo", "PermisoId", "RolId" },
                values: new object[] { "12", "10", "3" });

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Agendas_CodigoAgenda",
                table: "Citas",
                column: "CodigoAgenda",
                principalTable: "Agendas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Agendas_AgendaCodigo",
                table: "Persona",
                column: "AgendaCodigo",
                principalTable: "Agendas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Agendas_CodigoAgenda",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Agendas_AgendaCodigo",
                table: "Persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas");

            migrationBuilder.DeleteData(
                table: "PermisoRoles",
                keyColumn: "Codigo",
                keyValue: "12");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Codigo",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "Programas",
                keyColumn: "Codigo",
                keyValue: "10");

            migrationBuilder.RenameTable(
                name: "Agendas",
                newName: "Agenda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agenda",
                table: "Agenda",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Agenda_CodigoAgenda",
                table: "Citas",
                column: "CodigoAgenda",
                principalTable: "Agenda",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Agenda_AgendaCodigo",
                table: "Persona",
                column: "AgendaCodigo",
                principalTable: "Agenda",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
