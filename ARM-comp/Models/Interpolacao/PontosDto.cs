using System.Collections.Generic;
using System.Linq;

namespace ARM_comp.Models.Interpolacao
{
    public class PontosDto
    {
        public PontosDto(List<double[]> data)
        {
            data.ToList().ForEach(e =>
            {
                Pontos.Add(new PontoCartesiano(e[0], e[1]));
            });
        }

        public List<PontoCartesiano> Pontos { get; set; }
    }
}