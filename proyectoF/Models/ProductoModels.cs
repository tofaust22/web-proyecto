using Entity;

namespace proyectoF.Models
{
    public class ProductoInputModels
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public int Cantidad { get; set; }
    }

    public class ProductoViewModels : ProductoInputModels 
    {
        public ProductoViewModels(Producto producto)
        {
            Codigo = producto.Codigo;
            Nombre = producto.Nombre;
            Descripcion = producto.Descripcion;
            Valor = producto.Valor;
            Cantidad = producto.Cantidad;
        }
        
        
    }
}