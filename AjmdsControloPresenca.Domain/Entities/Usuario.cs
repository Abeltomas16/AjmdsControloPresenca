namespace AjmdsControloPresenca.Domain.Entities
{
    public class Usuario
    {
        public short FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
