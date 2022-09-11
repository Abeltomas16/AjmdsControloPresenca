using System.ComponentModel.DataAnnotations;

namespace AjmdsControloPresenca.UI.Models.TurnoFunc
{
    public class TurnoFuncAddEditVM
    {
        [Required]
        [Display(Name = "Funcionário")]
        public short Id { get; set; }

        [Required]
        [Display(Name = "Turno segunda")]
        public short TurnoSegundaId { get; set; }

        [Required]
        [Display(Name = "Turno terca")]
        public short TurnoTercaId { get; set; }

        [Required]
        [Display(Name = "Turno quarta")]
        public short TurnoQuartaId { get; set; }

        [Required]
        [Display(Name = "Turno quinta")]
        public short TurnoQuintaId { get; set; }

        [Required]
        [Display(Name = "Turno sexta")]
        public short TurnoSextaId { get; set; }

        [Required]
        [Display(Name = "Turno sabádo")]
        public short TurnoSabadoId { get; set; }

        [Required]
        [Display(Name = "Turno domingo")]
        public short TurnoDomingoId { get; set; }
    }
}