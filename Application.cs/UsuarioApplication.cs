using Application.Interfaces;
using Core.Exceptions;
using Core.Notificador;
using Domain.Interfaces;
using Entities.Entities;
using Entities.Validacoes;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly INotificador _notificador;
        private readonly IUsuario _usuarioRepository;
        private readonly ValidatorBase<Usuario> _usuarioValidation;

        public UsuarioApplication(INotificador notificador, IUsuario usuarioRepository)
        {
            _notificador = notificador;
            _usuarioRepository = usuarioRepository;
            _usuarioValidation = new ValidatorBase<Usuario>(notificador);
        }

        public async Task Cadastrar(Usuario usuario)
        {
            if (_usuarioValidation.ValidarEntidade(usuario))
                throw new ValidacaoException();

            await _usuarioRepository.Add(usuario);
        }

    }
}
