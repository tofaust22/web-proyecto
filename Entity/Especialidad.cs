using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Especialidad
    {
        [Key]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}