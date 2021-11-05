﻿using System;
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

            modelBuilder.Entity<Especialidad>()
                .HasData(LlenarEspecialidades());

            modelBuilder.Entity<Rol>()
                .HasData(LlenarRoles());

            modelBuilder.Entity<Usuario>()
                .HasData(CrearAdministrador());

            modelBuilder.Entity<UsuarioRol>()
                .HasData(AsignarRolAdmin());
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
