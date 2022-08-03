using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface ICargoRepository : IRepositoryCrud<Cargo>
    {
        IEnumerable<Cargo> ListarTodos();
    }
}
