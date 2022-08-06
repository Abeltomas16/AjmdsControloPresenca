using System.Collections.Generic;
using System.Linq;
using dept = AjmdsControloPresenca.Domain.Entities;
namespace AjmdsControloPresenca.UI.Models.Departamento
{
    public static class DepartamentoIndexVMExtension
    {
        public static IEnumerable<DepartamentoIndexVM> ToDepartamentoVM(this IEnumerable<dept.Departamento> Entity)
        {
            return Entity.Select(e => new DepartamentoIndexVM
            {
                DepartamentoId = e.DepartamentoId,
                Descricao = e.Descricao,
                Estado = e.Estado ? "Activo" : "Inactivo"
            }); ;
        }
    }
}