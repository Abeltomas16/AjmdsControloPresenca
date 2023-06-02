using AjmdsControloPresenca.UI.Models.Cargo;
using System.Collections.Generic;
using System.Linq;
using carg = AjmdsControloPresenca.Domain.Entities;

namespace AjmdsControloPresenca.UI.Models.Afastamento
{
    public static class AfastamentoIndexExtension
    {
        public static IEnumerable<AfastamentoIndexVM> ToAfastamentoIndexVM(this IEnumerable<carg.Afastamento> Entity)
        {
            return Entity.Select(e => new AfastamentoIndexVM
            {
                Id=e.Id,
                FuncionarioNome = string.Concat(e.Funcionario.Nome, " ", e.Funcionario.SobreNome),
                FuncionarioId = e.Funcionario.Id,
                Observacao = e.Observacao,
                Situacao = e.Situacao.Descricao,
                DataTermino = e.DataTermino == null ? "" : e.DataTermino.ToString("dd-MM-yyyy"),
                DataAfastamento = e.DataAfastamento == null ? "" : e.DataAfastamento.ToString("dd-MM-yyyy"),
                Estado = e.Estado,
                Apurado = e.Apurado
            });
        }
    }
}