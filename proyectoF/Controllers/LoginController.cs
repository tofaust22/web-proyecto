using BLL;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using proyectoF.Config;
using proyectoF.Servicios;
using proyectoF.Models;

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
        [HttpPost()]
        public ActionResult Login(UsuarioInputModels models)
        {
            var user = _servicioLogin.ValidarUsuario(models.Usuario, models.Password);
            if(user.Error)
            {
                return Unauthorized(user.Mensaje);
            }
            var response = _jwtServicios.GenerarToken(user.Object);
            return Ok(response);
        }
    }
}