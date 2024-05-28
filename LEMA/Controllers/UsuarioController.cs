using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using PBL.Models;
using PBL.DAO;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http;
using LEMA.DAO;

namespace PBL.Controllers
{
    public class UsuarioController : PadraoController<UsuarioViewModel>
    {
        public UsuarioController()
        {
            DAO = new UsuarioDAO();
        }


        protected override void ValidaDados(UsuarioViewModel model, string operacao)
        {
            LoginDAO usuarioDao = new LoginDAO();

            if (model.Usuario == null)
                ModelState.AddModelError("Usuario", "Usuário não preenchido!");

            if (model.Senha == null)
                ModelState.AddModelError("Senha", "Senha não preenchida!");

            if (model.Perfil == null)
                ModelState.AddModelError("Perfil", "Escolha o perfil para o usuário!");

            if (model.Usuario != null && usuarioDao.UsernameExiste(model.Usuario) && operacao == "I")
                ModelState.AddModelError("Usuario", "Nome do usuário já existente!");

            if (model.Senha?.Length < 4)
                ModelState.AddModelError("Senha", "Senha deve conter mais do que 4 caracteres!");

            if (model.Imagem != null && model.Imagem.Length / 1024 / 1024 >= 2)
                ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb!");

            if (operacao == "A" && model.Imagem == null)
            {
                UsuarioViewModel cid = DAO.Consulta(model.Id);
                model.ImagemEmByte = cid.ImagemEmByte;
            }
            else
            {
                model.ImagemEmByte = ConvertImageToByte(model.Imagem);
            }
        }

        public byte[] ConvertImageToByte(IFormFile file)
        {
            if (file != null)
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            else
                return null;
        }

        protected override void PreencheDadosParaView(string Operacao, UsuarioViewModel model)
        {
            PreparaListaEmpresasParaCombo();

            base.PreencheDadosParaView(Operacao, model);

            if(!string.IsNullOrEmpty(model.Perfil) && model.Id == HelperControllers.GetUsuarioId(HttpContext.Session))
                HttpContext.Session.SetString("Perfil", model.Perfil);

            if (!string.IsNullOrEmpty(model.ImagemEmBase64) && model.Id == HelperControllers.GetUsuarioId(HttpContext.Session))
                HttpContext.Session.SetString("Imagem64", model.ImagemEmBase64);
        }

        private void PreparaListaEmpresasParaCombo()
        {
            EmpresaDAO dao = new EmpresaDAO();
            var empresas = dao.Listagem();
            List<SelectListItem> listaEmpresas = new List<SelectListItem>();
            listaEmpresas.Add(new SelectListItem("Selecione uma empresa...", "0"));
            foreach (var empresa in empresas)
            {
                SelectListItem item = new SelectListItem(empresa.Nome, empresa.Id.ToString());
                listaEmpresas.Add(item);
            }
            ViewBag.Empresa = listaEmpresas;
        }

    }
}