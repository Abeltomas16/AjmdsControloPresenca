using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Infra.Entity.Data;
using System.Collections.Generic;
using System.Linq;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class RepositoryEF<T> : IRepositoryCrud<T> where T : class
    {
        EntityDatabaseContext Context = new EntityDatabaseContext();
        public IEnumerable<T> ListarTodos() => Context.Set<T>().ToList();

        public T ListarPorId(object id) => Context.Set<T>().Find(id);

        public void Add(T entidade)
        {
            Context.Set<T>().Add(entidade);
            SaveContext();
        }
        public void Delete(T entidade)
        {
            Context.Set<T>().Remove(entidade);
            SaveContext();
        }
        public void Alter(T entidade)
        {
            Context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
            SaveContext();
        }
        private void SaveContext() => Context.SaveChanges();

        public void Dispose() => Context.Dispose();
    }
}
