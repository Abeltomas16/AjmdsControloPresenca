using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface IDepartamentoRepository:IRepositoryCrud<Departamento>
    {
        IEnumerable<Departamento> ListarTodos();
    }
}
