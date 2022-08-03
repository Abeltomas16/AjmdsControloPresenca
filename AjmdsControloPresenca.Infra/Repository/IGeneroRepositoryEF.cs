using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities;
using AjmdsControloPresenca.Infra.Entity.Data;
using System.Collections.Generic;
using System.Linq;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class IGeneroRepositoryEF : IGeneroRepository
    {
        private EntityDatabaseContext Context = new EntityDatabaseContext();
        public IEnumerable<Genero> ListarTodos() => Context.Set<Genero>().ToList();
        public void Dispose() => Context.Dispose();
    }
}
