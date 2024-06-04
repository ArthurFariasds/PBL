using LEMA.Models;
using LEMA.Services;
using PBL.DAO;
using PBL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LEMA.DAO
{
    public class TemperaturaDAO : PadraoDAO<TemperaturaViewModel>
    {
        public async void GetTemperatura(int IdDispositivo)
        {
            DateTime ultimaDataLeitura = this.Listagem().Last().DataLeitura;
            DispositivoDAO dispositivoDAO = new DispositivoDAO();

            var dispositivoApi = dispositivoDAO.Listagem().Where(x => x.Id == IdDispositivo).FirstOrDefault();

            int idDipositivoApi = 0;
            if (dispositivoApi != null)
                idDipositivoApi = Convert.ToInt32(dispositivoApi.IdDispositivoApi.Substring(4, 3));

            HttpClientTemperatura cliente = new HttpClientTemperatura();
            try
            {
                List<TemperaturaViewModel> retornoTemperatura = await cliente.GetTemperatura(idDipositivoApi, ultimaDataLeitura);

                foreach (TemperaturaViewModel temperatura in retornoTemperatura)
                {
                    temperatura.DataLeitura = temperatura.DataLeitura.AddHours(-4);
                    Insert(temperatura);
                }

            }
            catch (Exception ex)
            {
                
            }
        }

        public HistoricoViewModel BuscarHistorico(HistoricoViewModel filtro)
        {
            HistoricoViewModel retorno = new HistoricoViewModel();

            List<TemperaturaViewModel> listaTemperaturas = base.Listagem().Where(xs => xs.IdDispositivo == filtro.IdDispositivo).OrderBy(o => o.DataLeitura).ToList();

            if (filtro.DataInicio.HasValue)
                listaTemperaturas = listaTemperaturas.Where(xs => xs.DataLeitura >= filtro.DataInicio.Value).ToList();

            if (filtro.DataFim.HasValue)
                listaTemperaturas = listaTemperaturas.Where(xs => xs.DataLeitura <= filtro.DataFim.Value).ToList();

            if (filtro.TemperaturaInicial.HasValue)
                listaTemperaturas = listaTemperaturas.Where(xs => xs.ValorTemperatura >= filtro.TemperaturaInicial.Value).ToList();

            if (filtro.TemperaturaFinal.HasValue)
                listaTemperaturas = listaTemperaturas.Where(xs => xs.ValorTemperatura <= filtro.TemperaturaFinal.Value).ToList();

            retorno.MaioresTemperaturas = new List<TemperaturaViewModel>();
            retorno.MenoresTemperaturas = new List<TemperaturaViewModel>();
            retorno.MediasDasTemperaturas = new List<RetornoMediaTemperaturaViewModel>();

            retorno.MaioresTemperaturas = listaTemperaturas.GroupBy(g => g.DataLeitura.Date)
                                                           .Select(g => new TemperaturaViewModel
                                                           {
                                                               DataLeitura = g.Key,
                                                               ValorTemperatura = g.Max(t => t.ValorTemperatura)
                                                           })
                                                           .ToList();

            retorno.MenoresTemperaturas = listaTemperaturas.GroupBy(g => g.DataLeitura.Date)
                                                           .Select(g => new TemperaturaViewModel
                                                           {
                                                               DataLeitura = g.Key,
                                                               ValorTemperatura = g.Min(t => t.ValorTemperatura)
                                                           })
                                                           .ToList();

            retorno.MediasDasTemperaturas = listaTemperaturas.GroupBy(g => g.DataLeitura.Date)
                                                             .Select(g => new RetornoMediaTemperaturaViewModel
                                                             {
                                                                 DataLeitura = g.Key,
                                                                 MediaTemperatura = g.Average(t => t.ValorTemperatura),
                                                                 MenorTemperatura = g.Min(t => t.ValorTemperatura),
                                                                 MaiorTemperatura = g.Max(t => t.ValorTemperatura)
                                                             })
                                                             .ToList();

            return retorno;
        }

        protected override SqlParameter[] CriaParametros(TemperaturaViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("id", HelperDAO.NullAsDbNull(model.Id));
            parametros[1] = new SqlParameter("valorTemperatura", model.ValorTemperatura);
            parametros[2] = new SqlParameter("dataLeitura", model.DataLeitura);
            parametros[3] = new SqlParameter("idDispositivo", model.IdDispositivo);

            return parametros;
        }

        protected override TemperaturaViewModel MontaModel(DataRow registro)
        {
            var c = new TemperaturaViewModel();
            c.Id = Convert.ToInt32(registro["id"]);
            c.ValorTemperatura = Convert.ToDouble(registro["valorTemperatura"]);
            c.DataLeitura = Convert.ToDateTime(registro["dataLeitura"]);
            c.IdDispositivo = Convert.ToInt32(registro["idDispositivo"]);

            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Temperatura";
            NomeSpListagem = "spListagemTemperatura";
        }
    }
}
