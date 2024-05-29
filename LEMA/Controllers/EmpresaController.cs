using LEMA.DAO;
using LEMA.Models;
using Microsoft.AspNetCore.Http;
using PBL.Controllers;
using PBL.DAO;
using PBL.Models;
using System.IO;

namespace LEMA.Controllers
{
    public class EmpresaController : PadraoController<EmpresaViewModel>
    {
        public EmpresaController()
        {
            DAO = new EmpresaDAO();
        }


        protected override void ValidaDados(EmpresaViewModel model, string operacao)
        {
            EmpresaDAO empresaDao = new EmpresaDAO();


            if (model.Nome == null)
                ModelState.AddModelError("Nome", "Empresa não preenchida!");

            if (model.Telefone == null)
                ModelState.AddModelError("Telefone", "Telefone não preenchido!");

            if (model.Telefone.Length < 14)
                ModelState.AddModelError("Telefone", "Número de telefone inválido!");

            if (model.Nome != null && empresaDao.EmpresaExiste(model.Nome) && operacao == "I")
                ModelState.AddModelError("Nome", "Nome da empresa já existente!");

            if (model.Imagem != null && model.Imagem.Length / 1024 / 1024 >= 2)
                ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb!");

            if (operacao == "A" && model.Imagem == null)
            {
                EmpresaViewModel cid = DAO.Consulta(model.Id);
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

        protected override void PreencheDadosParaView(string Operacao, EmpresaViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
        }

    }
}
