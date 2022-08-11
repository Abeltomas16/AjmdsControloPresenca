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

        public virtual ICollection<FuncionarioTurno> FuncionarioTurnoSegunda { get; set; }
        public virtual ICollection<FuncionarioTurno> FuncionarioTurnoTerca { get; set; }
        public virtual ICollection<FuncionarioTurno> FuncionarioTurnoQuarta { get; set; }
        public virtual ICollection<FuncionarioTurno> FuncionarioTurnoQuinta { get; set; }
        public virtual ICollection<FuncionarioTurno> FuncionarioTurnoSexta { get; set; }
        public virtual ICollection<FuncionarioTurno> FuncionarioTurnoSabado { get; set; }
        public virtual ICollection<FuncionarioTurno> FuncionarioTurnoDomingo { get; set; }
    }
}
