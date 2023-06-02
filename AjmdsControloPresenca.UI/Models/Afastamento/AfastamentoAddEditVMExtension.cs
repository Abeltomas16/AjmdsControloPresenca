using System;
using Func = AjmdsControloPresenca.Domain.Entities;

namespace AjmdsControloPresenca.UI.Models.Afastamento
{
    public static class AfastamentoAddEditVMExtension
    {
        public static AfastamentoAddEditVM ToAfastamentoVM(this Func.Afastamento e)
        {
            if (e is null) return null;
            return new AfastamentoAddEditVM
            {
                Id=e.Id,
                FuncionarioId = e.FuncionarioId,
                SituacaoId= e.SituacaoId,
                Observacao = e.Observacao,
                DataAfastamento = e.DataAfastamento.ToString("yyyy-MM-dd"),
                DataTermino = e.DataTermino.ToString("yyyy-MM-dd"),
                Apurado=e.Apurado,
            };
        }
        public static Func.Afastamento ToAfastamento(this AfastamentoAddEditVM e)
        {
            return new Func.Afastamento
            {
                Id = e.Id,
                FuncionarioId = e.FuncionarioId,
                SituacaoId=e.SituacaoId,
                Observacao = e.Observacao,
                DataAfastamento =Convert.ToDateTime(e.DataAfastamento),
                DataTermino =Convert.ToDateTime(e.DataTermino),
                Apurado = e.Apurado,
            };
        }
    }
}