using System.Collections.Generic;
using System.Linq;
using ARM_comp.Helpers;

namespace ARM_comp.Models.Interpolacao.Metodos
{
    public class FormaNewton
    {
        public FormaNewton(List<PontoCartesiano> data)
        {
            Pontos = data;
        }

        public FormaNewton(PontosDto data)
        {
            Pontos = data.Pontos;
        }

        public List<PontoCartesiano> Pontos { get; set; }

        public string Interpolacao()
        {
            var escalares = CalculaD();
            
            var polinomio = new Polinomial(escalares[0]);

            for (var i = 1; i < escalares.Count; i++)
            {
                var auxPoli = new Polinomial(-Pontos[0].x, 1);
                for (var j = 1; j < i; j++)
                {
                    auxPoli.Multiplicar(new []{-Pontos[j].x, 1});
                }
                auxPoli.Multiplicar(escalares[i]);
                polinomio.Somar(auxPoli);
            }

            return polinomio.ImprimirFormatado();
        }


        public List<double> CalculaD()
        {
            // Matriz quarda o valor dos D
            var Matriz = new List<List<double>>();
            
            Matriz.Add(Pontos.Select(e => e.y).ToList());

            // Auxiliar para elevar o x conforme avança
            // nas interações
            var nivel = 0;
            List<double> auxList;
            do
            {
                auxList = new List<double>();
                // Calcula nova lista
                for (var i = 0; i < Matriz.Last().Count - 1; i++)
                {
                    // Matriz é dos D
                    // Pontos sempre pega o x
                    var calculo = (Matriz.Last()[i + 1] - Matriz.Last()[i]) /
                                  (Pontos[nivel + 1 + i].x - Pontos[i].x);
                    auxList.Add(calculo);
                }

                nivel++;
                Matriz.Add(auxList);
            } while (auxList.Count > 0);

            // LINQ É genial...
            return Matriz.SkipLast(1).Select(e => e[0]).ToList();
        }
    }
}