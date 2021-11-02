using Microsoft.AspNetCore.Mvc;
using Entity;
using DAL;
using BLL;
using proyectoF.Models;
using System;

namespace proyectoF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoriaController : ControllerBase
    {
        private readonly PersonaService _service;

        public HistoriaController(ProyectoContext context)
        {
            _service = new PersonaService(context);
        }

        [HttpPost]
        public ActionResult<InformeViewsModels> RegistrarInforme(InformeInputModels informeInput)
        {
            Informe informe = MapearInforme(informeInput);
            var response = _service.RegistrarInforme(informe, informeInput.IdPaciente);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(new InformeViewsModels(response.Object));
        }

        private Informe MapearInforme(InformeInputModels informeInput)
        {
            var informe = new Informe()
            {
                Diagnostico = informeInput.Diagnostico
            };   

            informe.IdDoctor = informeInput.IdDoctor;
            informe.IdCita = informeInput.Cita.Codigo;
            informe.Estado = false;
            informeInput.Productos.ForEach(p => {
                informe.CrearDetalle(MapearProducto(p), p.Cantidad, DateTime.Now);
            });
            return informe;
        }

       

        private Producto MapearProducto(ProductoInputModels productoInput)
        {
            var producto = new Producto()
            {
                Codigo = productoInput.Codigo,
                Nombre = productoInput.Nombre,
                Cantidad = productoInput.Cantidad,
                Descripcion = productoInput.Descripcion,
                Valor = productoInput.Valor
            };
            return producto;   
        }
    }
}