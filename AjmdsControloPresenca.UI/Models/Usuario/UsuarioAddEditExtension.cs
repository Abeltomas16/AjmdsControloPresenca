using Func = AjmdsControloPresenca.Domain.Entities;

namespace AjmdsControloPresenca.UI.Models.Usuario
{
    public static class UsuarioAddEditExtension
    {
        public static Func.Usuario ToUsuario(this UsuarioAddEditVM Entity)
        {
            return new Func.Usuario
            {
                FuncionarioId = Entity.FuncionarioId,
                Nome = Entity.Nome,
                Senha = Entity.Password
            };
        }
    }
}