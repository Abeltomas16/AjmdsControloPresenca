using System.Collections.Generic;
using System.Linq;
using User = AjmdsControloPresenca.Domain.Entities;

namespace AjmdsControloPresenca.UI.Models.Usuario
{
    public static class UsuarioIndexExtension
    {
        public static IEnumerable<UsuarioIndexVM> ToUsuarioIndexVM(this IEnumerable<User.Usuario> Entidade)
        {
            return Entidade.Select(f => new UsuarioIndexVM()
            {
                Id = f.FuncionarioId,
                NomeFuncionario = f.Funcionario.Nome,
                Nome = f.Nome,
                Senha = f.Senha
            }
            );
        }
    }
}