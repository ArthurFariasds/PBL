using PBL.Models;

namespace PBL.Models
{
    public class LoginViewModel : PadraoViewModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
    }
}
