using PBL.DAO;
using PBL.Models;
using System.Data;
using System;
using System.Net.Http;
using System.Data.SqlClient;

namespace LEMA.DAO
{
    public class DispositivoDAO : PadraoDAO<DispositivoViewModel>
    {
        protected override SqlParameter[] CriaParametros(DispositivoViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("id", model.Id);
            parametros[1] = new SqlParameter("nome", model.Nome);
            parametros[2] = new SqlParameter("descricao", model.Descricao);
            parametros[3] = new SqlParameter("dataCriacao", DateTime.Now);

            return parametros;

        }

        protected override DispositivoViewModel MontaModel(DataRow registro)
        {
            var c = new DispositivoViewModel();
            c.Id = Convert.ToInt32(registro["id"]);
            c.Nome = registro["nome"].ToString();
            c.Descricao = registro["descricao"].ToString();
            c.DataCriacao = Convert.ToDateTime(registro["dataCriacao"]);
            
            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Dispositivo";
            NomeSpListagem = "spListagemDispositivos";
        }
    }
}
