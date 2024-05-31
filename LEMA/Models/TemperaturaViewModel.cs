using PBL.Models;
using System;

namespace LEMA.Models
{
    public class TemperaturaViewModel : PadraoViewModel
    {
        public DateTime DataLeitura { get; set; }
        public int IdDispositivo { get; set; }
        public double ValorTemperatura { get; set; }
    }
}
