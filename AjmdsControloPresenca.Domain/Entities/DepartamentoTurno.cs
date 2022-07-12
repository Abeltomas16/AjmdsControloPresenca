namespace AjmdsControloPresenca.Domain.Entities
{
    public class DepartamentoTurno
    {

        public short DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }

        public short TurnoSegundaId { get; set; }
        public virtual Turno TurnoSegunda { get; set; }
       
        public short TurnoTercaId { get; set; }
        public virtual Turno TurnoTerca { get; set; }

        public short TurnoQuartaId { get; set; }
        public virtual Turno TurnoQuarta { get; set; }

        public short TurnoQuintaId { get; set; }
        public virtual Turno TurnoQuinta { get; set; }

        public short TurnoSextaId { get; set; }
        public virtual Turno TurnoSexta { get; set; }

        public short TurnoSabadoId { get; set; }
        public virtual Turno TurnoSabado { get; set; }

        public short TurnoDomingoId { get; set; }
        public virtual Turno TurnoDomingo { get; set; }
    }
}
