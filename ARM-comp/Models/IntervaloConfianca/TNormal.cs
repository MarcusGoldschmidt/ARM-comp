using System;
using System.Collections.Generic;

namespace ARM_comp.Models.IntervaloConfianca
{
    public class Tstudent
    {
        public double Value { get; set; }

        public double Key { get; set; }

        public double Diferenca { get; set; }

        public Tstudent(KeyValuePair<double, double> data, double porcentagem)
        {
            Key = data.Key;
            Value = data.Value;
            Diferenca = Math.Abs(data.Key - porcentagem);
        }
    }
}