using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class PresencaRepositoryEF : RepositoryEF<Presenca>, IPresencaRepository
    {
        public Presenca ListarPor(int Id) => Context.Presencas.Where(p => p.Id == Id).FirstOrDefault();
    }
}
