using Application.Interfaces;
using AutoMapper;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : MorusController
    {
        private readonly IUsuarioApplication _usuarioApplication;
        private readonly IMapper mapper;
        private readonly IUsuario _IUsuario;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UsuarioController(IMapper mapper,
                                 IUsuario IUsuario,
                                 IUsuarioApplication usuarioApplication,
                                 INotificador notificador,
                                 SignInManager<User> signInManager,
                                 UserManager<User> userManager) : base(notificador)
        {
            this.mapper = mapper;
            _IUsuario = IUsuario;
            _usuarioApplication = usuarioApplication;
            _signInManager = signInManager;
            _userManager = userManager;

        }

        //[AllowAnonymous]
        //[Produces("application/json")]
        //[HttpPost("/api/CadastrarUsuario")]
        //public async Task<IActionResult> CadastrarUsuario(UsuarioRequest usuarioRequest)
        //{
        //    try
        //    {
        //        var usuarioMapeado = mapper.Map<Usuario>(usuarioRequest);
        //        await _usuarioApplication.Cadastrar(usuarioMapeado);

        //        return CustomResponse(200, true);
        //    }
        //    catch (ValidationException)
        //    {
        //        return CustomResponse(400, false);
        //    }
        //    catch (Exception)
        //    {
        //        _notificador.NotificarMensagemErroInterno();
        //        return CustomResponse(500, false);
        //    }
        //}

        //[AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarUsuarioMorador")]
        [Authorize(Roles = "Sindico")]
        public async Task<IActionResult> CadastrarMorador(CadastrarMoradorRequest cadastrarMoradorRequest)
        {
            try
            {
                var hasher = new PasswordHasher<User>();
                var user = new User
                {
                    Email = cadastrarMoradorRequest.Email,
                    UserName = cadastrarMoradorRequest.Email,
                    NormalizedEmail = cadastrarMoradorRequest.Email.ToUpperInvariant(),
                    NormalizedUserName = cadastrarMoradorRequest.Email.ToUpperInvariant(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword(null, cadastrarMoradorRequest.Senha)
                };
                var usuarioMapeado = mapper.Map<Usuario>(cadastrarMoradorRequest);

                return CustomResponse(200, (await _usuarioApplication.CadastrarMorador(user, usuarioMapeado)));
            }
            catch (ValidationException)
            {
                return CustomResponse(400, false);
            }
            catch (RegisterException e)
            {
                _notificador.Notificar(e.Message);
                return CustomResponse(403, false);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }


        //[AllowAnonymous]
        //[Produces("application/json")]
        //[HttpPut("/api/AtualizarUsuario")]
        //public async Task<List<Notifies>> AtualizarUsuario(UsuarioRequest usuarioRequest)
        //{
        //    var usuarioMap = mapper.Map<Usuario>(usuarioRequest);
        //    await _usuarioRepositorio.Update(usuarioMap);
        //    return usuarioMap.ListaNotificacoes;
        //}

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpDelete("/api/DeletarUsuario")]
        public async Task<List<Notifies>> DeletarUsuario(UsuarioRequest usuarioRequest)
        {
            var usuarioMap = mapper.Map<Usuario>(usuarioRequest);
            //await _usuarioRepositorio.Delete(usuarioMap);
            //return usuarioMap.ListaNotificacoes;
            return null;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("/api/ListarUsuarios")]
        public async Task<List<Usuario>> ListarUsuarios()
        {
            var usuarios = await _IUsuario.List();
            var usuarioMap = mapper.Map<List<Usuario>>(usuarios);
            return usuarioMap;
        }


        //[AllowAnonymous]
        //[Produces("application/json")]
        //[HttpPost]
        //public async Task<IActionResult>> Loging
    }
}
