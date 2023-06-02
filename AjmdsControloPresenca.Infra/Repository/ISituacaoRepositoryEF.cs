using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class ISituacaoRepositoryEF : RepositoryEF<Situacao>, ISituacaoRepository
    {
        public IEnumerable<Situacao> ListarTodos() => Context.Set<Situacao>().ToList();
    }
}
