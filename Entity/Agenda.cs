using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Agenda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Codigo { get; set; }
        [NotMapped]
        public List<Cita> Citas { get; set; }
        public bool Estado { get; set; }


        public void AgregarCitas(List<Cita> citas)
        {
            Citas = citas;
        }

    }
}