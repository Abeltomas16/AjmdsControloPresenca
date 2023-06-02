namespace AjmdsControloPresenca.UI.Models.Afastamento
{
    public class AfastamentoIndexVM
    {
        public int Id { get; set; }
        public string Observacao { get; set; }
        public string DataAfastamento { get; set; }
        public string DataTermino { get; set; }
        public bool Apurado { get; set; }
        public bool Estado { get; set; }

        public string FuncionarioNome { get; set; }
        public short FuncionarioId { get; set; }
        public string Situacao { get; set; }
    }
}