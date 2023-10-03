using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Morus.API.Models;

namespace Morus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaComumController : ControllerBase
    {
        private readonly IAreaComumRepositorio areaComumRepositorio;
        private readonly IMapper mapper;

        public AreaComumController(IAreaComumRepositorio areaComumRepositorio, IMapper mapper)
        {
            this.areaComumRepositorio = areaComumRepositorio;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CadastrarAreaComum")]
        public IActionResult CadastrarAreaComum(AreaComumRequest areaComumRequest)
        {
            if (areaComumRequest.Id_condominio == null)
                return BadRequest();

            var areaComum = mapper.Map<AreaComum>(areaComumRequest);
            areaComumRepositorio.Add(areaComum);
            areaComum.Mensagem = "Área Comum foi cadastrado com sucesso";

            return Ok(areaComum);
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPut("/api/EditarAreaComum")]
        public AreaComum AtualizarAreaComum(AreaComumRequest areaComumRequest)
        {
            var areaComum = mapper.Map<AreaComum>(areaComumRequest);
            areaComumRepositorio.Update(areaComum);

            return areaComum;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpDelete("/api/DeletarAreaComum")]
        public List<Notifies> DeletarAreaComum(AreaComumRequest areaComumRequest)
        {
            var areaComum = mapper.Map<AreaComum>(areaComumRequest);
            areaComumRepositorio.Delete(areaComum);
            areaComum.Mensagem = "Área Comum foi deletado com sucesso";

            return areaComum.ListaNotificacoes;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpGet("/api/ListarAreasComuns")]
        public async Task<List<AreaComumRequest>> ListarAreasComuns()
        {
            var areaComum = await areaComumRepositorio.List();
            var areaComumMapeado = mapper.Map<List<AreaComumRequest>>(areaComum);
            return areaComumMapeado;
        }
    }
}
