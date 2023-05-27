using System.ComponentModel.DataAnnotations;

namespace AjmdsControloPresenca.UI.Models.Justificar
{
    public class JustificarVM
    {
        [Required, Editable(false), Display(Name = "Presenca")]
        public int Id { get; set; }

        [Required, DataType(DataType.Date)]
        public string Data { get; set; }

        [Required, DataType(DataType.Time), Display(Name = "Hora inicial")]
        public string HoraInicial { get; set; }

        [Required, DataType(DataType.Time), Display(Name = "Hora Final")]
        [Compare(nameof(HoraFinal), ErrorMessage ="A hora final deve ser maior ou igual a hora inicial")]
        public string HoraFinal { get; set; }
    }
}