using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ARM_comp.Interfaces;
using ARM_comp.Models.IntervaloConfianca;

namespace ARM_comp.Helpers.Singleton
{
    public class TabelaIntervaloConfianca : ITabelaIntervaloConfianca
    {
        private Dictionary<double, double> TabelaNormalData = new Dictionary<double, double>();
        
        private List<List<double>> TabelaTStundent { set; get; }
        
        private List<double> TabelaTSudentRow { set; get; }
        
        private List<double> TabelaTSudentCollum { set; get; }

        public TabelaIntervaloConfianca()
        {
            ComputaTabelaNormal();
            ComputaTabelaTStudent();
        }
        
        public double TabelaNormal(double porcentagem)
        {
            porcentagem /= 2;
            if (TabelaNormalData.ContainsKey(porcentagem))
                return TabelaNormalData[porcentagem];
            
            // Calculando o mais proximo
            var menorTstudent = new TNormal(TabelaNormalData.AsEnumerable().First(), porcentagem);

            foreach (var (key, value) in TabelaNormalData.AsEnumerable())
            {
                var testeMenor = Math.Abs(key - porcentagem);
                
                // Compliquei aqui....
                if (testeMenor < menorTstudent.Diferenca)
                {
                    menorTstudent.Diferenca = testeMenor;
                    menorTstudent.Key = key;
                    menorTstudent.Value = value;
                }
            }

            return menorTstudent.Value;
        }
        
        public double TabelaTStudent(double grauLiberdade, double porcentagem)
        {
            var menorGrau = Math.Abs(grauLiberdade - TabelaTSudentCollum[0]);
            var row = 0;
            for (var i = 0; i < TabelaTSudentCollum.Count - 1; i++)
            {
                var aux = Math.Abs(grauLiberdade - TabelaTSudentCollum[i]);
                if (aux < menorGrau)
                {
                    menorGrau = aux;
                    row = i;
                }
            }
            menorGrau = Math.Abs(grauLiberdade - TabelaTSudentRow[0]);
            var collum = 0;
            for (var i = 0; i < TabelaTSudentRow.Count - 1; i++)
            {
                var aux = Math.Abs(grauLiberdade - TabelaTSudentRow[i]);
                if (aux < menorGrau)
                {
                    menorGrau = aux;
                    collum = i;
                }
            }
            return TabelaTStundent[row][collum];
        }

        
        private void ComputaTabelaNormal()
        {
            var tabelaNormalData = new Dictionary<double, List<Tuple<double, double>>>();
            
            // Le os valores
            var matriz = AbreCsv("tabela_normal.csv");
            for (var i = 1; i < matriz.Count - 1; i++)
            {
                for (var j = 1; j < matriz[i].Count -1; j++)
                {
                    if (tabelaNormalData.ContainsKey(matriz[i][j]))
                    {
                        tabelaNormalData[matriz[i][j]].Add(new Tuple<double, double>(matriz[0][j], matriz[i][0]));
                    }
                    else
                    {
                        var lista = new List<Tuple<double, double>>();
                        lista.Add(new Tuple<double, double>(matriz[0][j], matriz[i][0]));
                        tabelaNormalData.Add(matriz[i][j], lista);
                    }
                }
            }
            
            foreach (var (key, value) in tabelaNormalData.AsEnumerable())
            {
                var media = value.Sum(e => e.Item1 + e.Item2) / value.Count;
                TabelaNormalData.Add(key, media);
            }
        }

        private void ComputaTabelaTStudent()
        {
            // Le os valores
            TabelaTStundent = AbreCsv("tabela_tstudent.csv");
            
            // Primeira Linha
            TabelaTSudentRow = TabelaTStundent[0];
            
            // Primeira coluna
            TabelaTSudentCollum = TabelaTStundent.Select(e => e[0]).ToList();
            TabelaTSudentCollum.RemoveAt(0);
            
            // Removendo primeira linha
            TabelaTStundent.RemoveAt(0);
            // Removendo primeiro item de cada lista
            
            // Removendo primeiro valro que era da coluna
            TabelaTStundent.ForEach(e => e.RemoveAt(0));
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