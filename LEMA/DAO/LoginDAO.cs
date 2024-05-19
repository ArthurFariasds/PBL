using PBL.DAO;
using PBL.Models;
using System.Data.SqlClient;
using System.Data;
using System;

namespace PBL.DAO
{
    public class LoginDAO : PadraoDAO<LoginViewModel>
    {
        public LoginViewModel ValidaLogin(LoginViewModel model)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("username", model.Usuario),
                 new SqlParameter("senha", model.Senha)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spValidarUsuario", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }

        public bool UsernameExiste(string username)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("username", username)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultarUsuario", p);
            if (tabela.Rows.Count == 0)
                return false;

            return true;
        }

        protected override SqlParameter[] CriaParametros(LoginViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("id", HelperDAO.NullAsDbNull(model.Id));
            parametros[1] = new SqlParameter("username", model.Usuario);
            parametros[2] = new SqlParameter("senha", model.Senha);
            parametros[3] = new SqlParameter("perfil", "Padrão");

            return parametros;
        }

        protected override LoginViewModel MontaModel(DataRow registro)
        {
            var c = new LoginViewModel();
            c.Id = Convert.ToInt32(registro["id"]);
            c.Usuario = registro["username"].ToString();
            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Usuario";
        }
    }
}
