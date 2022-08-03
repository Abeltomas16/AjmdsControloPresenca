using AjmdsControloPresenca.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface IEstadoCivilRepository : IDisposable
    {
        IEnumerable<EstadoCivil> ListarTodos();
    }
}
