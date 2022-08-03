using System;

namespace AjmdsControloPresenca.UI.Models
{
    public class FuncionarioViewModel
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public decimal SalarioLiquido { get; set; }
        public string Observacao { get; set; }
        public string ContactoPrincipa { get; set; }
        public string ContactoAuxiliar { get; set; }
        public bool Estado { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public string GeneroDescricao { get; set; }
        public string EstadoCivilDescricao { get; set; }
        public string DepartamentoDescricao { get; set; }
    }
}