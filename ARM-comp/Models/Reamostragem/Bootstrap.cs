using System;
using System.Collections.Generic;
using System.Linq;

namespace ARM_comp.Models.Reamostragem
{
    public class Bootstrap
    {
        public List<double> Amostras { get; set; }

        public int TamanhoNovaAmostra { get; set; }

        public Bootstrap(List<double> amostras, int tamanhoNovaAmostra)
        {
            Amostras = amostras;
            TamanhoNovaAmostra = tamanhoNovaAmostra;
        }
    }
}