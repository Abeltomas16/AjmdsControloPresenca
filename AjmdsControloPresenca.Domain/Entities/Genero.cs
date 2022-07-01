using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Entities
{
    public class Genero
    {
        public short Id { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
