using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace AjmdsControloPresenca.Infra.Repository
{
    public class TurnoFuncRepositoryEF : RepositoryEF<FuncionarioTurno>, ITurnoFuncRepository
    {
        public FuncionarioTurno OverListarPorId(int Id)
        {
            return Context.Set<FuncionarioTurno>()
                          .Include(a => a.TurnoSegunda)
                          .Include(b => b.TurnoTerca)
                          .Include(c => c.TurnoQuarta)
                          .Include(d => d.TurnoQuinta)
                          .Include(e => e.TurnoSexta)
                          .Include(f => f.TurnoSabado)
                          .Include(g => g.TurnoDomingo)
                          .Include(h => h.Funcionario)
                          .Where(i => i.FuncionarioId == Id)
                          .FirstOrDefault();
        }

        public IEnumerable<FuncionarioTurno> ListarTodos()
        {
            return Context.Set<FuncionarioTurno>()
              .Include(a => a.TurnoSegunda)
              .Include(b => b.TurnoTerca)
              .Include(c => c.TurnoQuarta)
              .Include(d => d.TurnoQuinta)
              .Include(e => e.TurnoSexta)
              .Include(f => f.TurnoSabado)
              .Include(g => g.TurnoDomingo)
              .Include(h => h.Funcionario)
              .ToList();
        }
    }
}
