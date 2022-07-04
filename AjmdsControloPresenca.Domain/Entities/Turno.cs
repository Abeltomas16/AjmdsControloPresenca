using System;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Entities
{
    public class Turno
    {
        public short Id { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public bool Estado { get; set; }
        public short TurnoToleranciaAtraso { get; set; }
        public virtual ICollection<DepartamentoTurno> DepartamentosTurnos { get; set; }
    }
}
