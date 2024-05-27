using PBL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL.DAO
{
    public static class HelperDAO
    {

        public static object NullAsDbNull(object valor)
        {
            if (valor == null)
                return 0;
            else
                return valor;
        }
        public static void ExecutaSQL(string sql, SqlParameter[] parametros)

        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())

            {
                using (SqlCommand comando = new SqlCommand(sql, conexao))

                {
                    if (parametros != null
                   )
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();

                }
                conexao.Close();

            }

        }

        public static DataTable ExecutaSelect(string sql, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conexao))
                {
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    conexao.Close();
                    return tabela;
                }

            }

        }

        public static int ExecutaProc(string nomeSP, SqlParameter[] parametros, bool consultaUltimoIdentity = false)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(nomeSP, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                    if (consultaUltimoIdentity)
                    {
                        string sql = "select isnull(@@IDENTITY,0)";
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = sql;
                        int pedidoId = Convert.ToInt32(comando.ExecuteScalar());
                        conexao.Close();
                        return pedidoId;
                    }
                    else
                        return 0;
                }
            }
        }

        public static DataTable ExecutaProcSelect(string nomeSP, SqlParameter[] parametros)

        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(nomeSP, conexao))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    conexao.Close();
                    return tabela;
                }
            }
        }
    }
}