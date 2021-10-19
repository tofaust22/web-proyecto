using System;
using Entity;

namespace proyectoF.Models
{
    public class PersonaInputModels 
    {
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string TipoAseguradora { get; set; }
        public string Ocupacion { get; set; }
        public string DepartamentoResidencia { get; set; }
        public string Email { get; set; }
        public string Codigo { get; set; }
        public EspecialidadViewModels Especialidad { get; set; }
    }

    public class PersonaViewModel : PersonaInputModels
    {
        public PersonaViewModel(Paciente paciente)
        {
            MapearPersona(paciente);
            Genero = paciente.Genero;
            Direccion = paciente.Direccion;
            Telefono = paciente.Telefono;
            TipoAseguradora = paciente.TipoAseguradora;
            Ocupacion = paciente.Ocupacion;
            DepartamentoResidencia = paciente.DepartamentoResidencia;
            Email = paciente.Email;
        }
        public PersonaViewModel(Doctor doctor)
        {
            MapearPersona(doctor);
            Codigo = doctor.Codigo;
            Especialidad = new EspecialidadViewModels(doctor.Especialidad);
        }

        private void MapearPersona(Persona persona)
        {
            Identificacion = persona.Identificacion;
            PrimerNombre = persona.PrimerNombre;
            SegundoNombre = persona.SegundoNombre;
            PrimerApellido = persona.PrimerApellido;
            SegundoApellido = persona.SegundoApellido;
            Edad = persona.Edad;
        }
        public int Edad { get; set; }
    }
}