using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Entities
{
    public class Situacao
    {
        public short SituacaoId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Afastamento> Afastamentos { get; set; }
    }
}
