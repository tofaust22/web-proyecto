using Microsoft.AspNetCore.Mvc;
using Entity;
using BLL;
using DAL;
using proyectoF.Models;
using System.Collections.Generic;
using System.Linq;

namespace proyectoF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductoController(ProyectoContext context)
        {
            _service = new ProductoService(context);
        }

        [HttpPost]
        public ActionResult<ProductoViewModels> Guardar(ProductoInputModels productoInput)
        {
            Producto producto = MapearProducto(productoInput);
            var response = _service.Guardar(producto);
            return ResponseHttp(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductoViewModels>> Consultar()
        {
            var response = _service.Consultar();
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Objects.Select( p => new ProductoViewModels(p)));
        }

        [HttpPut("UpdateInfo")]
        public ActionResult<ProductoViewModels> UpdateInfo(ProductoInputModels productoInput)
        {
            Producto producto = MapearProducto(productoInput);
            var response = _service.ModificarInformacion(producto);
            return ResponseHttp(response);
        }

        [HttpPut("DiscountAmount")]
        public ActionResult<ProductoViewModels> DiscountAmount(ProductoInputModels productoInput)
        {
            Producto producto = MapearProducto(productoInput);
            var response = _service.DescontarCantidad(producto, producto.Cantidad);
            return ResponseHttp(response);
        }

        [HttpPut("UpdateAmount")]
        public ActionResult<ProductoViewModels> UpdateAmount(ProductoInputModels productoInput)
        {
            Producto producto = MapearProducto(productoInput);
            var response = _service.ActualizarCantidad(producto, producto.Cantidad);
            return ResponseHttp(response);
        }

        [HttpGet("{codigo}")]
        public ActionResult<ProductoViewModels> Buscar(string codigo)
        {
            var response =_service.Buscar(codigo);
            return ResponseHttp(response);
        }


        private ObjectResult ResponseHttp(ResponseClassGeneric<Producto> result)
        {
            if(result.Error)
            {
                return BadRequest(result.Mensaje);
            }
            return Ok(new ProductoViewModels(result.Object));
        }

        private Producto MapearProducto(ProductoInputModels productoInput)
        {
            var producto = new Producto()
            {
                Nombre = productoInput.Nombre,
                Cantidad = productoInput.Cantidad,
                Descripcion = productoInput.Descripcion,
                Valor = productoInput.Valor
            };
            return producto;
        }


    }
}