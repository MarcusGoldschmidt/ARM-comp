using System.Collections.Generic;
using System.Linq;

namespace ARM_comp.Models.Interpolacao.Metodos
{
    public class FormaNewton
    {
        public FormaNewton(PontosDto data)
        {
            Pontos = data.Pontos;
        }

        public FormaNewton()
        {
        }

        public List<PontoCartesiano> Pontos { get; set; }

        public string Interpolacao()
        {
            return "Method not implementado";
        }

        public List<double> CalculaD(List<PontoCartesiano> data)
        {
            var Matriz = new List<List<double>>();

            Matriz.Add(Pontos.Select(x => x.y).ToList());

            var nivel = 0;

            List<double> auxList;
            do
            {
                auxList = new List<double>();
                // Calcula nova lista
                for (var i = 0; i < Matriz.Last().Count - 1; i++)
                {
                    auxList.Add((Matriz.Last()[i + 1] - Matriz.Last()[i]) / (
                                    Pontos[nivel + 1 + i].x - Pontos[nivel + i].x));
                }

                nivel++;
                Matriz.Add(auxList);
            } while (auxList.Count > 0);

            return Matriz.Select(e => e[0]).ToList();
        }
    }
}