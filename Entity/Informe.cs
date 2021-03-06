using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Informe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Codigo { get; set; }
        public List<DetalleProducto> Detalles { get; set; }
        [NotMapped]
        public Doctor Doctor { get; set; }
        public string IdDoctor { get; set; }
        [NotMapped]
        public DetalleProducto Detalle { get; set; }
        public string Diagnostico { get; set; }
        [NotMapped]
        public Cita Cita { get; set; }
        public string IdCita { get; set; }
        public bool Estado { get; set; }
        public string IdHistoria { get; set; }

        public Informe()
        {
            Detalles = new List<DetalleProducto>();
        }
        public void AgregarDoctor(Doctor doctor)
        {
            Doctor = doctor;
            Doctor.Identificacion = doctor.Identificacion;
        }
        public void AgregarCita(Cita cita)
        {
            Cita = cita;
            IdCita = cita.Codigo;
        }

        public void CrearDetalle(Producto producto, int cantidad, DateTime fecha)
        {
            Detalle = new DetalleProducto();
            Detalle.Cantidad = cantidad;
            Detalle.Fecha = fecha;
            Detalle.Valor = producto.Valor;
            Detalle.AgregarProducto(producto);
            Detalles.Add(Detalle);
        }
    }
}