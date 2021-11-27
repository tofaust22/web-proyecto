using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Historia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Codigo { get; set; }
        [NotMapped]
        public List<Informe> Informes { get; set; }


        public void AgregarInforme(Informe informe)
        {
            Informes.Add(informe);
        }
    }
}