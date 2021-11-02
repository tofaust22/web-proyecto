using System;
using Entity;
using DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class PersonaService
    {
        private readonly ProyectoContext _context;

        public PersonaService(ProyectoContext context)
        {
            _context = context;
        }

        public ResponseClassGeneric<Doctor> GuardarDoctor(Doctor doctor)
        {
            try
            {
                _context.Personas.Add(doctor);
                _context.SaveChanges();
                return new ResponseClassGeneric<Doctor>(doctor);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Doctor>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Paciente> GuardarPaciente(Paciente paciente)
        {
            try
            {
                _context.Personas.Add(paciente);
                _context.SaveChanges();
                return new ResponseClassGeneric<Paciente>(paciente);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Paciente>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Paciente> ConsultarPacientes()
        {
            try
            {
                var response = _context.Pacientes.Include(p => p.Historia.Informes).ToList();
                foreach (var item in response)
                {
                    foreach (var item2 in item.Historia.Informes)
                    {
                        var informe = _context.Informes.Include(d => d.Detalles)
                                            .Where(d => d.Codigo == item2.Codigo).FirstOrDefault();
                        item2.Detalles = informe.Detalles;
                    }
                }
                return new ResponseClassGeneric<Paciente>(response);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Paciente>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Doctor> ConsultarDoctores()
        {
            try
            {
                var doctores = _context.Doctores.Include( d => d.Agenda ).ToList();
                foreach (var item in doctores)
                {
                    item.Especialidad = _context.Especialidades.Find(item.IdEspecialidad);
                }
                return new ResponseClassGeneric<Doctor>(doctores);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Doctor>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Informe> RegistrarInforme(Informe informe, string identificacion)
        {
            try
            {
                var response = _context.Pacientes.Include( p => p.Historia.Informes)
                                                .Where( p => p.Identificacion == identificacion).FirstOrDefault();
                if(response is null)
                {
                    return new ResponseClassGeneric<Informe>("No existe el paciente");
                }
                response.Historia.AgregarInforme(informe);
                _context.Pacientes.Update(response);
                _context.SaveChanges();
                return new ResponseClassGeneric<Informe>(informe);

            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Informe>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Doctor> ActualizarDoctor(Doctor doctor)
        {
            try
            {
                var response = _context.Doctores.Where( d => d.Identificacion == doctor.Identificacion).FirstOrDefault();
                if(response is null)
                {
                    return new ResponseClassGeneric<Doctor>("No existe el doctor");
                }
                response.PrimerNombre = doctor.PrimerNombre;
                response.SegundoNombre = doctor.SegundoNombre;
                response.PrimerApellido = doctor.PrimerApellido;
                response.SegundoApellido = doctor.SegundoApellido;
                _context.Doctores.Update(response);
                _context.SaveChanges();
                return new ResponseClassGeneric<Doctor>(doctor);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Doctor>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Paciente> ActualizarPaciente(Paciente paciente)
        {
            try
            {
                var response = _context.Pacientes.Where( d => d.Identificacion == paciente.Identificacion).FirstOrDefault();
                if(response is null)
                {
                    return new ResponseClassGeneric<Paciente>("No existe el doctor");
                }
                response.PrimerNombre = paciente.PrimerNombre;
                response.SegundoNombre = paciente.SegundoNombre;
                response.PrimerApellido = paciente.PrimerApellido;
                response.SegundoApellido = paciente.SegundoApellido;
                response.DepartamentoResidencia = paciente.DepartamentoResidencia;
                response.Direccion = paciente.Direccion;
                response.Email = paciente.Email;
                response.Telefono = paciente.Telefono;
                _context.Pacientes.Update(response);
                _context.SaveChanges();
                return new ResponseClassGeneric<Paciente>(paciente);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Paciente>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Paciente> BuscarPaciente(string id)
        {
            try
            {
                var response = _context.Pacientes.Find(id);
                if(response is null)
                {
                    return new ResponseClassGeneric<Paciente>("No existe el paciente");
                }
                return new ResponseClassGeneric<Paciente>(response);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Paciente>($"Error en la Aplicacion: {e.Message}");
            }
        }
        public ResponseClassGeneric<Doctor> BuscarDoctor(string id)
        {
            try
            {
                var response =_context.Doctores.Include( d => d.Agenda)
                .Where( d=> d.Identificacion == id).FirstOrDefault();
                if(response is null)
                {
                    return new ResponseClassGeneric<Doctor>("No existe el doctor");
                }
                response.Especialidad = _context.Especialidades.Find(response.IdEspecialidad);
                return new ResponseClassGeneric<Doctor>(response);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Doctor>($"Error en la Aplicacion: {e.Message}");
            }
        }
    }
}