using System;
using Entity;

namespace proyectoF.Models
{
    public class CitaInputModels
    {
        public string Codigo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
        public string Observaciones { get; set; }
        public PersonaInputModels Doctor { get; set; }
        public PersonaInputModels Paciente { get; set; }

    }

    public class CitaViewModels : CitaInputModels
    {
        public CitaViewModels(Cita cita)
        {
            Codigo = cita.Codigo;
            FechaRegistro = cita.FechaRegistro;
            Estado = cita.Estado;
            Observaciones = cita.Observaciones;
            Doctor = new PersonaViewModel(cita.Doctor);
            Paciente = new PersonaViewModel(cita.Paciente);
        }
    }
}