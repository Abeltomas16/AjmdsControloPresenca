using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Infra.Entity.Data;
using System.Collections.Generic;
using System.Linq;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class GraficosRepositoryEF : IGraficosRepository
    {
        protected EntityDatabaseContext Context = new EntityDatabaseContext();

        public List<string> Labels()
        {
            var result = Context.Database.SqlQuery<string>("" +
                  "SELECT DATENAME(Month,max(p.Cadastro)) AS Mes  " +
                  "FROM Presenca p\r\n" +
                  "WHERE (p.Entrada IS NOT NULL or p.Saida IS NOT NULL)\r\n" +
                  "AND DATEPART(YEAR,p.Cadastro)=YEAR(GETDATE())\r\n" +
                  "GROUP BY DATEPART(MONTH,p.Cadastro)").ToList();

            return result;
        }

        public List<int> ListarFalta()
        {
            var result = Context.Database.SqlQuery<int>("" +
                "SELECT count(*) Total FROM Presenca p WHERE (p.Entrada IS  NULL or p.Saida IS  NULL) AND DATEPART(YEAR,p.Cadastro)=YEAR(GETDATE()) GROUP BY DATEPART(MONTH,p.Cadastro)").ToList();

            return result;
        }

        public List<int> ListarPresenca()
        {
            var result = Context.Database.SqlQuery<int>("" +
                "SELECT count(*) Total FROM Presenca p WHERE (p.Entrada IS NOT NULL or p.Saida IS NOT NULL) AND DATEPART(YEAR,p.Cadastro)=YEAR(GETDATE())" +
                "GROUP BY DATEPART(MONTH,p.Cadastro)").ToList();

            return result;
        }
    }
}
