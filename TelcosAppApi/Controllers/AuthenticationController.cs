using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TelcosAppApi.DataAccess;
using TelcosAppApi.DataAccess.DataAccess;
using TelcosAppApi.AplicationServices.DTOs.Authentication;
using TelcosAppApi.AplicationServices.Application.Contracts.Roles;
using TelcosAppApi.AplicationServices.Application.Contracts.Authentication;
using TelcosAppApi.DataAccess.Entities;
using AutoMapper;

namespace TelcosAppApi.Controllers
{
    [ApiController]
    [Route("Api/Authentication")]
    public class AuthenticationController:ControllerBase
    {

        /// <summary>
        /// Instancia al servicio de aplicación
        /// </summary>
        private readonly IAuthenticationServices _AuthenticationServices;
        private readonly IMapper _mapper;

        public AuthenticationController(IAuthenticationServices authenticationServices,IMapper mapper)        {      
           
            _AuthenticationServices = authenticationServices;
            _mapper = mapper;
        }

        [HttpPost("login", Name = "loginUsuario")]
        public async Task<ActionResult<RespuestaAutenticacionDto>> Login(CredencialesUsuarioDto credencialesUsuario)
        {            
            var resultado = await _AuthenticationServices.Login(credencialesUsuario);            

            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                return BadRequest("Login incorrecto");
            }
        }
    }
}
