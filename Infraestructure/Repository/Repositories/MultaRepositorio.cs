﻿using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repository.Repositories
{
    public class MultaRepositorio : RepositoryGenerics<Multa>, IMulta
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public MultaRepositorio()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Multa>> ListarMessage(Expression<Func<Multa, bool>> exMessage)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Multa.Where(exMessage).AsNoTracking().ToListAsync();
            }
        }
    }
}
