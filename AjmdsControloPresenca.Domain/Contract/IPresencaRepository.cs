using AjmdsControloPresenca.Domain.Entities;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface IPresencaRepository : IRepositoryCrud<Presenca>
    {
        Presenca ListarPor(int Id);
    }
}

