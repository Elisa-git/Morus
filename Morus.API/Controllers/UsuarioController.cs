using Application.Interfaces;
using AutoMapper;
using Core.Notificador;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using FluentValidation;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
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
        public UsuarioController(IMapper mapper, IUsuario IUsuario, IUsuarioApplication usuarioApplication, INotificador notificador) : base(notificador)
        {
            this.mapper = mapper;
            _IUsuario = IUsuario;
            _usuarioApplication = usuarioApplication;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario(UsuarioRequest usuarioRequest)
        {
            try
            {
                var usuarioMapeado = mapper.Map<Usuario>(usuarioRequest);
                await _usuarioApplication.Cadastrar(usuarioMapeado);

                return CustomResponse(200, true);
            }
            catch(ValidationException)
            {
                return CustomResponse(400, false);
            }
            catch(Exception)
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
    }
}
