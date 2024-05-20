using System.Data;
using System;
using PBL.Models;
using System.Reflection;
using System.Data.SqlClient;

namespace PBL.DAO
{
    public class UsuarioDAO : PadraoDAO<UsuarioViewModel>
    {
        protected override SqlParameter[] CriaParametros(UsuarioViewModel model)
        {
            object imgByte = model.ImagemEmByte;
            if (imgByte == null)
                imgByte = DBNull.Value;

            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("id", model.Id);
            parametros[1] = new SqlParameter("username", model.Usuario);
            parametros[2] = new SqlParameter("senha", model.Senha);
            parametros[3] = new SqlParameter("perfil", model.Perfil);
            parametros[4] = new SqlParameter("imagem", imgByte);

            return parametros;

        }

        protected override UsuarioViewModel MontaModel(DataRow registro)
        {
            var c = new UsuarioViewModel();
            c.Id = Convert.ToInt32(registro["id"]);
            c.Usuario = registro["username"].ToString();
            c.Senha = registro["senha"].ToString();
            c.Perfil = registro["perfil"].ToString();
            if (registro["imagem"] != DBNull.Value)
                c.ImagemEmByte = registro["imagem"] as byte[];

            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Usuario";
            NomeSpListagem = "spListagemUsuarios";
        }
    }
}
