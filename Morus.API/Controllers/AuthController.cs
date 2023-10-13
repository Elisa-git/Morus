using Application.Interfaces;
using AutoMapper;
using Core.Notificador;
using Domain.Entities;
using Domain.Entities.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;
using Morus.API.Token;
using System.Security.Claims;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : MorusController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUsuarioApplication _usuarioApplication;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IUsuarioApplication usuarioApplication, INotificador notificador) : base(notificador)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _usuarioApplication = usuarioApplication;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.senha))
            {
                _notificador.Notificar("Revise os dados de login.");
                return CustomResponse(401, false);
            }

            var resultado = await
                _signInManager.PasswordSignInAsync(login.email, login.senha, false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                // Recupera Usuário Logado
                var userCurrent = await _userManager.FindByEmailAsync(login.email);
                var idUsuario = userCurrent.Id;
                var rolesUserCurrent = (await _userManager.GetRolesAsync(userCurrent))?.FirstOrDefault();
                


                if (rolesUserCurrent == null)
                {
                    _notificador.Notificar("Usuário deve estar associado a um tipo. Entre em contato com o suporte.");
                    return CustomResponse(401, false);
                }

                var token = new TokenJWTBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"))
                .AddSubject("Empresa - Morus")
                .AddIssuer("Morus.Securiry.Bearer")
                .AddAudience("Morus.Securiry.Bearer")
                .AddClaim("idUsuario", idUsuario)
                .AddClaim(ClaimTypes.Role, rolesUserCurrent)
                .AddExpiry(600)
                .Builder();

                var usuarioLogadoResponse = await _usuarioApplication.ObterDadosUsuarioLogin(idUsuario);
                usuarioLogadoResponse.Token = token.value;

                switch (rolesUserCurrent)
                {
                    case "Sindico":
                        usuarioLogadoResponse.Usuario.TipoUsuario = TipoUsuario.Sindico;
                        break;
                    case "Morador":
                        usuarioLogadoResponse.Usuario.TipoUsuario = TipoUsuario.Morador;
                        break;
                    case "Admin":
                        usuarioLogadoResponse.Usuario.TipoUsuario = TipoUsuario.Admin;
                        break;
                    case "Porteiro":
                        usuarioLogadoResponse.Usuario.TipoUsuario = TipoUsuario.Porteiro;
                        break;
                    default:
                        break;
                }

                return CustomResponse(200, true, usuarioLogadoResponse);
            }
            else
            {
                _notificador.Notificar("Usuário ou senha inválidos.");
                return CustomResponse(401, false);
            }
        }

        //[AllowAnonymous]
        //[Produces("application/json")]
        //[HttpPost("/api/AdicionaUsuarioIdentity")]
        //public async Task<IActionResult> AdicionaUsuarioIdentity([FromBody] Login login)
        //{
        //    if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.senha))
        //        return Ok("Falta alguns dados");

        //    var user = new User
        //    {
        //        UserName = login.email,
        //        Email = login.email
        //        //CPF = login.cpf,
        //        //Tipo = TipoUsuario.Admin,
        //    };

        //    var resultado = await _userManager.CreateAsync(user, login.senha);

        //    if (resultado.Errors.Any())
        //    {
        //        return Ok(resultado.Errors);
        //    }

        //    // Geração de Confirmação caso precise
        //    var userId = await _userManager.GetUserIdAsync(user);
        //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        //    // retorno email 
        //    code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        //    var resultado2 = await _userManager.ConfirmEmailAsync(user, code);

        //    if (resultado2.Succeeded)
        //        return Ok("Usuário Adicionado com Sucesso");
        //    else
        //        return Ok("Erro ao confirmar usuários");

        //}

    }

}
