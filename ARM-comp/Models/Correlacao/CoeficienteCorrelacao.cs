using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ARM_comp.Models.Interpolacao;

namespace ARM_comp.Models.Correlacao
{
    public class CoeficienteCorrelacao
    {
        public CoeficienteCorrelacao(PontosDto data)
        {
            if (data == null || data.Pontos.Count == 0)
                throw new InvalidDataException();
            
            Pontos = data.Pontos;
            MediaX = data.Pontos.Sum(e => e.x) / data.Pontos.Count;
            MediaY = data.Pontos.Sum(e => e.x) / data.Pontos.Count;
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
            // Ordenando dados
            Pontos.Sort(delegate(PontoCartesiano obj1, PontoCartesiano obj2)
            {
                if (obj1.x == obj2.x)
                    return 0;
                if (obj1.x > obj2.x)
                    return 1;
                return -1;
            });
            for (var i = 0; i < Pontos.Count; i++)
                Pontos[i].postoX = i+1;
            
            Pontos.Sort(delegate(PontoCartesiano obj1, PontoCartesiano obj2)
            {
                if (obj1.y == obj2.y)
                    return 0;
                if (obj1.y > obj2.y)
                    return 1;
                return -1;
            });
            for (var i = 0; i < Pontos.Count; i++)
                Pontos[i].postoY = i+1;
            
            return 1 - 6 * Pontos.Sum(e => Math.Pow(e.postoX - e.postoY, 2)) / (Pontos.Count * (Math.Pow(Pontos.Count, 2) - 1));
        }
        
        public double CorrelacaoKendall()
        {
            var concordantes = 0;
            var discordantes = 0;

            for (var i = 0; i < Pontos.Count; i++)
            {
                for (var j = i + 1; j < Pontos.Count; j++)
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