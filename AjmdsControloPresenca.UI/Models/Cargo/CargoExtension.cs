using System.Collections.Generic;
using System.Linq;
using carg = AjmdsControloPresenca.Domain.Entities;

namespace AjmdsControloPresenca.UI.Models.Cargo
{
    public static class CargoExtension
    {
        public static IEnumerable<CargoIndexVM> ToCargoIndexVM(this IEnumerable<carg.Cargo> Entity)
        {
            return Entity.Select(e => new CargoIndexVM
            {
                Id = e.CargoId,
                Descricao = e.Descricao
            });
        }

        public static carg.Cargo ToCargo(this CargoIndexVM Entity)
        {
            return new carg.Cargo
            {
                CargoId = Entity.Id,
                Descricao = Entity.Descricao.ToUpper(),
            };
        }
        public static CargoIndexVM ToCargoVM(this carg.Cargo Entity)
        {
            return new CargoIndexVM
            {
                Id = Entity.CargoId,
                Descricao = Entity.Descricao
            };
        }

    }
}