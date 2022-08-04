using System;

namespace AjmdsControloPresenca.UI.Models.Funcionario
{
    public class FuncionarioAddEditVM
    {
        public FuncionarioAddEditVM()
        {
            DataCadastro=DateTime.Now;
        }
        public short Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public decimal SalarioLiquido { get; set; }
        public string Observacao { get; set; }
        public string ContactoPrincipa { get; set; }
        public string ContactoAuxiliar { get; set; }
        public bool Estado { get; set; }
        public DateTime DataCadastro { get; set; }
        public short GeneroId { get; set; }
        public short EstadoCivilId { get; set; }
        public short DepartamentoId { get; set; }
        public short CargoId { get; set; }
    }
}