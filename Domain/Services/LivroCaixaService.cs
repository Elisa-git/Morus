using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;

namespace Domain.Services
{
    public class LivroCaixaService : ILivroCaixaService
    {
        private readonly ILivroCaixaRepositorio livroCaixaRepositorio;
        public LivroCaixaService(ILivroCaixaRepositorio livroCaixaRepositorio)
        {
            this.livroCaixaRepositorio = livroCaixaRepositorio;
        }

        public async Task CadastrarLivroCaixa(LivroCaixa livroCaixa)
        {
            await livroCaixaRepositorio.Add(livroCaixa);
        }
    }
}
