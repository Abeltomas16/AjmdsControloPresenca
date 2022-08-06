using System.ComponentModel.DataAnnotations;

namespace AjmdsControloPresenca.UI.Models.Departamento
{
    public class DepartamentoAddEditVM
    {
        public short DepartamentoId { get; set; }
        [Required]
        [Display(Name ="Nome"),StringLength(100),MinLength(2)]
        public string Descricao { get; set; }
        public bool Estado { get; set; }
    }
}