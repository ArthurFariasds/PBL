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
            DispositivoDAO dispositivoDao = new DispositivoDAO();

            if (string.IsNullOrEmpty(model.Nome))
                ModelState.AddModelError("Nome", "Dispositivo não preenchido!");

            if (model.Nome != null && dispositivoDao.DispositivoExiste(model.Nome) && operacao == "I")
                ModelState.AddModelError("Nome", "Nome de dispositivo já existente!");
        }

        protected override void PreencheDadosParaView(string Operacao, DispositivoViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
        }
    }
}
