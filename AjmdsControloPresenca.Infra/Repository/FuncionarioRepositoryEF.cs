using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace AjmdsControloPresenca.Infra.Repository
{
    public class FuncionarioRepositoryEF : RepositoryEF<Funcionario>, IFuncionarioRepository
    {
        public Funcionario ListarBI(string BI) => Context.Set<Funcionario>().Include(c => c.Cargo).Include(c => c.Departamento).Include(c => c.EstadoCivil).Include(c => c.Genero).Where(f => f.Bilhete.ToLower() == BI.ToLower()).FirstOrDefault();
        public Funcionario ListarTudoPorId(short Id) => Context.Set<Funcionario>().Include(c => c.Cargo).Include(c => c.Departamento).Include(c => c.EstadoCivil).Include(c => c.Genero).Where(f => f.Id == Id).FirstOrDefault();
        public IEnumerable<Funcionario> ListarTodos() => Context.Set<Funcionario>().Include(c => c.Cargo).Include(c => c.Departamento).Include(c => c.EstadoCivil).Include(c => c.Genero).ToList();
    }
}
