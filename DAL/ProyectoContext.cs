using System;
using Microsoft.EntityFrameworkCore;
using Entity;
using System.Collections.Generic;

namespace DAL
{
    public class ProyectoContext : DbContext
    {
        public ProyectoContext(DbContextOptions options) : base(options){}

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Informe> Informes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<PermisoRol> PermisoRoles { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<ProgramaMenu> Programas { get; set; }
        public DbSet<ModuleMenu> Modulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Doctor>().ToTable("Persona");
            modelBuilder.Entity<Paciente>().ToTable("Persona");

            modelBuilder.Entity<Doctor>()
                .HasOne<Especialidad>().WithMany()
                .HasForeignKey( d => d.IdEspecialidad );
            
            modelBuilder.Entity<Cita>()
                .HasOne<Agenda>().WithMany()
                .HasForeignKey( c => c.CodigoAgenda );

            modelBuilder.Entity<Cita>()
                .HasOne<Paciente>().WithMany()
                .HasForeignKey( c => c.IdPaciente );

            modelBuilder.Entity<DetalleProducto>()
                .HasOne<Producto>().WithMany()
                .HasForeignKey( p => p.IdProducto );
            
            modelBuilder.Entity<Informe>()
                .HasOne<Doctor>().WithMany()
                .HasForeignKey( I => I.IdDoctor );
            
            modelBuilder.Entity<Informe>()
                .HasOne<Cita>().WithMany()
                .HasForeignKey( I => I.IdCita );

            modelBuilder.Entity<PermisoRol>()
                .HasOne<Permiso>().WithMany()
                .HasForeignKey( p => p.PermisoId );
            
            modelBuilder.Entity<PermisoRol>()
                .HasOne<Rol>().WithMany()
                .HasForeignKey( p => p.RolId );
            
            modelBuilder.Entity<UsuarioRol>()
                .HasOne<Usuario>().WithMany()
                .HasForeignKey( u => u.UsuarioId );

            modelBuilder.Entity<UsuarioRol>()
                .HasOne<Rol>().WithMany()
                .HasForeignKey( u => u.RolId );

            modelBuilder.Entity<ProgramaMenu>()
                .HasOne<ModuleMenu>().WithMany()
                .HasForeignKey( m => m.IdModulo );
            
            modelBuilder.Entity<Permiso>()
                .HasOne<ProgramaMenu>().WithMany()
                .HasForeignKey( p => p.IdPrograma );

            modelBuilder.Entity<Especialidad>()
                .HasData(LlenarEspecialidades());

            modelBuilder.Entity<Rol>()
                .HasData(LlenarRoles());

            modelBuilder.Entity<Usuario>()
                .HasData(CrearAdministrador());

            modelBuilder.Entity<UsuarioRol>()
                .HasData(AsignarRolAdmin());

            modelBuilder.Entity<ModuleMenu>()
                .HasData(LlenarMenu());

            modelBuilder.Entity<ProgramaMenu>()
                .HasData(LlenarProgramas());

            modelBuilder.Entity<Permiso>()
                .HasData(LlenarPermisos());

            modelBuilder.Entity<PermisoRol>()
                .HasData(LlenarPermisosRol());
        }

        public List<Rol> LlenarRoles()
        {
            List<Rol> roles = new List<Rol>();
            roles.Add(new Rol(){ Codigo = "1", Nombre = "ADMINISTRADOR" });
            roles.Add(new Rol(){ Codigo = "2", Nombre = "DOCTOR" });
            roles.Add(new Rol(){ Codigo = "3", Nombre = "PACIENTE" });
            return roles;
        }

        public List<UsuarioRol> AsignarRolAdmin()
        {
            List<UsuarioRol> usuRoles = new List<UsuarioRol>();
            usuRoles.Add( new UsuarioRol(){ Codigo = "1", RolId = "1", UsuarioId = "Admin" } );
            return usuRoles;
        }

        public List<PermisoRol> LlenarPermisosRol()
        {
            List<PermisoRol> permisoRols = new List<PermisoRol>();
            //Rol Admin
            permisoRols.Add(new PermisoRol(){ Codigo = "1" , PermisoId = "1", RolId = "1" });
            permisoRols.Add(new PermisoRol(){ Codigo = "2", PermisoId = "2", RolId = "1" });
            permisoRols.Add(new PermisoRol(){ Codigo = "3", PermisoId = "3", RolId = "1" });
            permisoRols.Add(new PermisoRol(){ Codigo = "4", PermisoId = "4", RolId = "1" });
            permisoRols.Add(new PermisoRol(){ Codigo = "5", PermisoId = "5", RolId = "1" });
            permisoRols.Add(new PermisoRol(){ Codigo = "6", PermisoId = "6", RolId = "1" });
            permisoRols.Add(new PermisoRol(){ Codigo = "7", PermisoId = "7", RolId = "1" });
            permisoRols.Add(new PermisoRol(){ Codigo = "8", PermisoId = "8", RolId = "1" });
            permisoRols.Add(new PermisoRol(){ Codigo = "9", PermisoId = "9", RolId = "1" });

            //Rol Doctor
            permisoRols.Add(new PermisoRol(){ Codigo = "10", PermisoId = "8", RolId = "2" });
            //Rol Paciente
            permisoRols.Add(new PermisoRol(){ Codigo = "11", PermisoId = "9", RolId = "3" });
            return permisoRols;
        }

