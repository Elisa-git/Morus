using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioRepositorio;
        private readonly IMapper mapper;
        private readonly IUsuario _IUsuario;
        public UsuarioController(UsuarioRepositorio usuarioRepositorio, IMapper mapper, IUsuario IUsuario)
        {
            this.mapper = mapper;
            _IUsuario = IUsuario;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarUsuario")]
        public async Task<List<Notifies>> CadastrarUsuario(UsuarioRequest usuarioRequest)
        {
            var usuarioMapeado = mapper.Map<Usuario>(usuarioRequest);
            await _usuarioRepositorio.Add(usuarioMapeado);
            return usuarioMapeado.ListaNotificacoes;
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
            await _usuarioRepositorio.Delete(usuarioMap);
            return usuarioMap.ListaNotificacoes;
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
