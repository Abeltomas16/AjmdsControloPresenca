using System.ComponentModel.DataAnnotations;

namespace AjmdsControloPresenca.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O limite do {0} é de {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O limite do {0} é de {1} caracteres")]
        public string Senha { get; set; }

        public string GoUrl { get; set; }
    }
}