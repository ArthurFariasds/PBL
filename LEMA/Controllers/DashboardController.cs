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
            return Json("");
        }
    }
}
