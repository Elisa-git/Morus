using Domain.Interfaces;
using Entities.Entities;
using Infraestructure.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Repositories
{
    public class CondominioRepositorio : RepositoryGenerics<Condominio>, ICondominio
    {
    }
}
