using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroCaixaController : ControllerBase
    {
        private readonly ILivroCaixaRepositorio livroCaixaRepositorio;
        private readonly IMapper mapper;

        public LivroCaixaController(ILivroCaixaRepositorio livroCaixaRepositorio, IMapper mapper)
        {
            this.livroCaixaRepositorio = livroCaixaRepositorio;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarLivroCaixa")]
        public IActionResult CadastrarLivroCaixa(LivroCaixaRequest livroCaixaRequest)
        {
            if (livroCaixaRequest.Id_condominio == null)
                return BadRequest();

            var livroCaixa = mapper.Map<LivroCaixa>(livroCaixaRequest);
            livroCaixaRepositorio.Add(livroCaixa);
            livroCaixa.Mensagem = "Livro Caixa foi cadastrado com sucesso";

            return Ok(livroCaixa);
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPut("/api/EditarLivroCaixa")]
        public LivroCaixa AtualizarLivroCaixa(LivroCaixaRequest livroCaixaRequest)
        {
            var livroCaixa = mapper.Map<LivroCaixa>(livroCaixaRequest);
            livroCaixaRepositorio.Update(livroCaixa);

            return livroCaixa;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpDelete("/api/DeletarLivroCaixa")]
        public List<Notifies> DeletarLivroCaixa(LivroCaixaRequest livroCaixaRequest)
        {
            var livroCaixa = mapper.Map<LivroCaixa>(livroCaixaRequest);
            livroCaixaRepositorio.Delete(livroCaixa);
            livroCaixa.Mensagem = "Livro Caixa foi deletado com sucesso";

            return livroCaixa.ListaNotificacoes;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("/api/ListarLivroCaixa")]
        public async Task<List<LivroCaixaRequest>> ListarLivroCaixa()
        {
            var livroCaixa = await livroCaixaRepositorio.List();
            var livroCaixaMapeado = mapper.Map<List<LivroCaixaRequest>>(livroCaixa);
            return livroCaixaMapeado;
        }
    }
}
