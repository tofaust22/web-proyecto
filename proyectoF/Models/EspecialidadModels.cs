using Entity;

namespace proyectoF.Models
{
    public class EspecialidadInputModels
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }

    public class EspecialidadViewModels : EspecialidadInputModels
    {
        public EspecialidadViewModels(Especialidad especialidad)
        {
            Codigo = especialidad.Codigo;
            Nombre = especialidad.Nombre;
        }
    }


}