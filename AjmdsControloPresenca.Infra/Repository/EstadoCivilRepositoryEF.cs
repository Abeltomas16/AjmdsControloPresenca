using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities;
using AjmdsControloPresenca.Infra.Entity.Data;
using System.Collections.Generic;
using System.Linq;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class EstadoCivilRepositoryEF : IEstadoCivilRepository
    {
        private EntityDatabaseContext Context = new EntityDatabaseContext();
        public IEnumerable<EstadoCivil> ListarTodos() => Context.Set<EstadoCivil>().ToList();
        public void Dispose()=> Context.Dispose();      
    }
}
