﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILivroCaixaApplication
    {
        Task AtualizarLivroCaixa(LivroCaixa livroCaixa);
        Task CadastrarLivroCaixa(LivroCaixa livroCaixa);
        Task<List<LivroCaixa>> ListarLivroCaixas();
    }
}
