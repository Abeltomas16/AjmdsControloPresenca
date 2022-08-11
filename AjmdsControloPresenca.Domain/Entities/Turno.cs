using System;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Entities
{
    public class Turno
    {
        public short Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public bool Estado { get; set; }
        public short TurnoToleranciaAtraso { get; set; }

        public virtual ICollection<DepartamentoTurno> DepartamentoTurno { get; set; }
        public virtual ICollection<DepartamentoTurno> DepartamentoTurnoTerca { get; set; }
        public virtual ICollection<DepartamentoTurno> DepartamentoTurnoQuarta { get; set; }
        public virtual ICollection<DepartamentoTurno> DepartamentoTurnoQuinta { get; set; }
        public virtual ICollection<DepartamentoTurno> DepartamentoTurnoSexta { get; set; }
        public virtual ICollection<DepartamentoTurno> DepartamentoTurnoSabado { get; set; }
        public virtual ICollection<DepartamentoTurno> DepartamentoTurnoDomingo { get; set; }
    }
}
