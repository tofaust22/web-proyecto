using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class UsuarioRol
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Codigo { get; set; }
        public string UsuarioId { get; set; }
        public string RolId { get; set; }
        [NotMapped]
        public Rol Rol { get; set; }
    }
}