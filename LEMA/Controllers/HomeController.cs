using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PBL.DAO;
using PBL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PBL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
