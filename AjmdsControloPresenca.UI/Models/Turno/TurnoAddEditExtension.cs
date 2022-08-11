using System;
using turn = AjmdsControloPresenca.Domain.Entities;
namespace AjmdsControloPresenca.UI.Models.Turno
{
    public static class TurnoAddEditExtension
    {
        public static turn.Turno ToTurno(this TurnoAddEditVM Entity)
        {
            DateTime agora = DateTime.Now;
            DateTime Entrada = new DateTime(
                   agora.Year, agora.Month, agora.Day,
                   Entity.Entrada.Hours, Entity.Entrada.Minutes, Entity.Entrada.Seconds
                );
            DateTime Saida = new DateTime(
               agora.Year, agora.Month, agora.Day,
               Entity.Saida.Hours, Entity.Saida.Minutes, Entity.Saida.Seconds
            );

            return new turn.Turno
            {
                Id = Entity.Id,
                Descricao = Entity.Descricao.ToUpper(),
                Entrada = Entrada,
                Saida = Saida,
                Estado = Entity.Estado,
                TurnoToleranciaAtraso = Entity.TurnoToleranciaAtraso
            };
        }
        public static TurnoAddEditVM ToTurnoVM(this turn.Turno Entity)
        {
            return new TurnoAddEditVM
            {
                Id = Entity.Id,
                Descricao = Entity.Descricao,
                Entrada = Entity.Entrada.TimeOfDay,
                Saida = Entity.Saida.TimeOfDay,
                Estado = Entity.Estado,
                TurnoToleranciaAtraso = Entity.TurnoToleranciaAtraso
            };
        }
    }
}