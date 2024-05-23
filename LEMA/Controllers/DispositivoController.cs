using Microsoft.AspNetCore.Mvc;
using PBL.DAO;
using PBL.Models;

namespace PBL.Controllers
{
    public class DispositivoController : Controller /*PadraoController<DispositivoViewModel>*/
    {
        public IActionResult Index()
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();

            UsuarioViewModel usuario = usuarioDao.Consulta(HelperControllers.GetUsuarioId(HttpContext.Session));
            ViewBag.Perfil = usuario.Perfil;
            ViewBag.Imagem64 = usuario.ImagemEmBase64;
            ViewBag.Logado = HelperControllers.VerificaUserLogado(HttpContext.Session);
            ViewBag.Username = HelperControllers.GetUsername(HttpContext.Session);
            ViewBag.IdUsuario = HelperControllers.GetUsuarioId(HttpContext.Session);

            return View(); 
        }
    }
}
