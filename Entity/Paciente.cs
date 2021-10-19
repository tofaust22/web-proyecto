using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Paciente : Persona
    {
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TipoAseguradora { get; set; }
        public string Ocupacion { get; set; }
        public string DepartamentoResidencia { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public List<Cita> Citas { get; set; }
        public Historia Historia { get; set; }


        public void AgregarCita(Cita cita)
        {
            Citas.Add(cita);
        }

        public void CrearHistoria()
        {
            Historia = new Historia();
        }
    }
}