using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Entities
{
    public class Departamento
    {
        public short Id { get; set; }
        public string Descricao { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
       // public virtual DepartamentoTurno DepartamentoTurno { get; set; }
    }
}
