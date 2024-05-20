using Microsoft.AspNetCore.Http;
using System;

namespace PBL.Models
{
    public class UsuarioViewModel : PadraoViewModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
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
