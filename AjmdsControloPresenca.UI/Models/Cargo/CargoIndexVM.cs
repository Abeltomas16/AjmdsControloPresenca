using System.ComponentModel.DataAnnotations;

namespace AjmdsControloPresenca.UI.Models.Cargo
{
    public class CargoIndexVM
    {
        public short Id { get; set; }
        [Required]
        [Display(Name = "Nome"), StringLength(50)]
        public string Descricao { get; set; }
    }
}