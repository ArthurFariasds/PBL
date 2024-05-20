using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using PBL.Models;
using PBL.DAO;
using Microsoft.AspNetCore.Http;
using System.IO;

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
                ModelState.AddModelError("Usuario", "Usuario não preenchido!");

            if (model.Senha == null)
                ModelState.AddModelError("Senha", "Senha não preenchida!"); 

            if (model.Perfil == null)
                ModelState.AddModelError("Perfil", "Escolha o perfil para o usuário!");

            if (model.Usuario != null && usuarioDao.UsernameExiste(model.Usuario))
                ModelState.AddModelError("Usuario", "Nome de usuário já existente!");

            if (model.Senha?.Length < 4)
                ModelState.AddModelError("Senha", "Senha deve conter mais que 4 caracteres!");

            //if (model.Imagem == null && operacao == "I")
            //    ModelState.AddModelError("Imagem", "Escolha uma imagem.");

            if (model.Imagem != null && model.Imagem.Length / 1024 / 1024 >= 2)
                ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb!");

            if (ModelState.IsValid)
            {
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
            base.PreencheDadosParaView(Operacao, model);
            ViewBag.Perfil = model.Perfil;
            //if (Operacao == "I")
            //    model.DataNascimento = DateTime.Now;

            //PreparaListaCidadesParaCombo();
        }

        //private void PreparaListaCidadesParaCombo()
        //{
        //    CidadeDAO cidadeDao = new CidadeDAO();
        //    var cidades = cidadeDao.Listagem();
        //    List<SelectListItem> listaCidades = new List<SelectListItem>();
        //    listaCidades.Add(new SelectListItem("Selecione uma cidade...", "0"));
        //    foreach (var cidade in cidades)
        //    {
        //        SelectListItem item = new SelectListItem(cidade.Nome, cidade.Id.ToString());
        //        listaCidades.Add(item);
        //    }
        //    ViewBag.Cidades = listaCidades;
        //}

    }
}