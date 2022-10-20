using AjmdsControloPresenca.Domain.Entities.Relatorio;
using System;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface IRelatorioRepository : IDisposable
    {
        IEnumerable<RelFolhaPresenca> Listar(short id, DateTime DataIn, DateTime DataFim);
    }
}
