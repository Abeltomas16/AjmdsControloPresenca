using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class AfastamentoRepositoryEF : RepositoryEF<Afastamento>, IAfastamentoRepository
    {
        public IEnumerable<Afastamento> ListarTodos() => Context.Set<Afastamento>().Include(s => s.Situacao).Include(f => f.Funcionario).ToList();
        public bool AtestadoDataExiste (Afastamento e)=> Context.Set<Afastamento>()
                .Any(x => x.FuncionarioId == e.FuncionarioId && x.DataAfastamento <= e.DataTermino && x.DataTermino >= e.DataAfastamento);      
    }
}
