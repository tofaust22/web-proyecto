using BLL;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using proyectoF.Config;
using proyectoF.Servicios;

namespace proyectoF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _servicioLogin;
        private readonly ServiciosJwt _jwtServicios;

        public LoginController(ProyectoContext context, IOptions<AppSetting> appSettings)
        {
            _jwtServicios = new ServiciosJwt(appSettings);
            _servicioLogin = new LoginService(context);
            
        }

        [AllowAnonymous]
        [HttpPost("{usuario}/{password}")]
        public ActionResult Login(string usuario, string password)
        {
            var user = _servicioLogin.ValidarUsuario(usuario, password);
            if(user.Error)
            {
                return Unauthorized(user.Mensaje);
            }
            var response = _jwtServicios.GenerarToken(user.Object);
            return Ok(response);
        }
    }
}