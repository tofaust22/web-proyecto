using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Persona
    {
        [Key]
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }

        public void CalcularEdad()
        {
            Edad = DateTime.Today.AddTicks(-FechaNacimiento.Ticks).Year - 1;
        }
    }

    
}
