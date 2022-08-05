using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface IUsuarioRepository : IRepositoryCrud<Usuario>
    {
        Usuario ListarPorNome(string nome);
        Usuario ListarPorBI(string Bilhete);
        IEnumerable<Usuario> ListarTodos();
    }
}
