using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Rol
    {
        [Key]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [NotMapped]
        public List<PermisoRol> PermisoRoles { get; set; }
    }
}