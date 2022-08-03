using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class UsuarioRepositoryEF : RepositoryEF<Usuario>, IUsuarioRepository
    {
        public Usuario ListarPorNome(string nome) => Context.Usuarios.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
        public IEnumerable<Usuario> ListarTodos() => Context.Set<Usuario>().Include(c => c.Funcionario).ToList();
    }
}
