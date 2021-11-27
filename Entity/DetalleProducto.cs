using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class DetalleProducto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Codigo { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        [NotMapped]
        public Producto Producto { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Valor { get; set; }
        public string IdProducto { get; set; }

        public void AgregarProducto(Producto producto)
        {
            Producto = producto;
            IdProducto = producto.Codigo;
        }
    }
}