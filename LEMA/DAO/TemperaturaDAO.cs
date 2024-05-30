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
        public async void GetTemperatura()
        {
            DateTime ultimaDataLeitura = this.Listagem().Last().DataLeitura;

            HttpClientTemperatura cliente = new HttpClientTemperatura();

            List<TemperaturaViewModel> retornoTemperatura = await cliente.GetTemperatura("Temp:001", ultimaDataLeitura);

            foreach (TemperaturaViewModel temperatura in retornoTemperatura)
            {
                Insert(temperatura);
            }
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
