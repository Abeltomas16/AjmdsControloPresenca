using System;

namespace AjmdsControloPresenca.Domain.Entities
{
    public class Afastamento
    {
        public int AfastamentoId { get; set; }
        public string Observacao { get; set; }
        public DateTime DataAfasmento { get; set; }
        public DateTime DataTermino { get; set; }
        public bool Apurado { get; set; }
        public bool Estado { get; set; }


        public short FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        public short SituacaoId { get; set; }
        public virtual Situacao Situacao { get; set; }
    }
}
