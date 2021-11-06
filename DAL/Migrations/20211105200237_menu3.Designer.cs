﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ProyectoContext))]
    [Migration("20211105200237_menu3")]
    partial class menu3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Agenda", b =>
                {
                    b.Property<string>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.HasKey("Codigo");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("Entity.Cita", b =>
                {
                    b.Property<string>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodigoAgenda")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdPaciente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoAgenda");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("Entity.DetalleProducto", b =>
                {
                    b.Property<string>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdProducto")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InformeCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal");

                    b.HasKey("Codigo");

                    b.HasIndex("IdProducto");

                    b.HasIndex("InformeCodigo");

                    b.ToTable("DetalleProducto");
                });

            modelBuilder.Entity("Entity.Especialidad", b =>
                {
                    b.Property<string>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Especialidades");

                    b.HasData(
                        new
                        {
                            Codigo = "123",
                            Nombre = "Odontólogo general"
                        },
                        new
                        {
                            Codigo = "1234",
                            Nombre = "Odontopediatra"
                        },
                        new
                        {
                            Codigo = "1235",
                            Nombre = "Periodoncista"
                        },
                        new
                        {
                            Codigo = "1236",
                            Nombre = "Endodoncista"
                        },
                        new
                        {
                            Codigo = "1237",
                            Nombre = "Cirujano Oral"
                        },
                        new
                        {
                            Codigo = "1238",
                            Nombre = "Prostodoncista"
                        });
                });

            modelBuilder.Entity("Entity.Historia", b =>
                {
                    b.Property<string>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.ToTable("Historia");
                });

            modelBuilder.Entity("Entity.Informe", b =>
                {
                    b.Property<string>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Diagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("HistoriaCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdCita")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdDoctor")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.HasIndex("HistoriaCodigo");

                    b.HasIndex("IdCita");

                    b.HasIndex("IdDoctor");

                    b.ToTable("Informes");
                });

            modelBuilder.Entity("Entity.ModuleMenu", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Modulos");

                    b.HasData(
                        new
                        {
                            Codigo = "1",
                            Nombre = "Configuracion"
                        });
                });

            modelBuilder.Entity("Entity.Permiso", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdPrograma")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Modulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.HasIndex("IdPrograma");

                    b.ToTable("Permisos");

                    b.HasData(
                        new
                        {
                            Codigo = "1",
                            Descripcion = "Configuracion de permisos",
                            IdPrograma = "1"
                        },
                        new
                        {
                            Codigo = "2",
                            Descripcion = "Crear Modulos del menu",
                            IdPrograma = "2"
                        });
                });

            modelBuilder.Entity("Entity.PermisoRol", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PermisoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RolId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Codigo");

                    b.HasIndex("PermisoId");

                    b.HasIndex("RolId");

                    b.ToTable("PermisoRoles");

                    b.HasData(
                        new
                        {
                            Codigo = "1",
                            PermisoId = "1",
                            RolId = "1"
                        },
                        new
                        {
                            Codigo = "2",
                            PermisoId = "2",
                            RolId = "1"
                        });
                });

            modelBuilder.Entity("Entity.Persona", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioUser")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Identificacion");

                    b.HasIndex("UsuarioUser");

                    b.ToTable("Persona");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Entity.Producto", b =>
                {
                    b.Property<string>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal");

                    b.HasKey("Codigo");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Entity.ProgramaMenu", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdModulo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.HasIndex("IdModulo");

                    b.ToTable("Programas");

                    b.HasData(
                        new
                        {
                            Codigo = "1",
                            IdModulo = "1",
                            Nombre = "/configurarPermisos"
                        },
                        new
                        {
                            Codigo = "2",
                            IdModulo = "1",
                            Nombre = "/crearModulo"
                        });
                });

            modelBuilder.Entity("Entity.Rol", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Codigo = "1",
                            Nombre = "ADMINISTRADOR"
                        },
                        new
                        {
                            Codigo = "2",
                            Nombre = "DOCTOR"
                        },
                        new
                        {
                            Codigo = "3",
                            Nombre = "PACIENTE"
                        });
                });

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.Property<string>("User")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(15)");

                    b.HasKey("User");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            User = "Admin",
                            Estado = "Activo",
                            Password = "Admin"
                        });
                });

            modelBuilder.Entity("Entity.UsuarioRol", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RolId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Codigo");

                    b.HasIndex("RolId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioRoles");

                    b.HasData(
                        new
                        {
                            Codigo = "1",
                            RolId = "1",
                            UsuarioId = "Admin"
                        });
                });

            modelBuilder.Entity("Entity.Doctor", b =>
                {
                    b.HasBaseType("Entity.Persona");

                    b.Property<string>("AgendaCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdEspecialidad")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("AgendaCodigo");

                    b.HasIndex("IdEspecialidad");

                    b.ToTable("Persona");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("Entity.Paciente", b =>
                {
                    b.HasBaseType("Entity.Persona");

                    b.Property<string>("DepartamentoResidencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HistoriaCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ocupacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoAseguradora")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("HistoriaCodigo");

                    b.ToTable("Persona");

                    b.HasDiscriminator().HasValue("Paciente");
                });

            modelBuilder.Entity("Entity.Cita", b =>
                {
                    b.HasOne("Entity.Agenda", null)
                        .WithMany()
                        .HasForeignKey("CodigoAgenda");

                    b.HasOne("Entity.Paciente", null)
                        .WithMany()
                        .HasForeignKey("IdPaciente");
                });

            modelBuilder.Entity("Entity.DetalleProducto", b =>
                {
                    b.HasOne("Entity.Producto", null)
                        .WithMany()
                        .HasForeignKey("IdProducto");

                    b.HasOne("Entity.Informe", null)
                        .WithMany("Detalles")
                        .HasForeignKey("InformeCodigo");
                });

            modelBuilder.Entity("Entity.Informe", b =>
                {
                    b.HasOne("Entity.Historia", null)
                        .WithMany("Informes")
                        .HasForeignKey("HistoriaCodigo");

                    b.HasOne("Entity.Cita", null)
                        .WithMany()
                        .HasForeignKey("IdCita");

                    b.HasOne("Entity.Doctor", null)
                        .WithMany()
                        .HasForeignKey("IdDoctor");
                });

            modelBuilder.Entity("Entity.Permiso", b =>
                {
                    b.HasOne("Entity.ProgramaMenu", null)
                        .WithMany()
                        .HasForeignKey("IdPrograma");
                });

            modelBuilder.Entity("Entity.PermisoRol", b =>
                {
                    b.HasOne("Entity.Permiso", null)
                        .WithMany()
                        .HasForeignKey("PermisoId");

                    b.HasOne("Entity.Rol", null)
                        .WithMany()
                        .HasForeignKey("RolId");
                });

            modelBuilder.Entity("Entity.Persona", b =>
                {
                    b.HasOne("Entity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioUser");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entity.ProgramaMenu", b =>
                {
                    b.HasOne("Entity.ModuleMenu", null)
                        .WithMany()
                        .HasForeignKey("IdModulo");
                });

            modelBuilder.Entity("Entity.UsuarioRol", b =>
                {
                    b.HasOne("Entity.Rol", null)
                        .WithMany()
                        .HasForeignKey("RolId");

                    b.HasOne("Entity.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Entity.Doctor", b =>
                {
                    b.HasOne("Entity.Agenda", "Agenda")
                        .WithMany()
                        .HasForeignKey("AgendaCodigo");

                    b.HasOne("Entity.Especialidad", null)
                        .WithMany()
                        .HasForeignKey("IdEspecialidad");

                    b.Navigation("Agenda");
                });

            modelBuilder.Entity("Entity.Paciente", b =>
                {
                    b.HasOne("Entity.Historia", "Historia")
                        .WithMany()
                        .HasForeignKey("HistoriaCodigo");

                    b.Navigation("Historia");
                });

            modelBuilder.Entity("Entity.Historia", b =>
                {
                    b.Navigation("Informes");
                });

            modelBuilder.Entity("Entity.Informe", b =>
                {
                    b.Navigation("Detalles");
                });
#pragma warning restore 612, 618
        }
    }
}
