using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ARM_comp.Models.Interpolacao;

namespace ARM_comp.Models.Correlacao
{
    public class CoeficienteCorrelacao
    {
        public CoeficienteCorrelacao(List<PontoCartesiano> data)
        {
            if (data == null || data.Count == 0)
                throw new InvalidDataException();
            
            Pontos = data;
            MediaX = data.Sum(e => e.x) / data.Count;
            MediaY = data.Sum(e => e.x) / data.Count;
        }

        public double CorrelacaoPerson()
        {
            return Pontos.Sum(e => (e.x - MediaX) * (e.y - MediaY)) / (
                    Math.Sqrt(Pontos.Sum(e => Math.Pow(e.x - MediaX, 2))) * 
                    Math.Sqrt(Pontos.Sum(e => Math.Pow(e.y - MediaY, 2)))
                );
        }
        
        public double CorrelacaoSperman()
        {
            return 1 - 6 * Pontos.Sum(e => Math.Pow(e.x - e.y,2)) / (Pontos.Count * (Math.Pow(Pontos.Count, 2) - 1));
        }
        
        public double CorrelacaoKendall()
        {
            var concordantes = 0;
            var discordantes = 0;

            for (var i = 0; i < Pontos.Count - 1; i++)
            {
                for (var j = i + 1; j < Pontos.Count - 1; j++)
                {
                    if (Pontos[i].x > Pontos[j].x && Pontos[i].y > Pontos[j].y)
                        concordantes++;
                    else
                        discordantes++;
                }
            }

            return (concordantes - discordantes) / (Pontos.Count * (Math.Pow(Pontos.Count, 2) - 1));
        }

        private List<PontoCartesiano> Pontos { get; set; }

        private double MediaX { get; set; }
        
        private double MediaY { get; set; }
    }
}