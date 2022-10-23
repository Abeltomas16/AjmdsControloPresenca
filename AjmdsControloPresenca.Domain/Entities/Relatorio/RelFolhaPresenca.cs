namespace AjmdsControloPresenca.Domain.Entities.Relatorio
{
    public class RelFolhaPresenca
    {
        public int Id { get; set; }
        public string Marcacoes { get; set; }
        public string DiaMes { get; set; }
        public string DataCompleta { get; set; }
        public string Semana { get; set; }
        public short FuncionarioId { get; set; }
        public int Dia { get; set; }
        public int HorasTrabalhadas { get; set; }
        public decimal Falta { get; set; }

    }
}
