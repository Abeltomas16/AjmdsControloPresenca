using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface ITurnoRepository:IRepositoryCrud<Turno>
    {
        IEnumerable<Turno> ListarTodos();
    }
}
