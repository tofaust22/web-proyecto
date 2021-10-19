using Entity;

namespace proyectoF.Models
{
    public class EspecialidadInputModels
    {
        public string Nombre { get; set; }
    }

    public class EspecialidadViewModels : EspecialidadInputModels
    {
        public EspecialidadViewModels(Especialidad especialidad)
        {
            Codigo = especialidad.Codigo;
            Nombre = especialidad.Nombre;
        }
        public string Codigo { get; set; }
    }


}