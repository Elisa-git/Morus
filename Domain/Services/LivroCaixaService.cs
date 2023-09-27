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
