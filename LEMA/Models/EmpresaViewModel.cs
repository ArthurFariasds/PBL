using Microsoft.AspNetCore.Http;
using PBL.Controllers;
using PBL.Models;
using System;

namespace PBL.Models
{
    public class EmpresaViewModel : PadraoViewModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public IFormFile? Imagem { get; set; }

        public byte[]? ImagemEmByte { get; set; }

        public string ImagemEmBase64
        {
            get
            {
                if (ImagemEmByte != null)
                    return Convert.ToBase64String(ImagemEmByte);
                else
                    return string.Empty;
            }
        }
    }
}
