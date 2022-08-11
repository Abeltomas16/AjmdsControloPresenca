using System;

namespace AjmdsControloPresenca.UI.Models.Turno
{
    public class TurnoIndexVM
    {
        public short Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public string Estado { get; set; }
        public short TurnoToleranciaAtraso { get; set; }
    }
}