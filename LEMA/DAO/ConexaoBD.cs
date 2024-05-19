using System.Data.SqlClient;

namespace PBL.DAO
{
    public static class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
            //string strCon = "Server=DESKTOP-DPOI5PT; Database=PBL;Trusted_Connection=True";
            //string strCon = "Server=LEVI; Database=PBL;Trusted_Connection=True";
            string strCon = "Server=DESKTOP-1FOS03S\\SQLEXPRESS; Database=PBL;Trusted_Connection=True";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
