using System;
using System.Collections.Generic;
using System.Linq;

namespace ARM_comp.Models.Interpolacao.Metodos
{
    public class Trignometrica
    {
        public Trignometrica(PontosDto data)
        {
            Pontos = TransformaEmRadianos(data.Pontos);
        }

        private List<PontoCartesiano> Pontos { set; get; }

        public string Interpolacao()
        {
            var aux = "";
            var m = Pontos.Count % 2 == 0 ? Pontos.Count / 2 : (Pontos.Count - 1) / 2;

            aux +=  $"{CalculaA(0)/2} + ";
            
            for (var i = 1; i < m; i++)
            {
                if (i == m - 1)
                    aux += $"({CalculaA(i)} * cos({i} * x)) + ({CalculaB(i)} * sen({i} * x))";
                else
                    aux += $"({CalculaA(i)} * cos({i} * x)) + ({CalculaB(i)} * sen({i} * x)) + ";
            }

            if (Pontos.Count % 2 == 0)
                aux += $" + ({CalculaA(m)/2} * cos({m}x))";
            return aux;
        }

        private List<PontoCartesiano> TransformaEmRadianos(List<PontoCartesiano> data)
        {
            foreach (var value in data)
                value.xRad = value.x * 2 * Math.PI / data.Count;
            return data;
        }

        private double CalculaA(int j)
        {
            return (double) 2 / Pontos.Count * Pontos.Sum(t => t.y * Math.Cos(j * t.xRad));
        }

        private double CalculaB(int j)
        {
            return (double) 2 / Pontos.Count * Pontos.Sum(t => t.y * Math.Sin(j * t.xRad));
        }
    }
}