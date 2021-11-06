using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class ProgramaMenu
    {
        [Key]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public string IdModulo { get; set; }
    }
}