using System;
using System.Collections.Generic;
using System.Linq;

namespace ARM_comp.Helpers
{
    public class Matriz
    {
        public List<List<double>> Data { get; set; }

        public Matriz(List<List<double>> data)
        {
            ValidaMatriz(data);
            Data = data;
        }

        public void Multiplica(double data)
        {
            Data = Data.Select(e => e.Select(d => d * data).ToList()).ToList();
        }

        private void ValidaMatriz(List<List<double>> data)
        {
            var colunas = data[0].Count;
            foreach (var row in data)
                if (row.Count != colunas)
                    throw new FormatException();
        }

        public int LinhasTamanho()
        {
            return Data.Count;
        }

        public int ColunasTamanho()
        {
            return Data[0].Count;
        }

        public List<List<double>> RetornaMatriz()
        {
            return Data;
        }

        public bool Equals(Matriz obj)
        {
            if (obj.LinhasTamanho() != LinhasTamanho() || obj.ColunasTamanho() != ColunasTamanho())
            {
                return false;
            }

            for (var i = 0; i < LinhasTamanho() - 1; i++)
            {
                for (var j = 0; j < ColunasTamanho() - 1; j++)
                {
                    if (obj.Data[i][j] != Data[i][j])
                        return false;
                }
            }

            return true;
        }
    }
}