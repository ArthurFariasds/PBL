using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using PBL.Models;
using PBL.DAO;

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

            if (string.IsNullOrEmpty(model.Usuario))
                ModelState.AddModelError("Pefil", "Escolha o perfil para o usuário.");

            if (model.Usuario != null && usuarioDao.UsernameExiste(model.Usuario))
                ModelState.AddModelError("Usuario", "Nome de usuário já existente!");

            if (model.Senha?.Length < 4)
                ModelState.AddModelError("Senha", "Senha deve conter mais que 4 caracteres!");

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