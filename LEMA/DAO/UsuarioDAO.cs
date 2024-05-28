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
            byte[] imgByte = model.ImagemEmByte;
            if (imgByte == null)
                imgByte = Array.Empty<byte>();

            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("id", model.Id);
            parametros[1] = new SqlParameter("username", model.Usuario);
            parametros[2] = new SqlParameter("senha", model.Senha);
            parametros[3] = new SqlParameter("perfil", model.Perfil);
            parametros[4] = new SqlParameter("imagem", imgByte);
            parametros[5] = new SqlParameter("idEmpresa", model.IdEmpresa);

            return parametros;

        }

        protected override UsuarioViewModel MontaModel(DataRow registro)
        {

            UsuarioViewModel c = new UsuarioViewModel();

            c.Id = Convert.ToInt32(registro["id"]);
            c.Usuario = registro["username"].ToString();
            c.Senha = registro["senha"].ToString();
            c.Perfil = registro["perfil"].ToString();
            if (registro["imagem"] != DBNull.Value)
                c.ImagemEmByte = registro["imagem"] as byte[];
            if (registro["idEmpresa"] != DBNull.Value)
                c.IdEmpresa = Convert.ToInt32(registro["idEmpresa"]);

            if (registro.Table.Columns.Contains("Empresa"))
                c.NomeEmpresa = Convert.ToString(registro["Empresa"]);


            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Usuario";
            NomeSpListagem = "spListagemUsuarios";
        }
    }
}
