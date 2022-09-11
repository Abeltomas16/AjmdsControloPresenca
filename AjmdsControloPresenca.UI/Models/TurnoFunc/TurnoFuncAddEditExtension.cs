using AjmdsControloPresenca.Domain.Entities;

namespace AjmdsControloPresenca.UI.Models.TurnoFunc
{
    public static class TurnoFuncAddEditExtension
    {
        public static FuncionarioTurno ToFuncionarioTurno(this TurnoFuncAddEditVM Entity)
        {
            return new FuncionarioTurno
            {
                FuncionarioId = Entity.Id,
                TurnoSegundaId = Entity.TurnoSegundaId,
                TurnoTercaId = Entity.TurnoTercaId,
                TurnoQuartaId = Entity.TurnoQuartaId,
                TurnoQuintaId = Entity.TurnoQuintaId,
                TurnoSextaId = Entity.TurnoSextaId,
                TurnoSabadoId = Entity.TurnoSabadoId,
                TurnoDomingoId = Entity.TurnoDomingoId
            };
        }
        public static TurnoFuncAddEditVM ToFuncionarioTurnoVM(this FuncionarioTurno Entity)
        {
            return new TurnoFuncAddEditVM
            {
                Id = Entity.FuncionarioId,
                TurnoSegundaId = Entity.TurnoSegundaId,
                TurnoTercaId = Entity.TurnoTercaId,
                TurnoQuartaId = Entity.TurnoQuartaId,
                TurnoQuintaId = Entity.TurnoQuintaId,
                TurnoSextaId = Entity.TurnoSextaId,
                TurnoSabadoId = Entity.TurnoSabadoId,
                TurnoDomingoId = Entity.TurnoDomingoId
            };
        }
    }
}