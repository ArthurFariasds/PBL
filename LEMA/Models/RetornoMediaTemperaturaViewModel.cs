using System;

namespace LEMA.Models
{
    public class RetornoMediaTemperaturaViewModel
    {
        public DateTime DataLeitura { get; set; }
        public double MaiorTemperatura { get; set; }
        public double MenorTemperatura { get; set; }
        public double MediaTemperatura { get; set; }
    }
}
