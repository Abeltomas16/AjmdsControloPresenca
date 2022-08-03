using System;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface IRepositoryCrud<T> : IDisposable where T : class
    {
        T ListarPorId(object id);
        void Add(T entidade);
        void Alter(T entidade);
        void Delete(T entidade);
    }
}
