using Microsoft.AspNetCore.Http;
using System;

namespace PBL.Models
{
    public class UsuarioViewModel : PadraoViewModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
    }
}
