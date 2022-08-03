using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class CargoRepositoryEF : RepositoryEF<Cargo>, ICargoRepository
    {
        public IEnumerable<Cargo> ListarTodos() => Context.Set<Cargo>().ToList();
    }
}
