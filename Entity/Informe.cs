using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Informe
    {
        [Key]
        public string Codigo { get; set; }
        public List<DetalleProducto> Detalles { get; set; }
        [NotMapped]
        public Doctor Doctor { get; set; }
        public string IdDoctor { get; set; }
        [NotMapped]
        public DetalleProducto Detalle { get; set; }
        public string Diagnostico { get; set; }

        public void AgregarDoctor(Doctor doctor)
        {
            Doctor = doctor;
            Doctor.Identificacion = doctor.Identificacion;
        }

        public void CrearDetalle(Producto producto, int cantidad, DateTime fecha)
        {
            Detalle = new DetalleProducto();
            Detalle.Cantidad = cantidad;
            Detalle.Fecha = fecha;
            Detalle.Valor = producto.Valor;
            Detalle.AgregarProducto(producto);

        }
    }
}