using System.Collections.Generic;
using System.Linq;
using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using proyectoF.Models;

namespace proyectoF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _service;
        public PersonaController(ProyectoContext context)
        {
            _service = new PersonaService(context);
        }

        [HttpPost("Doctor")]
        public ActionResult<PersonaViewModel> GuardarDoctor(PersonaInputModels personaInput)
        {
            Doctor doctor = MapearDoctor(personaInput);
            var response = _service.GuardarDoctor(doctor);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Object);
        }
        [HttpPost("Paciente")]
        public ActionResult<PersonaViewModel> GuardarPaciente(PersonaInputModels personaInput)
        {
            Paciente paciente = MapearPaciente(personaInput);
            var response = _service.GuardarPaciente(paciente);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Object);
        }

        [HttpGet("Doctores")]
        public ActionResult<IEnumerable<PersonaViewModel>> ConsultarDoctores()
        {
            var response = _service.ConsultarDoctores();
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Objects);
        }

        [HttpGet("Pacientes")]
        public ActionResult<IEnumerable<PersonaViewModel>> ConsultarPacientes()
        {
            var response = _service.ConsultarPacientes();
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Objects);
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
            doctor.CalcularEdad();
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
            paciente.CalcularEdad();
            paciente.CrearHistoria();
            return paciente;
        }
        
    }
}