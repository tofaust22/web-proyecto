using System.Collections.Generic;
using Entity;

namespace proyectoF.Models
{
    public class InformeInputModels 
    {

        public List<ProductoInputModels> Productos { get; set; }
        public string IdDoctor { get; set; }
        public string Diagnostico { get; set; }
        public string IdPaciente { get; set; }
        public CitaInputModels Cita { get; set; }
    }

    public class InformeViewsModels : InformeInputModels
    {
        public InformeViewsModels(Informe informe)
        {
            Diagnostico = informe.Diagnostico;
            Codigo = informe.Codigo;
        }

        public string Codigo { get; set; }
    }
}