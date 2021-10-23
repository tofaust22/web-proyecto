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
            return ResponseHttpDoctor(response, false);
        }
        [HttpPost("Paciente")]
        public ActionResult<PersonaViewModel> GuardarPaciente(PersonaInputModels personaInput)
        {
            Paciente paciente = MapearPaciente(personaInput);
            var response = _service.GuardarPaciente(paciente);
            return ResponseHttpPaciente(response, false);
        }

        [HttpGet("Doctores")]
        public ActionResult<IEnumerable<PersonaViewModel>> ConsultarDoctores()
        {
            var response = _service.ConsultarDoctores();
            return ResponseHttpDoctor(response, true);
        }

        [HttpGet("Pacientes")]
        public ActionResult<IEnumerable<PersonaViewModel>> ConsultarPacientes()
        {
            var response = _service.ConsultarPacientes();
            return ResponseHttpPaciente(response, true);
        }

        [HttpGet("Paciente/{id}")]
        public ActionResult<PersonaViewModel> BuscarPaciente(string id)
        {
            var response = _service.BuscarPaciente(id);
            return ResponseHttpPaciente(response, false);
        }

        [HttpGet("Doctor/{id}")]
        public ActionResult<PersonaViewModel> BuscarDoctor(string id)
        {
            var response = _service.BuscarDoctor(id);
            return ResponseHttpDoctor(response, false);
        }

        [HttpPut("Doctor")]
        public ActionResult<PersonaViewModel> ModificarDoctor(PersonaInputModels personaInput)
        {
            Doctor doctor = MapearDoctor(personaInput);
            var response = _service.ActualizarDoctor(doctor);
            return ResponseHttpDoctor(response, false);
        }

        [HttpPut("Paciente")]
        public ActionResult<PersonaViewModel> ModificarPaciente(PersonaInputModels personaInput)
        {
            Paciente paciente = MapearPaciente(personaInput);
            var response = _service.ActualizarPaciente(paciente);
            return ResponseHttpPaciente(response, false);
        } 

        private ObjectResult ResponseHttpDoctor(ResponseClassGeneric<Doctor> result, bool list)
        {
            if(result.Error)
            {
                return BadRequest(result.Mensaje);
            }
            if(list)
            {
                return Ok(result.Objects.Select( p => new PersonaViewModel(p) ));
            }
            return Ok(new PersonaViewModel(result.Object));
        }

        private ObjectResult ResponseHttpPaciente(ResponseClassGeneric<Paciente> result, bool list)
        {
            if(result.Error)
            {
                return BadRequest(result.Mensaje);
            }
            if(list)
            {
                return Ok(result.Objects.Select( p => new PersonaViewModel(p) ));
            }
            return Ok(new PersonaViewModel(result.Object));
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
                IdEspecialidad = personaInput.Especialidad.Codigo,
                Especialidad = new Especialidad()
                {
                    Codigo = personaInput.Especialidad.Codigo,
                    Nombre = personaInput.Especialidad.Nombre
                }
            };
            doctor.CalcularEdad();
            doctor.CrearAgenda();
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