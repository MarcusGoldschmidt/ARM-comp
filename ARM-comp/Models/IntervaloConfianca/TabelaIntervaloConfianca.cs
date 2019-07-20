using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ARM_comp.Models.Interfaces;

namespace ARM_comp.Models.IntervaloConfianca
{
    public class TabelaIntervaloConfianca : ITabelaIntervaloConfianca
    {
        private static TabelaIntervaloConfianca _tabelaIntervaloConfianca = new TabelaIntervaloConfianca();

        public static TabelaIntervaloConfianca GetInstance() => _tabelaIntervaloConfianca;

        public TabelaIntervaloConfianca()
        {
            ComputaTabelaNormal();
            ComputaTabelaTStudent();
        }

        private Dictionary<double, List<Tuple<double, double>>> TabelaNormalData =
            new Dictionary<double, List<Tuple<double, double>>>();

        public double TabelaNormal(double valor)
        {
            return 1;
        }

        public double TabelaTStudent(int grauLiberdade, double segundoValor)
        {
            throw new NotImplementedException();
        }

        private void ComputaTabelaNormal()
        {
            var matriz = AbreCsv("tabela_normal.csv");
            for (var i = 1; i < matriz.Count - 1; i++)
            {
                for (var j = 1; j < matriz[i].Count -1; j++)
                {
                    if (TabelaNormalData.ContainsKey(matriz[i][j]))
                    {
                        TabelaNormalData[matriz[i][j]].Add(new Tuple<double, double>(matriz[0][j], matriz[i][0]));
                    }
                    else
                    {
                        var lista = new List<Tuple<double, double>>();
                        lista.Add(new Tuple<double, double>(matriz[0][j], matriz[i][0]));
                        TabelaNormalData.Add(matriz[i][j], lista);
                    }
                }
            }
        }

        private void ComputaTabelaTStudent()
        {
        }

        private List<List<double>> AbreCsv(string fileName)
        {
            var path = Environment.CurrentDirectory;
            path += $"/Data/{fileName}";
            var valores = new List<List<double>>();
            using (var file = new StreamReader(path))
            {
                string line;
                // Tranforma o svg em matriz
                while ((line = file.ReadLine()) != null)
                    valores.Add(line.Split("|").Select(Convert.ToDouble).ToList());
            }

            return valores;
        }
    }
}