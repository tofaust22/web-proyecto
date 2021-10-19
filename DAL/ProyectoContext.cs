using System;
using Microsoft.EntityFrameworkCore;
using Entity;

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
                .HasOne<Doctor>().WithMany()
                .HasForeignKey( c => c.IdDoctor );

            modelBuilder.Entity<Cita>()
                .HasOne<Doctor>().WithMany()
                .HasForeignKey( c => c.IdPaciente );

            modelBuilder.Entity<DetalleProducto>()
                .HasOne<Producto>().WithMany()
                .HasForeignKey( p => p.IdProducto );
            
            modelBuilder.Entity<Informe>()
                .HasOne<Doctor>().WithMany()
                .HasForeignKey( I => I.IdDoctor );
        }
    }
}
