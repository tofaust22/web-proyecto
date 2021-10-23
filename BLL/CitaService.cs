using System;
using System.Linq;
using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;

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
                Doctor doctor = _context.Doctores.Include( d => d.Agenda).Where( d => d.Identificacion == cita.Doctor.Identificacion)
                                                    .FirstOrDefault();
                
                if(doctor is null)
                {
                    return new ResponseClassGeneric<Cita>("Error al apartar la cita, el doctor no existe.");
                }
                doctor.Especialidad = _context.Especialidades.Find(doctor.IdEspecialidad);
                var citas = _context.Citas.Where( c => c.CodigoAgenda == doctor.Agenda.Codigo && c.FechaRegistro > DateTime.Now ).OrderBy(f => f.FechaRegistro).ToList();
                DateTime fecha = DateTime.Now;
                if(citas.Count == 0)
                {
                    fecha = fecha.AddMinutes(30);
                }
                else
                {
                    var citaResult = citas.Last();
                    fecha = citaResult.FechaRegistro.AddMinutes(30);
                }
                
                if(fecha.Hour > 20 && fecha.Minute >= 0)
                {
                    return new ResponseClassGeneric<Cita>("No hay citas disponibles");
                }
                cita.FechaRegistro = fecha;
                cita.CodigoAgenda = doctor.Agenda.Codigo;
                _context.Citas.Add(cita);
                _context.SaveChanges();
                cita.Doctor = doctor;
                var paciente = _context.Pacientes.Include(p => p.Historia.Informes).FirstOrDefault();
                    foreach (var item2 in paciente.Historia.Informes)
                    {
                        var informe = _context.Informes.Include(d => d.Detalles)
                                            .Where(d => d.Codigo == item2.Codigo).FirstOrDefault();
                        item2.Detalles = informe.Detalles;
                    }
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

        public ResponseClassGeneric<Cita> BuscarCitasDoctor(string identificacion)
        {
            try
            {
                Doctor doctor = _context.Doctores.Include( d => d.Agenda)
                .Where( d => d.Identificacion == identificacion).FirstOrDefault();

                doctor.Especialidad = _context.Especialidades.Find(doctor.IdEspecialidad);

                var citas = _context.Citas
                .Where( c => c.CodigoAgenda == doctor.Agenda.Codigo && c.FechaRegistro > DateTime.Now )
                .OrderBy(f => f.FechaRegistro).ToList();
                
                foreach (var item in citas)
                {
                    item.Doctor = doctor;
                    item.Paciente = _context.Pacientes.Find(item.IdPaciente);
                };
                
                return new ResponseClassGeneric<Cita>(citas);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Cita>($"Error en la Aplicacion: {e.Message}");
            }
        }

    }
}