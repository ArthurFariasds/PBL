using LEMA.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBL.DAO;
using PBL.Models;

namespace PBL.Controllers
{
    public class DispositivoController : PadraoController<DispositivoViewModel>
    {
        public DispositivoController()
        {
            DAO = new DispositivoDAO();
        }

        protected override void ValidaDados(DispositivoViewModel model, string operacao)
        {
            if (model.Nome == null)
                ModelState.AddModelError("Usuario", "Usuário não preenchido!");

            if (model.Descricao == null)
                ModelState.AddModelError("Senha", "Senha não preenchida!");
        }

        protected override void PreencheDadosParaView(string Operacao, DispositivoViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
        }
    }
}
