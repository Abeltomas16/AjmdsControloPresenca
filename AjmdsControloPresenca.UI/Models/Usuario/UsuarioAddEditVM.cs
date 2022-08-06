using System.ComponentModel.DataAnnotations;

namespace AjmdsControloPresenca.UI.Models.Usuario
{
    public class UsuarioAddEditVM
    {
        [Required, Display(Name = "Funcionário")]
        public short FuncionarioId { get; set; }

        public string NomeFuncionario { get; set; }

        [Required, Display(Name = "Nome"), StringLength(50), MinLength(14)]
        public string Nome { get; set; }

        [Required, StringLength(8), MinLength(4)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required, StringLength(8), MinLength(4)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirmar senha")]
        public string ConfirmPassword { get; set; }
    }
}