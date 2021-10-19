using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Historia",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historia", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEspecialidad = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoAseguradora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ocupacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartamentoResidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoriaCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Persona_Especialidades_IdEspecialidad",
                        column: x => x.IdEspecialidad,
                        principalTable: "Especialidades",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Historia_HistoriaCodigo",
                        column: x => x.HistoriaCodigo,
                        principalTable: "Historia",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDoctor = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdPaciente = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Citas_Persona_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Persona",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Persona_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Persona",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Informe",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDoctor = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoriaCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informe", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Informe_Historia_HistoriaCodigo",
                        column: x => x.HistoriaCodigo,
                        principalTable: "Historia",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Informe_Persona_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Persona",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleProducto",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdProducto = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InformeCodigo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleProducto", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_DetalleProducto_Informe_InformeCodigo",
                        column: x => x.InformeCodigo,
                        principalTable: "Informe",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleProducto_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdDoctor",
                table: "Citas",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdPaciente",
                table: "Citas",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProducto_IdProducto",
                table: "DetalleProducto",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProducto_InformeCodigo",
                table: "DetalleProducto",
                column: "InformeCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Informe_HistoriaCodigo",
                table: "Informe",
                column: "HistoriaCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Informe_IdDoctor",
                table: "Informe",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_HistoriaCodigo",
                table: "Persona",
                column: "HistoriaCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdEspecialidad",
                table: "Persona",
                column: "IdEspecialidad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "DetalleProducto");

            migrationBuilder.DropTable(
                name: "Informe");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Historia");
        }
    }
}
