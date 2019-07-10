using System.Collections.Generic;

namespace ARM_comp.Helpers.NotEval
{
    public class Polinomial
    {
        public Polinomial()
        {
        }

        public Polinomial(List<double> data)
        {
            for (var i = 0; i < data.Count; i++)
                Polinomio.Add(i, data[i]);
        }

        public Dictionary<int, double> Polinomio = new Dictionary<int, double>();

        public void Multiplicar(Polinomial parans)
        {
            var newPolinomio = new Dictionary<int, double>();

            foreach (var data in Polinomio)
            {
                foreach (var paransData in parans.Polinomio)
                {
                    var potenciaFinal = data.Key + paransData.Key;
                    if (newPolinomio.ContainsKey(potenciaFinal))
                        newPolinomio[potenciaFinal] += data.Value * paransData.Value;
                    else
                    {
                        newPolinomio.Add(
                            data.Key + paransData.Key,
                            data.Value * paransData.Value
                        );
                    }
                }
            }

            Polinomio = newPolinomio;
        }
    }
}