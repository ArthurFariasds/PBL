using PBL.Models;
using System.Data;
using System;
using System.Data.SqlClient;
using LEMA.Models;
using PBL.DAO;

namespace LEMA.DAO
{
    public class EmpresaDAO : PadraoDAO<EmpresaViewModel>
    {
        protected override SqlParameter[] CriaParametros(EmpresaViewModel model)
        {
            byte[] imgByte = model.ImagemEmByte;
            if (imgByte == null)
                imgByte = Array.Empty<byte>();

            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("id", model.Id);
            parametros[1] = new SqlParameter("nome", model.Nome);
            parametros[2] = new SqlParameter("telefone", model.Telefone);
            parametros[3] = new SqlParameter("imagem", imgByte);

            return parametros;

        }

        protected override EmpresaViewModel MontaModel(DataRow registro)
        {
            var c = new EmpresaViewModel();
            c.Id = Convert.ToInt32(registro["id"]);
            c.Nome = registro["nome"].ToString();
            c.Telefone = registro["telefone"].ToString();
            if (registro["imagem"] != DBNull.Value)
                c.ImagemEmByte = registro["imagem"] as byte[];

            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Empresa";
            NomeSpListagem = "spListagemEmpresas";
        }


        public bool EmpresaExiste(string empresa)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("nome", empresa)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultarEmpresa", p);
            if (tabela.Rows.Count == 0)
                return false;

            return true;
        }
    }
}
