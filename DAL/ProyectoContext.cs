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

            modelBuilder.Entity<Especialidad>()
                .HasData(LlenarEspecialidades());
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
