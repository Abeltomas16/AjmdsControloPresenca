namespace AjmdsControloPresenca.Domain.Entities
{
    public class DepartamentoTurno
    {

        public short DepartamentoId { get; set; }
        public virtual Departamento  Departamento { get; set; }

        public short Segunda { get; set; }
        public virtual Turno TurnoS { get; set; }

        public short Terca { get; set; }
        public virtual Turno TurnoT { get; set; }

        public short Quarta { get; set; }
        public virtual Turno TurnoQ { get; set; }

        public short Quinta { get; set; }
        public virtual Turno TurnoQT { get; set; }

        public short Sexta { get; set; }
        public virtual Turno TurnoST { get; set; }

        public short Sabado { get; set; }
        public virtual Turno TurnoSB { get; set; }

        public short Domingo { get; set; }
        public virtual Turno TurnoDM { get; set; }
    }
}
