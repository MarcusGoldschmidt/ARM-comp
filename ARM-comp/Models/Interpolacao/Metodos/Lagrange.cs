using System.Collections.Generic;
using System.Linq;
using ARM_comp.Helpers;

namespace ARM_comp.Models.Interpolacao.Metodos
{
    public class Lagrange
    {
        public Lagrange(List<PontoCartesiano> data)
        {
            Pontos = data;
        }
        
        public Lagrange(PontosDto data)
        {
            Pontos = data.Pontos;
        }

        private List<PontoCartesiano> Pontos { set; get; }

        // Nome das Variaveis peguei da wikipedia pra n me perder
        private int K { set; get; }

        public string Interpolacao()
        {
            // Quantida de pontos
            K = Pontos.Count - 1;
            var polinomial = new Polinomial();
            for (var i = 0; i < K; i++)
            {
                polinomial.Somar(ProdutorioL(i));
            }

            return polinomial.ImprimirFormatado();
        }

        private Polinomial ProdutorioL(int j)
        {
            Polinomial polinomial;

            // Caso especial para iniciação do polinomio
            // K == 1
            if (j != 0)
            {
                polinomial = new Polinomial(new[]
                {
                    Pontos[0].x * -1,
                    1
                });
                polinomial.Multiplicar(1 / (Pontos[j].x - Pontos[0].x));
            }
            else
            {
                // Quando é o primeiro
                // K = 1
                polinomial = new Polinomial(new[]
                {
                    Pontos[1].x * -1,
                    1
                });
                polinomial.Multiplicar(1 / (Pontos[j].x - Pontos[1].x));
            }

            for (var i = 1; i < K; i++)
            {
                if (i == j)
                    continue;

                polinomial.Multiplicar(new[]
                {
                    Pontos[i].x * -1,
                    1
                });
                polinomial.Multiplicar(1 / (Pontos[j].x - Pontos[i].x));
            }

            // Multiplicação de Y
            polinomial.Multiplicar(Pontos[j].y);

            return polinomial;
        }
    }
}