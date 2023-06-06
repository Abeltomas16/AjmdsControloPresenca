using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Domain.Entities.Relatorio;
using AjmdsControloPresenca.Infra.Entity.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjmdsControloPresenca.Infra.Repository
{
    public class RelatorioRepositorioEF : IRelatorioRepository
    {
        protected EntityDatabaseContext Context = new EntityDatabaseContext();

        private void SaveContext() => Context.SaveChanges();

        public void Dispose() => Context.Dispose();

        public IEnumerable<RelFolhaPresenca> Listar(short id, DateTime DataIn, DateTime DataFim)
        {
            var PDataIn = new SqlParameter("@DataIn", DataIn);
            var PDataFin = new SqlParameter("@Datafin", DataFim);
            var PFuncionarioId = new SqlParameter("@Funcionario", id);

            var lista = Context.Database.SqlQuery<RelFolhaPresenca>("uspFolhaPesenca @DataIn,@Datafin,@Funcionario",
                                                                     PDataIn, PDataFin, PFuncionarioId).ToList();
            return lista;
        }
        public IEnumerable<Presencas> ListarHoje()
        {
            var lista = Context.Database.SqlQuery<Presencas>("SELECT F.Nome, CASE WHEN P.Entrada IS NULL THEN 'Atraso' ELSE FORMAT(p.Entrada,'HH:mm:ss','pt-Pt') END Entrada, '''' as Cor FROM Presenca P JOIN Funcionario f ON P.FuncionarioId = f.Id WHERE CAST(P.Cadastro AS DATE)=CAST(GETDATE() AS DATE) ORDER BY f.Nome").ToList();
            return lista;
        }
    }
}
