using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Permiso
    {
        [Key]
        public string Codigo { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
        public string IdPrograma { get; set; }
    }
}