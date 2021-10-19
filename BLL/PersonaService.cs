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
                return new ResponseClassGeneric<Doctor>(_context.Doctores.ToList());
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Doctor>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Paciente> RegistrarInforme(Informe informe, string identificacion)
        {
            try
            {
                var response = _context.Pacientes.Include( p => p.Historia.Informes)
                                                .Where( p => p.Identificacion == identificacion).FirstOrDefault();
                if(response is null)
                {
                    return new ResponseClassGeneric<Paciente>("No existe el paciente");
                }
                response.Historia.AgregarInforme(informe);
                _context.Pacientes.Update(response);
                _context.SaveChanges();
                return new ResponseClassGeneric<Paciente>(response);

            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Paciente>($"Error en la Aplicacion: {e.Message}");
            }
        }
    }
}