using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class ModuleMenu
    {
        [Key]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [NotMapped]
        public List<ProgramaMenu> Programas { get; set; }


        public ModuleMenu()
        {
            Programas = new List<ProgramaMenu>();
        }
    }
}