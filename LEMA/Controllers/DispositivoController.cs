using Microsoft.AspNetCore.Mvc;
using PBL.Models;

namespace PBL.Controllers
{
    public class DispositivoController : Controller /*PadraoController<DispositivoViewModel>*/
    {
        public IActionResult Index()
        {
            ViewBag.IdUsuario = HelperControllers.GetUsuarioId(HttpContext.Session);
            ViewBag.Logado = true;
            return View(); 
        }
    }
}
