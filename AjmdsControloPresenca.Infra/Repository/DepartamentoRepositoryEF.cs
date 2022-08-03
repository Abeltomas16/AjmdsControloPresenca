using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class DepartamentoRepositoryEF : RepositoryEF<Departamento>, IDepartamentoRepository
    {
        public IEnumerable<Departamento> ListarTodos() => Context.Set<Departamento>().ToList();
    }
}
