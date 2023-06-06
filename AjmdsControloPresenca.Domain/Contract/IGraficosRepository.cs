using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface IGraficosRepository
    {
        List<string> Labels();
        List<int> ListarPresenca();
        List<int> ListarFalta();
    }
}
