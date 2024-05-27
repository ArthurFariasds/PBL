using System;

namespace PBL.Models
{
    public class DispositivoViewModel : PadraoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string IdDispositivoApi { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
