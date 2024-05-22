using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBL.DAO;
using PBL.Models;
using System;

namespace PBL.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            ViewBag.Logado = false;
            ViewBag.Login = true;
            return View(new LoginViewModel());
        }

        public IActionResult Register()
        {
            ViewBag.Logado = false;
            ViewBag.Login = false;
            return View(new LoginViewModel());
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult LogoutModal()
        {
            return PartialView("_Logout");
        }

        public IActionResult ValidaLogin(LoginViewModel login)
        {
            try
            {
                ViewBag.Logado = false;
                ViewBag.Login = true;
                ValidaDados(login);

                if (!ModelState.IsValid) 
                    return View("Login", login);

                UsuarioDAO dao = new UsuarioDAO();
                UsuarioViewModel usuario = dao.Consulta(HelperControllers.GetUsuarioId(HttpContext.Session));

                ViewBag.IdUsuario = HelperControllers.GetUsuarioId(HttpContext.Session);
                ViewBag.Imagem64 = usuario.ImagemEmBase64;
                HttpContext.Session.SetString("Perfil", usuario.Perfil);
                HttpContext.Session.SetString("Imagem64", usuario.ImagemEmBase64);
                HttpContext.Session.SetString("Logado", "true");
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public IActionResult Salvar(LoginViewModel login)
        {
            try
            {
                ViewBag.Logado = false;
                ViewBag.Login = false;
                ValidaDados(login);

                if (!ModelState.IsValid)
                    return View("Register", login);

                LoginDAO usuarioDao = new LoginDAO();
                usuarioDao.Insert(login);

                return RedirectToAction("Login", "Login");
            }
            catch
            {
                return View("Error", new ErrorViewModel());
            }
        }

        private void ValidaDados(LoginViewModel login)
        {
            ModelState.Clear();

            LoginDAO usuarioDao = new LoginDAO();

            if (login.Usuario == null)
                ModelState.AddModelError("Usuario", "Usuário não preenchido!");

            if (login.Senha == null)
                ModelState.AddModelError("Senha", "Senha não preenchida!");

            if (ViewBag.Login && ModelState.IsValid)
            {
                LoginViewModel usuario = usuarioDao.ValidaLogin(login);

                if (usuario == null)
                    ModelState.AddModelError("Senha", "Usuário ou senha inválidos.");
                else
                {
                    HttpContext.Session.SetString("id", usuario.Id.ToString());
                    HttpContext.Session.SetString("Username", usuario.Usuario);
                }

                return;
            }

            if (!ViewBag.Login)
            {
                if (login.Usuario != null && usuarioDao.UsernameExiste(login.Usuario))
                    ModelState.AddModelError("Usuario", "Nome de usuário já existente!");

                if (login.Senha?.Length < 4)
                    ModelState.AddModelError("Senha", "Senha deve conter mais que 4 caracteres!");

                if (login.Senha != null && (login.Senha != login.ConfirmarSenha || login.ConfirmarSenha == null))
                    ModelState.AddModelError("ConfirmarSenha", "Senhas não correspondem!");
            }
        }
    }
}
