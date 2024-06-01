using LEMA.Services;
using PBL.DAO;
using PBL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace LEMA.DAO
{
    public class DispositivoDAO : PadraoDAO<DispositivoViewModel>
    {
        public override void Insert(DispositivoViewModel model)
        {
            HttpClientDispositivo client = new HttpClientDispositivo();

            string idDispositivoApi = client.ListarDispositivo().devices.Last<RetornoDispositivoViewModel>().device_id;
            int idDispositivo = Convert.ToInt32(idDispositivoApi.Substring(4, 3)) + 1;

            client.SalvarDispositivoAsync(idDispositivo);
            client.RegistrarDispositivoAsync(idDispositivo);

            model.IdDispositivoApi = "temp" + (idDispositivo).ToString("D3");
            model.DataCriacao = DateTime.Now;

            base.Insert(model);
        }

        public override void Delete(int id)
        {
            HttpClientDispositivo client = new HttpClientDispositivo();

            string idDispositivoApi = this.Consulta(id).IdDispositivoApi;
            client.DeletarDispositivo(idDispositivoApi);

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            UsuarioViewModel usuarioDispositivo = usuarioDAO.Listagem().Where(x => x.IdDispositivo == id).FirstOrDefault();

            if(usuarioDispositivo != null)
            {
                usuarioDispositivo.IdDispositivo = 0;
                usuarioDAO.Update(usuarioDispositivo);
            }
              
            base.Delete(id);
        }

        protected override SqlParameter[] CriaParametros(DispositivoViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("id", model.Id);
            parametros[1] = new SqlParameter("nome", model.Nome);
            parametros[2] = new SqlParameter("descricao", model.Descricao);
            parametros[3] = new SqlParameter("idDispositivoApi", model.IdDispositivoApi);
            parametros[4] = new SqlParameter("dataCriacao", model.DataCriacao);

            return parametros;

        }

        protected override DispositivoViewModel MontaModel(DataRow registro)
        {
            var c = new DispositivoViewModel();
            c.Id = Convert.ToInt32(registro["id"]);
            c.Nome = registro["nome"].ToString();
            c.Descricao = registro["descricao"].ToString();
            c.IdDispositivoApi = registro["idDispositivoApi"].ToString();
            c.DataCriacao = Convert.ToDateTime(registro["dataCriacao"]);

            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Dispositivo";
            NomeSpListagem = "spListagemDispositivos";
        }

        public bool DispositivoExiste(string dispositivo)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("nome", dispositivo)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultarDispositivo", p);
            if (tabela.Rows.Count == 0)
                return false;

            return true;
        }

        public List<(string, int)> ListarDispositivosNaoAssociados(int id)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("id", id)
            };
            List<(string, int) > dispositivosNaoAssociados = new List<(string, int)>();

            var tabela = HelperDAO.ExecutaProcSelect("spListarDispositivosSemUsuario", p);

            foreach (DataRow registro in tabela.Rows)
            {
                string nomeDispositivo = registro["nome"].ToString();
                int idDispositivo = Convert.ToInt32(registro["id"]);
                dispositivosNaoAssociados.Add((nomeDispositivo, idDispositivo));
            }

            return dispositivosNaoAssociados;
        }

    }
}
