using System.ComponentModel.DataAnnotations;

namespace AjmdsControloPresenca.UI.Models.Relatorio
{
    public class RelPresencaVM
    {      
        [Required, Display(Name = "Funcionário")]
        public short FuncionarioId { get; set; }

        [Required, DataType(DataType.Date), Display(Name ="De")]
        public string DataInicial { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Até")]
        public string DataFinal { get; set; }
    }
}