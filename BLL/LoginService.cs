using System;
using System.Linq;
using DAL;
using Entity;

namespace BLL
{
    public class LoginService
    {
        private readonly ProyectoContext _context;
        public LoginService(ProyectoContext context)
        {
            _context = context;
        }

        public ResponseClassGeneric<Usuario> ValidarUsuario(string usuario, string contrasena)
        {
            try
            {
                var user = _context.Usuarios.Where( u => u.User.ToLower() == usuario.ToLower() && u.Password == contrasena && u.Estado == "Activo" ).FirstOrDefault();
                if(user is null)
                {
                    return new ResponseClassGeneric<Usuario>("Error al iniciar");
                }
                var roles = _context.UsuarioRoles.Where( u => u.UsuarioId.ToLower() == usuario.ToLower() ).ToList();
                foreach (var item in roles)
                {
                    item.Rol = _context.Roles.Find(item.RolId);
                    item.Rol.PermisoRoles = _context.PermisoRoles.Where( p => p.RolId == item.RolId ).ToList();
                    foreach (var item2 in item.Rol.PermisoRoles)
                    {
                        item2.Permiso = _context.Permisos.Find(item2.PermisoId);
                    }
                }
                user.Roles = roles;
                return new ResponseClassGeneric<Usuario>(user);
            }
            catch(Exception e)
            {
                return new ResponseClassGeneric<Usuario>($"Error en la Aplicacion: {e.Message}");
            }
        }
    }
}