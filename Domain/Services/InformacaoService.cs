using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class InformacaoService : IInformacaoService
    {
        private readonly IInformacaoRepositorio informacaoRepositorio;

        public InformacaoService(IInformacaoRepositorio informacaoRepositorio)
        {
            this.informacaoRepositorio = informacaoRepositorio;
        }

        public async Task CadastrarInformacao(Informacao informacaoRequest)
        {
            var validatitulo = informacaoRequest.ValidarPropriedadeString(informacaoRequest.Titulo, "Titulo");
            if (validatitulo)
            {
                informacaoRequest.DataCadastro = DateTime.Now;
                informacaoRequest.DataAlteracao = DateTime.Now;
                informacaoRequest.Ativo = true;
                await informacaoRepositorio.Add(informacaoRequest);
            }
        }

        public async Task AtualizarInformacao(Informacao informacaoRequest)
        {
            var validatitulo = informacaoRequest.ValidarPropriedadeString(informacaoRequest.Titulo, "Titulo");
            if (validatitulo)
            {
                informacaoRequest.DataAlteracao = DateTime.Now;
                await informacaoRepositorio.Update(informacaoRequest);
            }
        }

        public async Task<List<Informacao>> ListarInformacoesAtivas()
        {
            return await informacaoRepositorio.ListarInformacoes(n => n.Ativo);
        }
    }
}