using Func = AjmdsControloPresenca.Domain.Entities;

namespace AjmdsControloPresenca.UI.Models.Funcionario
{
    public static class FuncionarioInfoExtension
    {
        public static FuncionarioInfoVM ToFuncionarioInfoVM(this Func.Usuario entity)
        {
            return new FuncionarioInfoVM()
            {
                Nome = entity.Funcionario.Nome,
                SobreNome = entity.Funcionario.SobreNome,
                Usuario = entity.Nome
            };
        }
    }
}