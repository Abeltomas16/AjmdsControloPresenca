using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class TurnoRepositoryEF : RepositoryEF<Turno>, ITurnoRepository
    {
        public IEnumerable<Turno> ListarTodos() => Context.Set<Turno>().ToList();
    }
}
