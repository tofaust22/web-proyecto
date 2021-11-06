using System.Collections.Generic;
using Entity;

namespace proyectoF.Models
{
    public class UsuarioInputModels
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }
        public string  Token { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Estado { get; set; }
        public string IdPersona { get; set; }
        public int IdRole { get; set; }
    }

    public class UsuarioViewModel : UsuarioInputModels
    {
        public UsuarioViewModel()
        {

        }

        public UsuarioViewModel(Usuario usuario)
        {
            Usuario = usuario.User;
            Tipo = usuario.Tipo;
            Token = usuario.Token;
            Estado = usuario.Estado;
            Nombre = usuario.Nombre;
            Apellidos = usuario.Apellidos;
            Roles = usuario.Roles;
            Modulos = usuario.Modulos;
        }
        public List<ModuleMenu> Modulos { get; set; }
        public List<UsuarioRol> Roles { get; set; }
    }
}