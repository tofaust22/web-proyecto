using BLL;
using Microsoft.AspNetCore.Mvc;
using Entity;
using proyectoF.Models;
using DAL;
using System.Collections;
using System.Linq;

namespace proyectoF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadController : ControllerBase
    {
        private readonly EspecialidadService _service;

        public EspecialidadController(ProyectoContext context)
        {
            _service = new EspecialidadService(context);
        }

        [HttpPost]
        public ActionResult<EspecialidadViewModels> Guardar(EspecialidadInputModels especialidadInput)
        {
            Especialidad especialidad = MapearEspecialidad(especialidadInput);
            var response = _service.Guardar(especialidad);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(new EspecialidadViewModels(response.Object));
        }

        [HttpGet]
        public ActionResult<IEnumerable> Consultar()
        {
            var response = _service.Consultar();
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Objects.Select(e => new EspecialidadViewModels(e)));
        }

        private Especialidad MapearEspecialidad(EspecialidadInputModels especialidadInput)
        {
            var especialidad = new Especialidad()
            {
                Nombre = especialidadInput.Nombre
            };
            return especialidad;
        }


    }
}