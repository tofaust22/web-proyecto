using System;
using System.Linq;
using DAL;
using Entity;

namespace BLL
{
    public class CitaService
    {
        private readonly ProyectoContext _context;

        public CitaService(ProyectoContext context)
        {
            _context = context;
        }

        public ResponseClassGeneric<Cita> CrearCita(Cita cita)
        {
            try
            {
                _context.Citas.Add(cita);
                _context.SaveChanges();
                return new ResponseClassGeneric<Cita>(cita);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Cita>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Cita> ConsultarCitas()
        {
            try
            {
                return new ResponseClassGeneric<Cita>(_context.Citas.Where(c => c.Estado == true && c.FechaRegistro > DateTime.Now).ToList());
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Cita>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Cita> BuscarCita(string codigo)
        {
            try
            {
                return new ResponseClassGeneric<Cita>(_context.Citas.Where( c => c.Codigo == codigo && c.Estado == true )
                                                        .FirstOrDefault());
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Cita>($"Error en la Aplicacion: {e.Message}");
            }
        }

    }
}