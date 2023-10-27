using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Configuration;
using Infraestructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Repositories
{
    public class ReservaRepositorio : RepositoryGenerics<Reserva>, IReservaRepositorio
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public ReservaRepositorio()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<List<Reserva>> ListarPorCondominio(int idCondominio)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await banco.Reserva.Include(o => o.AreaComum).AsNoTracking().Where(u => u.AreaComum.IdCondominio == idCondominio).ToListAsync();
            }
        }
    }
}
