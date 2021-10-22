using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Doctor : Persona
    {
        public string Codigo { get; set; }
        [NotMapped]
        public Especialidad Especialidad { get; set; }
        [NotMapped]
        public List<Cita> Citas { get; set; }
        public string IdEspecialidad { get; set; }
        public Agenda Agenda { get; set; }


        public void AgregarEspecialidad(Especialidad especialidad)
        {
            Especialidad = especialidad;
            IdEspecialidad = especialidad.Codigo;
        }
        public void CrearAgenda()
        {
            Agenda = new Agenda(){Estado = true};
        }
    }
}