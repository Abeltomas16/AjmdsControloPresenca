using AjmdsControloPresenca.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface IGeneroRepository : IDisposable
    {
        IEnumerable<Genero> ListarTodos();
    }
}
