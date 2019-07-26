using System;
using System.Collections.Generic;

namespace ARM_comp.Models.IntervaloConfianca
{
    public class TNormal
    {
        public double Value { get; set; }

        public double Key { get; set; }

        public double Diferenca { get; set; }

        public TNormal(KeyValuePair<double, double> data, double porcentagem)
        {
            Key = data.Key;
            Value = data.Value;
            Diferenca = Math.Abs(data.Key - porcentagem);
        }
    }
}