        public List<Permiso> LlenarPermisos()
        {
            List<Permiso> permisos = new List<Permiso>();
            permisos.Add(new Permiso(){ Codigo = "1", IdPrograma = "1", Descripcion = "Configuracion de permisos" });
            permisos.Add(new Permiso(){ Codigo = "2", IdPrograma = "2", Descripcion = "Crear Modulos del menu"});
            permisos.Add(new Permiso(){ Codigo = "3", IdPrograma = "3", Descripcion = "Registro de Doctores" });
            permisos.Add(new Permiso(){ Codigo = "4", IdPrograma = "4", Descripcion = "Consultar Doctores" });
            permisos.Add(new Permiso(){ Codigo = "5", IdPrograma = "5", Descripcion = "Registro Paciente" });
            permisos.Add(new Permiso(){ Codigo = "6", IdPrograma = "6", Descripcion = "Consulta de pacientes" });
            permisos.Add(new Permiso(){ Codigo = "7", IdPrograma = "7", Descripcion = "Registro de productos" });
            permisos.Add(new Permiso(){ Codigo = "8", IdPrograma = "8", Descripcion = "Consulta de productos" });
            permisos.Add(new Permiso(){ Codigo = "9", IdPrograma = "9", Descripcion = "Registro de citas medicas" });
            return permisos;
        }

        public List<ProgramaMenu> LlenarProgramas()
        {
            List<ProgramaMenu> programas = new List<ProgramaMenu>();
            //configuracion
            programas.Add(new ProgramaMenu(){ Codigo = "1", Nombre = "Configurar Permisos" , Ruta = "/configurarPermisos", IdModulo = "1" });
            programas.Add(new ProgramaMenu(){ Codigo = "2", Nombre = "Crear Modulo" , Ruta = "/crearModulo", IdModulo = "1" });
            //doctor
            programas.Add(new ProgramaMenu(){ Codigo = "3", Nombre = "Registro Doctor" ,Ruta = "/registro-doctor", IdModulo = "2" });
            programas.Add(new ProgramaMenu(){ Codigo = "4", Nombre = "Consultar Doctores", Ruta = "/consulta-doctores", IdModulo = "2" });
            //paciente
            programas.Add(new ProgramaMenu(){ Codigo = "5", Nombre = "Registro Paciente", Ruta = "/registro-pacientes", IdModulo = "3" });
            programas.Add(new ProgramaMenu(){ Codigo = "6", Nombre = "Consultar Pacientes", Ruta = "/lista-pacientes", IdModulo = "3" });
            //producto
            programas.Add(new ProgramaMenu(){ Codigo = "7", Nombre = "Registrar Producto", Ruta = "/registro-productos", IdModulo = "4" });
            programas.Add(new ProgramaMenu(){ Codigo = "8", Nombre = "Consultar Productos", Ruta = "/productosLista", IdModulo = "4" });
            //cita
            programas.Add(new ProgramaMenu(){ Codigo = "9", Nombre = "Registrar Cita", Ruta = "/registro-cita", IdModulo = "5" });
            return programas;
        }

        public List<ModuleMenu> LlenarMenu()
        {
            List<ModuleMenu> modulos = new List<ModuleMenu>();
            modulos.Add(new ModuleMenu(){ Codigo = "1", Nombre = "Configuracion" });
            modulos.Add(new ModuleMenu(){ Codigo = "2", Nombre = "Doctor" });
            modulos.Add(new ModuleMenu(){ Codigo = "3", Nombre = "Paciente" });
            modulos.Add(new ModuleMenu(){ Codigo = "4", Nombre = "Producto" });
            modulos.Add(new ModuleMenu(){ Codigo = "5", Nombre = "Cita" });
            return modulos;
        }

        public List<Usuario> CrearAdministrador()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add( new Usuario(){ User = "Admin", Password = "Admin", Estado = "Activo" });
            return usuarios;
        }


        public List<Especialidad> LlenarEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            especialidades.Add(new Especialidad(){Nombre = "Odontólogo general", Codigo = "123"});
            especialidades.Add(new Especialidad(){ Nombre = "Odontopediatra", Codigo = "1234"});
            especialidades.Add(new Especialidad(){ Nombre = "Periodoncista", Codigo = "1235"});
            especialidades.Add(new Especialidad(){ Nombre = "Endodoncista", Codigo = "1236"});
            especialidades.Add(new Especialidad(){ Nombre = "Cirujano Oral", Codigo = "1237"});
            especialidades.Add(new Especialidad(){ Nombre = "Prostodoncista", Codigo = "1238"});
            return especialidades;
        }
    }
}
