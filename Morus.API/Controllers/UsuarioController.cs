﻿using Application.Interfaces;
using Application.NovaPasta1;
using AutoMapper;
using Core.Exceptions;
using Core.Notificador;
using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
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
        private readonly IUsuarioService _usuarioService;
        private readonly SignInManager<User> _signInManager;
        public UsuarioController(IMapper mapper,
                                 IUsuario IUsuario,
                                 IUsuarioApplication usuarioApplication,
                                 INotificador notificador,
                                 IUsuarioService usuarioService,
                                 SignInManager<User> signInManager,
                                 UserManager<User> userManager) : base(notificador)
        {
            this.mapper = mapper;
            _IUsuario = IUsuario;
            _usuarioApplication = usuarioApplication;
            _signInManager = signInManager;
            _userManager = userManager;
            _usuarioService = usuarioService;
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

        //[AllowAnonymous]
        //[Produces("application/json")]
        //[HttpDelete("/api/DeletarUsuario")]
        //public async Task<List<Notifies>> DeletarUsuario(UsuarioRequest usuarioRequest)
        //{
        //    var usuarioMap = mapper.Map<Usuario>(usuarioRequest);
        //    //await _usuarioRepositorio.Delete(usuarioMap);
        //    //return usuarioMap.ListaNotificacoes;
        //    return null;
        //}

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/ListarUsuarios")]
        public async Task<IActionResult> ListarUsuarios()
        {
            try
            {
                var usuarios = await _usuarioApplication.ListarUsuarios();

                if (usuarios == null)
                    return CustomResponse(404, true);
                
                var usuariosMap = mapper.Map<List<UsuarioRequest>>(usuarios);

                foreach(var u in usuarios)
                {
                    var userIdentity = await _userManager.FindByIdAsync(u.IdUserIdentity);
                    var role = (await _userManager.GetRolesAsync(userIdentity))?.FirstOrDefault();

                    switch (role)
                    {
                        case "Sindico":
                            usuariosMap.FirstOrDefault(m => m.Id == u.Id).Tipo = TipoUsuario.Sindico;
                            break;
                        case "Morador":
                            usuariosMap.FirstOrDefault(m => m.Id == u.Id).Tipo = TipoUsuario.Morador;
                            break;
                        case "Admin":
                            usuariosMap.FirstOrDefault(m => m.Id == u.Id).Tipo = TipoUsuario.Admin;
                            break;
                        case "Porteiro":
                            usuariosMap.FirstOrDefault(m => m.Id == u.Id).Tipo = TipoUsuario.Porteiro;
                            break;
                        default:
                            break;
                    }
                }
            
                return CustomResponse(200, true, usuariosMap);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/ListarUsuariosTipo")]
        public async Task<IActionResult> ListarUsuariosRole([FromQuery] string tipo)
        {
            try
            {
                var usuarios = await _usuarioApplication.ListarUsuarios();

                if (usuarios == null)
                    return CustomResponse(404, true);

                var usuariosFiltrados = new List<Usuario>();
                foreach (var u in usuarios)
                {
                    var userIdentity = await _userManager.FindByIdAsync(u.IdUserIdentity);
                    var roleUser = (await _userManager.GetRolesAsync(userIdentity))?.FirstOrDefault();
                    
                    if (roleUser.ToLowerInvariant() == tipo.ToLowerInvariant())
                        usuariosFiltrados.Add(u);
                }
                var usuariosMap = mapper.Map<List<UsuarioRequest>>(usuariosFiltrados);

                return CustomResponse(200, true, usuariosMap);
            }
            catch (Exception e)
            {
                _notificador.NotificarMensagemErroInterno();
                return CustomResponse(500, false);
            }
        }


        //[AllowAnonymous]
        //[Produces("application/json")]
        //[HttpPost]
        //public async Task<IActionResult>> Loging
    }
}
