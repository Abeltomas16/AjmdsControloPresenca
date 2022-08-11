using System;
using System.ComponentModel.DataAnnotations;

namespace AjmdsControloPresenca.UI.Models.Turno
{
    public class TurnoAddEditVM
    {
        public short Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Entrada { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Saida { get; set; }

        public bool Estado { get; set; }

        [Required]
        [Display(Name = "Tolerância")]
        [DataType(DataType.Duration)]
        public short TurnoToleranciaAtraso { get; set; }
    }
}