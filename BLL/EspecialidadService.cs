using System;
using System.Linq;
using DAL;
using Entity;

namespace BLL
{
    public class EspecialidadService
    {
        private readonly ProyectoContext _context;

        public EspecialidadService(ProyectoContext context)
        {
            _context = context;
        }

        public ResponseClassGeneric<Especialidad> Guardar(Especialidad especialidad)
        {
            try
            {
                _context.Especialidades.Add(especialidad);
                _context.SaveChanges();
                return new ResponseClassGeneric<Especialidad>(especialidad);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Especialidad>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Especialidad> Consultar()
        {
            try
            {
                return new ResponseClassGeneric<Especialidad>(_context.Especialidades.ToList());
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Especialidad>($"Error en la Aplicacion: {e.Message}");
            }
        }

    }
}