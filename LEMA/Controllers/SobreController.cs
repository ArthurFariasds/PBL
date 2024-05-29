using LEMA.DAO;
using Microsoft.AspNetCore.Mvc;
using PBL.DAO;
using PBL.Models;

namespace PBL.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Index()
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            EmpresaDAO empresaDao = new EmpresaDAO();

            UsuarioViewModel usuario = usuarioDao.Consulta(HelperControllers.GetUsuarioId(HttpContext.Session));
            EmpresaViewModel empresa = empresaDao.Consulta(usuario.IdEmpresa);

            ViewBag.Perfil = usuario.Perfil;
            ViewBag.Imagem64 = usuario.ImagemEmBase64;
            ViewBag.Logado = HelperControllers.VerificaUserLogado(HttpContext.Session);
            ViewBag.Username = HelperControllers.GetUsername(HttpContext.Session);
            ViewBag.IdUsuario = HelperControllers.GetUsuarioId(HttpContext.Session);

            if (empresa != null)
                ViewBag.NomeEmpresa = empresa.Nome;
            else
                ViewBag.NomeEmpresa = "";

            return View();
        }
    }
}
