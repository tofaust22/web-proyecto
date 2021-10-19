using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Historia
    {
        [Key]
        public string Codigo { get; set; }
        public List<Informe> Informes { get; set; }


        public void AgregarInforme(Informe informe)
        {
            Informes.Add(informe);
        }
    }
}