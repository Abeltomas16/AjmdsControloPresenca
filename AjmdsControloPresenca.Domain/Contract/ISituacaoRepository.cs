using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;
namespace AjmdsControloPresenca.Domain.Contract
{
    public interface ISituacaoRepository : IRepositoryCrud<Situacao>
    {
        IEnumerable<Situacao> ListarTodos();
    }
}
