﻿using Domain.Entities;
using Domain.Interfaces;
using Google.Protobuf;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repository.Repositories
{
    public class OcorrenciaRepositorio : RepositoryGenerics<Ocorrencia>, IOcorrencia
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public OcorrenciaRepositorio()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Ocorrencia>> ListarMessage(Expression<Func<Ocorrencia, bool>> exMessage)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Ocorrencia.Where(exMessage).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Ocorrencia>> ListarPorCondominio(int idCondominio)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Ocorrencia.Include(o => o.Usuario).AsNoTracking().Where(u => u.Usuario.IdCondominio == idCondominio).ToListAsync();
            }
        }

        public async Task<List<Ocorrencia>> ListarPorCondominioMessage(int idCondominio, Expression<Func<Ocorrencia, bool>> exMessage)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Ocorrencia.Include(o => o.Usuario).AsNoTracking().Where(u => u.Usuario.IdCondominio == idCondominio).Where(exMessage).ToListAsync();
            }
        }
    }
}
