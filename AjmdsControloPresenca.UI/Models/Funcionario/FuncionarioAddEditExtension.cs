using Func = AjmdsControloPresenca.Domain.Entities;

namespace AjmdsControloPresenca.UI.Models.Funcionario
{
    public static class FuncionarioAddEditExtension
    {
        public static FuncionarioAddEditVM ToFuncionarioAddEdit(this Func.Funcionario Entity)
        {
            return new FuncionarioAddEditVM
            {
                Id = Entity.Id,
                Nome = Entity.Nome,
                SobreNome = Entity.SobreNome,
                SalarioLiquido = Entity.SalarioLiquido,
                Observacao = Entity.Observacao,
                ContactoPrincipa = Entity.ContactoPrincipa,
                ContactoAuxiliar = Entity.ContactoAuxiliar,
                Estado = Entity.Estado,
                DataCadastro = Entity.DataCadastro,
                GeneroId = Entity.GeneroId,
                EstadoCivilId = Entity.EstadoCivilId,
                DepartamentoId = Entity.DepartamentoId,
                CargoId = Entity.CargoId
            };
        }
    }
}