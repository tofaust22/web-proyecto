using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class PermisoRol
    {
        [Key]
        public string Codigo { get; set; }
        public string PermisoId { get; set; }
        public string RolId { get; set; }
        [NotMapped]
        public Permiso Permiso { get; set; }
    }
}