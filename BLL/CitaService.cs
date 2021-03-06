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
                var citas = _context.Citas.Where( c => c.CodigoAgenda == doctor.Agenda.Codigo && c.FechaRegistro > DateTime.Now &&  (c.Estado == "Activa" )  ).OrderBy(f => f.FechaRegistro).ToList();
                DateTime fecha = cita.FechaRegistro;
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
                return new ResponseClassGeneric<Cita>(_context.Citas.Where(c => c.Estado == "Activo" && c.FechaRegistro > DateTime.Now).ToList());
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Cita>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Cita> BuscarCita(string codigo, string idDoctor)
        {
            try
            {
                var cita = _context.Citas.Where( c => c.Codigo == codigo && c.Estado == "Atendiendo" )
                                                        .FirstOrDefault();
                var doctor = _context.Doctores.Include( d => d.Agenda)
                                .Where( d => d.Identificacion == idDoctor).FirstOrDefault();
                doctor.Especialidad = _context.Especialidades.Find(doctor.IdEspecialidad);
                cita.Doctor = doctor;
                cita.Paciente = _context.Pacientes.Find(cita.IdPaciente);
                return new ResponseClassGeneric<Cita>(cita);
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
                .Where( c => c.CodigoAgenda == doctor.Agenda.Codigo && c.FechaRegistro > DateTime.Now && (c.Estado == "Activa" )  )
                .OrderBy(f => f.FechaRegistro).ToList();
                
                foreach (var item in citas)
                {
                    item.Doctor = doctor;
                    var fecha = item.FechaRegistro;
                    var fecha2 = DateTime.Now;
                    item.Paciente = _context.Pacientes.Find(item.IdPaciente);
                };
                
                return new ResponseClassGeneric<Cita>(citas);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Cita>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Cita> CitasPaciente(string identificacion)
        {
            try
            {
                var citas = _context.Citas.Where( p => p.IdPaciente == identificacion  ).OrderBy(f => f.FechaRegistro)
                .ToList();

                foreach (var item in citas)
                {
                    var agenda = _context.Agendas.Find(item.CodigoAgenda);
                    var doctor = _context.Doctores.Include(a => a.Agenda).Where( d => d.Agenda.Codigo == agenda.Codigo).FirstOrDefault();
                    doctor.Especialidad = _context.Especialidades.Find(doctor.IdEspecialidad);
                    item.Doctor = doctor;
                    item.Paciente = _context.Pacientes.Find(item.IdPaciente);
                }
                return new ResponseClassGeneric<Cita>(citas);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Cita>($"Error en la Aplicacion: {e.Message}");
            }
        }

        public ResponseClassGeneric<Cita> AtenderCita(string codigo, string idDoctor)
        {
            try
            {
                var cita = _context.Citas
                    .Where( c => c.Codigo == codigo && c.Estado == "Activa" && c.FechaRegistro > DateTime.Now )
                    .FirstOrDefault();
                if(cita is null)
                {
                    return new ResponseClassGeneric<Cita>("No existe la cita");
                }
                cita.Estado = "Atendiendo";
                _context.Citas.Update(cita);
                _context.SaveChanges();
                var doctor = _context.Doctores.Include( d => d.Agenda)
                                .Where( d => d.Identificacion == idDoctor).FirstOrDefault();
                doctor.Especialidad = _context.Especialidades.Find(doctor.IdEspecialidad);
                cita.Doctor = doctor;
                cita.Paciente = _context.Pacientes.Find(cita.IdPaciente);
                return new ResponseClassGeneric<Cita>(cita);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Cita>($"Error en la Aplicacion: {e.Message}");
            }
        }

    }
}