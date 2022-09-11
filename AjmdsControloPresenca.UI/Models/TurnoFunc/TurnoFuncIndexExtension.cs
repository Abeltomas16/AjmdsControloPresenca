using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AjmdsControloPresenca.UI.Models.TurnoFunc
{
    public static class TurnoFuncIndexExtension
    {
        public static IEnumerable<TurnoFuncIndexVM> ToTurnoFuncVM(this IEnumerable<FuncionarioTurno> entitie)
        {
            return entitie.Select(x =>
             new TurnoFuncIndexVM
             {
                 Id = x.FuncionarioId,
                 Funcionario = x.Funcionario.Nome,
                 TurnoSegunda = x.TurnoSegunda.Descricao,
                 TurnoTerca = x.TurnoTerca.Descricao,
                 TurnoQuarta = x.TurnoQuarta.Descricao,
                 TurnoQuinta = x.TurnoQuinta.Descricao,
                 TurnoSexta = x.TurnoSexta.Descricao,
                 TurnoSabado = x.TurnoSabado.Descricao,
                 TurnoDomingo = x.TurnoDomingo.Descricao,
             }
            );
        }
    }
}