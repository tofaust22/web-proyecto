using System.Collections.Generic;

namespace proyectoF.Models
{
    public class InformeInputModels 
    {

        public List<ProductoInputModels> Productos { get; set; }
        public string IdDoctor { get; set; }
        public string Diagnostico { get; set; }
        public string IdPaciente { get; set; }
    }

    public class InformeViewsModels : InformeInputModels
    {

    }
}