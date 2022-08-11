using System.Collections.Generic;
using System.Linq;
using turn = AjmdsControloPresenca.Domain.Entities;
namespace AjmdsControloPresenca.UI.Models.Turno
{
    public static class TurnoIndexExtension
    {
        public static IEnumerable<TurnoIndexVM> ToTurnoVM(this IEnumerable<turn.Turno> Entity)
        {
            return Entity.Select(e =>
            new TurnoIndexVM
            {
                Id = e.Id,
                Descricao = e.Descricao,
                Entrada = e.Entrada.ToShortTimeString(),
                Saida = e.Saida.ToShortTimeString(),
                Estado = e.Estado ? "Activo" : "Inactivo",
                TurnoToleranciaAtraso = e.TurnoToleranciaAtraso
            });
        }
    }
}