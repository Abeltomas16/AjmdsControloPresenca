using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface IFuncionarioRepository : IRepositoryCrud<Funcionario>
    {
        IEnumerable<Funcionario> ListarTodos();
    }
}
