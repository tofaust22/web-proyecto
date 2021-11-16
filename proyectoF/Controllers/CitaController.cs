using Microsoft.AspNetCore.Mvc;
using Entity;
using DAL;
using BLL;
using proyectoF.Models;
using System.Linq;

namespace proyectoF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
    {
        private readonly CitaService _service;
        public CitaController(ProyectoContext context)
        {
            _service = new CitaService(context);
        }


        [HttpPost]
        public ActionResult<CitaViewModels> CrearCita(CitaInputModels citaInput)
        {
            Cita cita = MapearCita(citaInput);
            var response = _service.CrearCita(cita);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(new CitaViewModels(response.Object));
        }

        [HttpGet("Doctor/{identificacion}")]
        public ActionResult<CitaViewModels> BuscarCitaDoctores(string identificacion)
        {
            var response = _service.BuscarCitasDoctor(identificacion);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Objects.Select( c => new CitaViewModels(c)));
        }

        [HttpPut("Doctor")]
        public ActionResult<CitaViewModels> AtenderCita(CitaInputModels citaInput)
        {
            var response = _service.AtenderCita(citaInput.Codigo, citaInput.Doctor.Identificacion);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(new CitaViewModels(response.Object));
        }

        [HttpGet("Doctor/Buscar/{codigo}/{idDoctor}")]
        public ActionResult<CitaViewModels> BuscarCita(string codigo, string idDoctor)
        {
            var response = _service.BuscarCita(codigo, idDoctor);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(new CitaViewModels(response.Object));
        }

        [HttpGet("Pacientee/{identificacion}")]
        public ActionResult<CitaViewModels> ConsultarCitasPaciente(string identificacion)
        {
            var response = _service.CitasPaciente(identificacion);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Objects.Select( c => new CitaViewModels(c)));
        }


        private Cita MapearCita(CitaInputModels citaInput)
        {
            var cita = new Cita()
            {
                Estado = "Activa",
                FechaRegistro = citaInput.FechaRegistro,
                Observaciones = citaInput.Observaciones
            };
            cita.AgregarDoctor(MapearDoctor(citaInput.Doctor));
            cita.AgregarPaciente(MapearPaciente(citaInput.Paciente));
            return cita;
        }

        private Doctor MapearDoctor(PersonaInputModels personaInput)
        {
            var doctor = new Doctor()
            {   
                Identificacion = personaInput.Identificacion,
                PrimerNombre = personaInput.PrimerNombre,
                SegundoNombre = personaInput.SegundoNombre,
                PrimerApellido = personaInput.PrimerApellido,
                SegundoApellido = personaInput.SegundoApellido,
                FechaNacimiento = personaInput.FechaNacimiento,
                Codigo = personaInput.Codigo,
                IdEspecialidad = personaInput.Especialidad.Codigo
            };
            return doctor;
        }

        private Paciente MapearPaciente(PersonaInputModels personaInput)
        {
            var paciente = new Paciente()
            {
                Identificacion = personaInput.Identificacion,
                PrimerNombre = personaInput.PrimerNombre,
                SegundoNombre = personaInput.SegundoNombre,
                PrimerApellido = personaInput.PrimerApellido,
                SegundoApellido = personaInput.SegundoApellido,
                FechaNacimiento = personaInput.FechaNacimiento,
                Genero = personaInput.Genero,
                Direccion = personaInput.Direccion,
                Telefono = personaInput.Telefono,
                TipoAseguradora = personaInput.TipoAseguradora,
                Ocupacion = personaInput.Ocupacion,
                DepartamentoResidencia = personaInput.DepartamentoResidencia,
                Email = personaInput.Email
            };
            return paciente;
        }
    }
}