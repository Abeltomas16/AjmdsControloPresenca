using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface ITurnoFuncRepository : IRepositoryCrud<FuncionarioTurno>
    {
        IEnumerable<FuncionarioTurno> ListarTodos();
        FuncionarioTurno ListarPorId(int Id);
    }
}
