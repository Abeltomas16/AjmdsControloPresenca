using System.ComponentModel.DataAnnotations;

namespace AjmdsControloPresenca.UI.Models.Funcionario
{
    public class FuncionarioAddEditVM
    {
        [Required]
        public short Id { get; set; }
        [Required, StringLength(30)]
        public string Nome { get; set; }
        [Required, StringLength(30)]
        public string SobreNome { get; set; }
        [Required, Display(Name = "Bilhete"), MinLength(14), StringLength(15)]
        public string Bilhete { get; set; }
        public decimal SalarioLiquido { get; set; }
        [StringLength(200)]
        public string Observacao { get; set; }
        [Required, StringLength(9), MaxLength(9), Display(Name = "Contacto Principal")]
        public string ContactoPrincipal { get; set; }
        [Display(Name = "Contacto Auxiliar"), MaxLength(50)]
        public string ContactoAuxiliar { get; set; }
        public bool Estado { get; set; }
        [Required, Display(Name = "Genero")]
        public short GeneroId { get; set; }
        [Required, Display(Name = "Estado Civil")]
        public short EstadoCivilId { get; set; }
        [Required, Display(Name = "Departamento")]
        public short DepartamentoId { get; set; }
        [Required, Display(Name = "Cargo")]
        public short CargoId { get; set; }
    }
}