using Entity;
using DAL;
using System;
using System.Linq;

namespace BLL
{
    public class ProductoService
    {
        private readonly ProyectoContext _context;

        public ProductoService(ProyectoContext context)
        {
            _context = context;
        }

        public ResponseClassGeneric<Producto> Guardar(Producto producto)
        {
            try
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return new ResponseClassGeneric<Producto>(producto);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Producto>($"Error en la Aplicación {e.Message}");
            }
        }

        public ResponseClassGeneric<Producto> Consultar()
        {
            try
            {
                return new ResponseClassGeneric<Producto>(_context.Productos.ToList());
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Producto>($"Error en la Aplicación {e.Message}");
            }
        }

        public ResponseClassGeneric<Producto> Buscar(string codigo)
        {
            try
            {
                var response = _context.Productos.Where( p => p.Codigo == codigo).FirstOrDefault();
                if(response is null)
                {
                    return new ResponseClassGeneric<Producto>("No existe el producto");
                }
                return new ResponseClassGeneric<Producto>(response);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Producto>($"Error en la Aplicación {e.Message}");
            }
        }

        public ResponseClassGeneric<Producto> ModificarInformacion(Producto producto)
        {
            try
            {
                var response = _context.Productos.Where( p => p.Codigo == producto.Codigo).FirstOrDefault();
                if(response is null)
                {
                    return new ResponseClassGeneric<Producto>("No existe el producto");
                }
                response.Descripcion = producto.Descripcion;
                response.Nombre = producto.Nombre;
                response.Valor = producto.Valor;
                _context.Productos.Update(response);
                _context.SaveChanges();
                return new ResponseClassGeneric<Producto>(producto);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Producto>($"Error en la Aplicación {e.Message}");
            }
        }

        public ResponseClassGeneric<Producto> DescontarCantidad(Producto producto, int cantidad)
        {
            try
            {
                var response = _context.Productos.Where( p => p.Codigo == producto.Codigo).FirstOrDefault();
                if(response is null)
                {
                    return new ResponseClassGeneric<Producto>("No existe el producto");
                }
                if(response.Cantidad <= cantidad)
                {
                    producto.Cantidad = response.Cantidad;
                    response.Cantidad = 0;
                    _context.Productos.Update(response);
                    _context.SaveChanges();
                    return new ResponseClassGeneric<Producto>(producto);
                }
                producto.Cantidad = cantidad;
                response.Cantidad -= cantidad;
                _context.Productos.Update(response);
                _context.SaveChanges();
                return new ResponseClassGeneric<Producto>(producto);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Producto>($"Error en la Aplicación {e.Message}");
            }
        }

        public ResponseClassGeneric<Producto> ActualizarCantidad(Producto producto, int cantidad)
        {
            try
            {
                var response = _context.Productos.Where( p => p.Codigo == producto.Codigo).FirstOrDefault();
                if(response is null)
                {
                    return new ResponseClassGeneric<Producto>("No existe el producto");
                }
                response.Cantidad += cantidad;
                _context.Productos.Update(response);
                _context.SaveChanges();
                return new ResponseClassGeneric<Producto>(response);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Producto>($"Error en la Aplicación {e.Message}");
            }
        }
    }
}