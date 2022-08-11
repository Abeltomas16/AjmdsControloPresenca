using turn = AjmdsControloPresenca.Domain.Entities;
namespace AjmdsControloPresenca.UI.Models.Turno
{
    public static class TurnoAddEditExtension
    {
        public static turn.Turno ToTurno(this TurnoAddEditVM Entity)
        {
            return new turn.Turno
            {
                Id = Entity.Id,
                Descricao = Entity.Descricao,
                Entrada = Entity.Entrada,
                Saida = Entity.Saida,
                Estado = Entity.Estado,
                TurnoToleranciaAtraso = Entity.TurnoToleranciaAtraso
            };
        }
    }
}