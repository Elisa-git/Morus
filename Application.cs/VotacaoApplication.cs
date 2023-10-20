using Application.Interfaces;
using Core.Notificador;
using Domain.Entities;
using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces;
using Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using Core.Exceptions;

namespace Application
{
    public class VotacaoApplication : IVotacaoApplication
    {
        private readonly IVotacaoRepositorio _votacaoRepositorio;
        private readonly ValidatorBase<Votacao> _votacaoValidator;
        private readonly IVotacaoService _votacaoService;
        private readonly IUserLogadoApplication _userLogadoApplication;
        private readonly IVotoRepositorio _votoRepositorio;
        private readonly INotificador _notificador;

        public VotacaoApplication(IVotacaoRepositorio votacaoRepositorio, INotificador notificador, IVotacaoService votacaoService, IUserLogadoApplication userLogadoApplication, IVotoRepositorio votoRepositorio)
        {
            _votacaoRepositorio = votacaoRepositorio;
            _votacaoValidator = new ValidatorBase<Votacao>(notificador);
            _votacaoService = votacaoService;
            _userLogadoApplication = userLogadoApplication;
            _votoRepositorio = votoRepositorio;
            _notificador = notificador;
        }

        public async Task CadastrarVotacao(Votacao votacao)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            votacao.IdCondominio = usuarioLogado.IdCondominio;

            await _votacaoService.CadastrarVotacao(votacao);
        }
        public async Task<List<Votacao>> ListarVotacoesCondominio()
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            return await _votacaoService.ListarPorCondominio(usuarioLogado.IdCondominio);
        }

        public async Task RegistrarVoto(Voto voto)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            var votosUsuario = await _votoRepositorio.ListarVotos(v => v.IdUsuario == usuarioLogado.Id);
            var votacao = await _votacaoRepositorio.GetEntityById(voto.IdVotacao);

            if (votacao.DataExpiracao > DateTime.Now)
            {
                _notificador.Notificar("Votação está encerrada");
                throw new ValidacaoException("");
            }

            if (votosUsuario != null && votosUsuario.Any()) 
            {
                _notificador.Notificar("Usuário já realizou voto único");
                throw new ValidacaoException("");
            }

            voto.IdUsuario = usuarioLogado.Id;
            await _votoRepositorio.Add(voto);
        }

        public async Task<VotacaoContadorResponse> ContadorVotacao(int idVotacao)
        {
            var usuarioLogado = await _userLogadoApplication.ObterUsuarioLogado();
            var votacao = await _votacaoRepositorio.GetEntityById(idVotacao);
            var votos = await _votoRepositorio.ListarVotos(v => v.IdVotacao == votacao.Id);

            return new VotacaoContadorResponse
            {
                Id = votacao.Id,
                Tema = votacao.Tema,
                Descricao = votacao.Descricao,
                Ativa = votacao.Ativa,
                DataCriacao = votacao.DataCriacao,
                DataExpiracao = votacao.DataExpiracao,
                QtdVotosContras = votos.Count(v => v.ValorVoto == false),
                QtdVotosFavoraveis = votos.Count(v => v.ValorVoto == true),
                QtdVotosNulos = votos.Count(v => v.ValorVoto == null)
            };
        }
    }
}
