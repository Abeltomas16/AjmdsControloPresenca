using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface IUsuarioRepository : IRepositoryCrud<Usuario>
    {
        Usuario ListarPorNome(string nome);
        IEnumerable<Usuario> ListarTodos();
    }
}
