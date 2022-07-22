using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities;
using System.Linq;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class UsuarioRepositoryEF : RepositoryEF<Usuario>, IUsuarioRepository
    {
        public Usuario ListarPorNome(string nome) => Context.Usuarios.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
    }
}
