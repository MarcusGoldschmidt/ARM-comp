using System;
using System.Collections.Generic;
using ARM_comp.Helpers;

namespace ARM_comp.Models.Interpolacao.Metodos
{
    public class Linear
    {
        public Linear(PontosDto data)
        {
            if (data.Pontos.Count < 2)
                throw new Exception("Ao menos dois pontos são necessários");
            Pontos = data.Pontos;
        }

        private List<PontoCartesiano> Pontos { set; get; }

        public List<string> Interpolacao()
        {
            var response = new List<string>();

            for (var i = 1; i < Pontos.Count; i++)
            {
                var anterior = new Polinomial(Pontos[i].x, -1);
                anterior.Multiplicar(1 / (Pontos[i].x - Pontos[i - 1].x));
                anterior.Multiplicar(Pontos[i - 1].y);

                var proximo = new Polinomial(-Pontos[i - 1].x, 1);
                proximo.Multiplicar(1 / (Pontos[i].x - Pontos[i - 1].x));
                proximo.Multiplicar(Pontos[i].y);

                anterior.Somar(proximo);
                response.Add(anterior.ImprimirFormatado());
            }

            return response;
        }
    }
}