using System;
using Entity;
using DAL;
using System.Linq;

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

        public ResponseClassGeneric<Persona> Consultar()
        {
            try
            {
                return new ResponseClassGeneric<Persona>(_context.Personas.ToList());
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Persona>($"Error en la Aplicacion: {e.Message}");
            }
        }
    }
}