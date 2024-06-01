using LEMA.DAO;
using LEMA.Models;
using LEMA.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using PBL.Controllers;
using PBL.DAO;
using PBL.Models;

namespace LEMA.Controllers
{
    public class DashboardController : PadraoController<TemperaturaViewModel>
    {
        public DashboardController()
        {
            DAO = new TemperaturaDAO();
        }

        public override IActionResult Index()
        {
            return View();
        }

        public IActionResult DadosHistorico(HistoricoViewModel filtro)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            var idDispositivo = usuarioDao.Consulta(HelperControllers.GetUsuarioId(HttpContext.Session)).IdDispositivo;

            if (filtro == null)
                filtro = new HistoricoViewModel { IdDispositivo = idDispositivo };
            else
            {
                ValidaDados(filtro);

                if (!ModelState.IsValid)
                {
                    ViewBag.HistoricoViewModel = new TemperaturaDAO().BuscarHistorico(new HistoricoViewModel { IdDispositivo = idDispositivo });
                    filtro.MenoresTemperaturas = ViewBag.HistoricoViewModel.MenoresTemperaturas;
                    filtro.MaioresTemperaturas = ViewBag.HistoricoViewModel.MaioresTemperaturas;
                    filtro.MediasDasTemperaturas = ViewBag.HistoricoViewModel.MediasDasTemperaturas;
                    return View("Historico", filtro);
                }
            }

            filtro.IdDispositivo = idDispositivo;
            HistoricoViewModel historico = new TemperaturaDAO().BuscarHistorico(filtro);
            historico.DataInicio = filtro.DataInicio;
            historico.DataFim = filtro.DataFim;
            historico.TemperaturaInicial = filtro.TemperaturaInicial;
            historico.TemperaturaFinal = filtro.TemperaturaFinal;

            ViewBag.HistoricoViewModel = historico;
            return View("Historico", historico);
        }

        public IActionResult Historico()
        {
            TemperaturaDAO dao = new TemperaturaDAO();
            UsuarioDAO usuarioDao = new UsuarioDAO();
            dao.GetTemperatura();

            var idUsuario = HelperControllers.GetUsuarioId(HttpContext.Session);
            HistoricoViewModel historico = dao.BuscarHistorico(new HistoricoViewModel{ IdDispositivo = usuarioDao.Consulta(idUsuario).IdDispositivo });
            ViewBag.HistoricoViewModel = historico;
            return View(historico);
        }

        public JsonResult GetTemperatura()
        {
            HttpClientTemperatura client = new HttpClientTemperatura();
            RetornoTemperatura temperaturas = client.GetUltimaTemperatura();

            return Json(temperaturas);
        }

        //Achei melhor fazer por form action post
        //public JsonResult GetHistorico(HistoricoViewModel filtro)
        //{
        //    HistoricoViewModel historico = new TemperaturaDAO().BuscarHistorico(filtro);
        //    historico.DataInicio = filtro.DataInicio;
        //    historico.DataFim = filtro.DataFim;
        //    historico.TemperaturaInicial = filtro.TemperaturaInicial;
        //    historico.TemperaturaFinal = filtro.TemperaturaFinal;

        //    return Json(historico);
        //}

        protected void ValidaDados(HistoricoViewModel model)
        {
            if (model.DataInicio > model.DataFim)
                ModelState.AddModelError("DataInicio", "Maior que a data final.");

            if (model.TemperaturaInicial > model.TemperaturaFinal)
                ModelState.AddModelError("TemperaturaInicial", "Maior que a temperatura final.");
        }
    }
}
