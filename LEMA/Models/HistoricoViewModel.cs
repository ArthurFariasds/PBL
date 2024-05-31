using System.Collections.Generic;
using System;
using LEMA.Models;

namespace PBL.Models
{
    public class HistoricoViewModel
    {
        public double? TemperaturaInicial { get; set; }
        public double? TemperaturaFinal { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public List<TemperaturaViewModel> Temperaturas { get; set; }
        public List<TemperaturaViewModel> MaioresTemperaturas { get; set; }
        public List<TemperaturaViewModel> MenoresTemperaturas { get; set; }
        public List<RetornoMediaTemperaturaViewModel> MediasDasTemperaturas { get; set; }
    }
}
