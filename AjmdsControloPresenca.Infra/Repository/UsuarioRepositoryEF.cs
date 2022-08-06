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
        public Usuario ListarPorBI(string Bilhete) => Context.Set<Usuario>().Include(c => c.Funcionario).Where(f => f.Funcionario.Bilhete.ToLower() == Bilhete.ToLower()).FirstOrDefault();
        public Usuario ListarPorIdFunconario(short funcionario) => Context.Set<Usuario>().Include(c => c.Funcionario).Where(f => f.FuncionarioId == funcionario).FirstOrDefault();
        public IEnumerable<Usuario> ListarTodos() => Context.Set<Usuario>().Include(c => c.Funcionario).ToList();
    }
}
