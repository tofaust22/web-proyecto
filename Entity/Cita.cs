using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Cita
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Codigo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        [NotMapped]
        public Doctor Doctor { get; set; }
        [NotMapped]
        public Paciente Paciente { get; set; }
        public string IdPaciente { get; set; }
        public string CodigoAgenda { get; set; }


        public void AgregarDoctor(Doctor doctor)
        {
            Doctor = doctor;
        }

        public void AgregarPaciente(Paciente paciente)
        {
            Paciente = paciente;
            IdPaciente = paciente.Identificacion;
        }
    }
}