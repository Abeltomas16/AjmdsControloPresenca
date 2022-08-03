using System;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Entities
{
    public class Presenca
    {
        public int Id { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public DateTime Cadastro { get; set; }
        public short FuncionarioId { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
