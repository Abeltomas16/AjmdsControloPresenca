using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintServico.Data
{
    public class SqlServer
    {
        #region TesteDeConexão

        SqlConnection _cn;

        public string StringConexao()
        {
            return "Data Source=.;Password=049222Xp12;Persist Security Info=True;User ID=sa;Initial Catalog=AJMDSPresenca";
        }

        #endregion
        #region Good
        SqlConnection PegarConexao()
        {
            //string stringCon = ConfigurationManager.ConnectionStrings["SQLServerConnectionString"].ConnectionString;
            //String stringCon = "Password=049222Xp12;Persist Security Info=True;User ID=sa;Initial Catalog=ALAYSBDataBase;Data Source=AlekseiNoteBook";
            return new SqlConnection(StringConexao());
        }
        private readonly SqlParameterCollection _sqlParameterCollection = new SqlCommand().Parameters;
        public void LimparParametro()
        {
            _sqlParameterCollection.Clear();
        }
        public void AdicionarParametros(string nomeParametro, object valorParametro, SqlDbType SqlTipo = SqlDbType.NVarChar, string TypeName = null)
        {
            SqlParameter parameter = new SqlParameter(nomeParametro, valorParametro);
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = TypeName;
            _sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }
        public object ExecutarManipulacao(CommandType commandType, string nomeStoredProcedureOuTextSql)
        {
            SqlConnection sqlConnection = PegarConexao();
            try
            {
                sqlConnection.Open();
                using (SqlCommand sqlcommand = sqlConnection.CreateCommand())
                {
                    sqlcommand.CommandType = commandType;
                    sqlcommand.CommandText = nomeStoredProcedureOuTextSql;
                    sqlcommand.CommandTimeout = 7200;
                    foreach (SqlParameter sqlParameter in _sqlParameterCollection)
                    {
                        sqlcommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }
                    return sqlcommand.ExecuteScalar();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public DataTable ExecutarConsulta(CommandType commandType, String nomeStoredProcedureOuTextSql)
        {
            SqlConnection sqlConnection = PegarConexao();
            try
            {
                sqlConnection.Open();
                DataTable datatable = new DataTable();
                using (SqlCommand sqlcommand = sqlConnection.CreateCommand())
                {
                    sqlcommand.CommandType = commandType;
                    sqlcommand.CommandText = nomeStoredProcedureOuTextSql;
                    sqlcommand.CommandTimeout = 7200;
                    foreach (SqlParameter sqlParameter in _sqlParameterCollection)
                    {
                        sqlcommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                    }
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlcommand);
                    sqlDataAdapter.Fill(datatable);
                }
                return datatable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


        }
        public string Cadastrar(int FuncionarioId)
        {
            try
            {
                LimparParametro();
                AdicionarParametros("@FuncionarioId", FuncionarioId);
                return ExecutarManipulacao(CommandType.StoredProcedure, "uspFuncionarioPresencaCadastrar").ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
