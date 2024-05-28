using LEMA.Models;
using LEMA.Services;
using Microsoft.AspNetCore.Mvc;
using PBL.Controllers;
using PBL.Models;

namespace LEMA.Controllers
{
    public class DashboardController : PadraoController<PadraoViewModel>
    {
        public override IActionResult Index()
        {
            return View();
        }

        public JsonResult GetTemperatura()
        {
            HttpClientTemperatura client = new HttpClientTemperatura();
            RetornoTemperatura temperaturas = client.GetUltimaTemperatura();

            return Json(temperaturas);
        }
    }
}
