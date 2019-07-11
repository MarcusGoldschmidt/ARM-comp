using System.Collections.Generic;
using System.Linq;

namespace ARM_comp.Helpers
{
    public class Polinomial
    {
        public Polinomial()
        {
        }
        
        public Polinomial(double[] data)
        {
            for (var i = 0; i < data.Length; i++)
                Polinomio.Add(i, data[i]);
        }

        public Polinomial(IReadOnlyList<double> data)
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
                        newPolinomio.Add(
                            data.Key + paransData.Key,
                            data.Value * paransData.Value
                        );
                }
            }
            Polinomio = newPolinomio;
        }
        
        public void Multiplicar(double[] list)
        {
            // FIXME Podia fazer melhor mas fiquei com preguiça
            var parans = new Polinomial(list.ToList());
            
            var newPolinomio = new Dictionary<int, double>();

            foreach (var data in Polinomio)
            {
                foreach (var paransData in parans.Polinomio)
                {
                    var potenciaFinal = data.Key + paransData.Key;
                    if (newPolinomio.ContainsKey(potenciaFinal))
                        newPolinomio[potenciaFinal] += data.Value * paransData.Value;
                    else
                        newPolinomio.Add(
                            data.Key + paransData.Key,
                            data.Value * paransData.Value
                        );
                }
            }
            Polinomio = newPolinomio;
        }
        
        public void Multiplicar(double parans)
        {
            var newPolinomio = new Dictionary<int, double>();
            foreach (var (key, value) in Polinomio)
            {
                newPolinomio.Add(key, value * parans);
            }
            Polinomio = newPolinomio;
        }

        public void Somar(Polinomial parans)
        {
            foreach (var (key, value) in parans.Polinomio)
            {
                if (Polinomio.ContainsKey(key))
                    Polinomio[key] += value;    
                else
                    Polinomio.Add(key, value);
            }
        }
    }
}