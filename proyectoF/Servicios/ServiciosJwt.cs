using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using BLL;
using proyectoF.Config;
using Microsoft.Extensions.Options;
using proyectoF.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace proyectoF.Servicios
{
    public class ServiciosJwt
    {
        private readonly AppSetting _appSetting;
        public ServiciosJwt(IOptions<AppSetting> appSetting)
        {
            _appSetting = appSetting.Value;
        }

        public UsuarioViewModel GenerarToken(Usuario usuario)
        {
            if(usuario == null)
                return null;
            
            var usuarioResponse = new UsuarioViewModel(usuario)
            {
                Usuario = usuario.User,
                Tipo = usuario.Tipo
            };
            
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var claims = new List<Claim>();
            foreach (var item in usuario.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Rol.Nombre));
            }
            claims.Add(new Claim(ClaimTypes.Name, usuario.User.ToString()));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            usuarioResponse.Token = tokenHandler.WriteToken(token);

            return usuarioResponse;
        }
    }
}