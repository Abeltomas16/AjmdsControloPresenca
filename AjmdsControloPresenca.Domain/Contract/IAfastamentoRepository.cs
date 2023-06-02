using AjmdsControloPresenca.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface IAfastamentoRepository : IRepositoryCrud<Afastamento>
    {
        IEnumerable<Afastamento> ListarTodos();
        bool AtestadoDataExiste(Afastamento e);
    }
}
