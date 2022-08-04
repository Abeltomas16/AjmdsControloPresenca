using System.Collections.Generic;
using System.Linq;
using Func = AjmdsControloPresenca.Domain.Entities;
namespace AjmdsControloPresenca.UI.Models.Funcionario
{
    public static class FuncionarioIndexExtension
    {
        public static IEnumerable<FuncionarioIndexVM> ToFuncionarioIndex(this IEnumerable<Func.Funcionario> Entity)
        {
            return Entity.Select(f => new FuncionarioIndexVM
            {
                Id = f.Id,
                Nome = f.Nome,
                SobreNome = f.SobreNome,
                Bilhete=f.Bilhete,
                ContactoPrincipal = f.ContactoPrincipal,
                EstadoCivilDescricao = f.EstadoCivil.Descricao,
                DepartamentoDescricao = f.Departamento.Descricao,
                CargoDescricao = f.Cargo.Descricao
            });
        }
    }
}