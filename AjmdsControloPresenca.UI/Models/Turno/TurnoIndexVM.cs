using System;

namespace AjmdsControloPresenca.UI.Models.Turno
{
    public class TurnoIndexVM
    {
        public short Id { get; set; }
        public string Descricao { get; set; }
        public string Entrada { get; set; }
        public string Saida { get; set; }
        public string Estado { get; set; }
        public short TurnoToleranciaAtraso { get; set; }
    }
}