using System.Collections.Generic;
using System.Linq;

namespace ARM_comp.Helpers
{
    public class Polinomial
    {
        
        public Polinomial()
        {
        }
        public Polinomial(double data)
        {
            Polinomio.Add(0, data);
        }
        
        public Polinomial(double grauZero, double grauUm)
        {
            Polinomio.Add(0, grauZero);
            Polinomio.Add(1, grauUm);
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
        
        // TODO: Fazer versão com sobrecarga de operadores
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
            var parans = new Polinomial(list.ToList());
            Multiplicar(parans);
        }
        
        public void Multiplicar(double parans)
        {
            var newPolinomio = new Dictionary<int, double>();
            foreach (var (key, value) in Polinomio)
                newPolinomio.Add(key, value * parans);
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

        public string ImprimirFormatado()
        {
            var retorno = "";
            var potencia = Polinomio.Keys.Reverse().ToList();
            var valor = Polinomio.Values.Reverse().ToList();

            for (var i = 0; i < valor.Count; i++)
            {
                if (i == valor.Count - 1)
                    retorno += $"({valor[i]}*x^{potencia[i]})";
                else
                    retorno += $"({valor[i]}*x^{potencia[i]}) + ";
            }
            
            return retorno;
        }
    }
}