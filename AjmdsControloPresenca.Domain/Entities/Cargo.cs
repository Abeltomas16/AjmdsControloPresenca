using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Entities
{
    public class Cargo
    {
        public short CargoId { get; set; }
        public string Descricao { get; set; }


        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
