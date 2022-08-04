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
                Bilhete = Entity.Bilhete,
                SalarioLiquido = Entity.SalarioLiquido,
                Observacao = Entity.Observacao,
                ContactoPrincipal = Entity.ContactoPrincipal,
                ContactoAuxiliar = Entity.ContactoAuxiliar,
                Estado = Entity.Estado,
                GeneroId = Entity.GeneroId,
                EstadoCivilId = Entity.EstadoCivilId,
                DepartamentoId = Entity.DepartamentoId,
                CargoId = Entity.CargoId
            };
        }
        public static Func.Funcionario ToFuncionario(this FuncionarioAddEditVM Entity)
        {
            return new Func.Funcionario
            {
                Id = Entity.Id,
                Nome = Entity.Nome,
                SobreNome = Entity.SobreNome,
                SalarioLiquido = Entity.SalarioLiquido,
                Observacao = Entity.Observacao,
                ContactoPrincipal = Entity.ContactoPrincipal,
                ContactoAuxiliar = Entity.ContactoAuxiliar,
                Bilhete=Entity.Bilhete,
                Estado = Entity.Estado,
                GeneroId = Entity.GeneroId,
                EstadoCivilId = Entity.EstadoCivilId,
                DepartamentoId = Entity.DepartamentoId,
                CargoId = Entity.CargoId
            };
        }
    }
}