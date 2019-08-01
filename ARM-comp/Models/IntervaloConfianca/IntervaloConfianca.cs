using System;
using System.IO;
using ARM_comp.Interfaces;

namespace ARM_comp.Models.IntervaloConfianca
{
    public class IntervaloConfianca
    {
        public IntervaloConfianca(ITabelaIntervaloConfianca table, IntervaloConfiancaDto data)
        {
            if (data.IntervaloDeConfianca < 0 && data.IntervaloDeConfianca > 100)
                throw new InvalidDataException();
            if (data.Media == null || data.Media == 0)
                throw new InvalidDataException();
            if (data.DesvioPadrao == null)
                throw new InvalidDataException();
            if (data.QuantidadeElementos <= 0)
                throw new InvalidDataException();
            
            _tabelaIntervaloConfianca = table;
            
            Media = data.Media;
            DesvioPadrao = data.DesvioPadrao;
            QuantidadeElementos = data.QuantidadeElementos;
            IntervaloDeConfianca = data.IntervaloDeConfianca / 100;
            CasoDeSucesso = data.CasosDeSucesso;
        }

        public double Media { get; set; }
        
        public double DesvioPadrao { get; set; }
        
        public double QuantidadeElementos { get; set; }

        public double IntervaloDeConfianca { get; set; }
        
        public double CasoDeSucesso { get; set; }
        
        public object DesvioPadraoConhecido()
        {
            var intervalo = CalculaIntervaloTabelaNormal();
            return new
            {
                Formula = $"{Media} +- {intervalo}",
                Maior = Media + intervalo,
                Menor = Media - intervalo
            };
        }
        
        public object DesvioPadraoDesconhecido()
        {
            var intervalo = CalculaIntervaloTabelaTStudent();
            return new
            {
                Formula = $"{Media} +- {intervalo}",
                Maior = Media + intervalo,
                Menor = Media - intervalo
            };
        }

        private double CalculaIntervaloTabelaNormal()
        {
            return _tabelaIntervaloConfianca.TabelaNormal(IntervaloDeConfianca) *
                   (DesvioPadrao / Math.Sqrt(QuantidadeElementos));
        }
        
        private double CalculaIntervaloTabelaTStudent()
        {
            return _tabelaIntervaloConfianca.TabelaTStudent(QuantidadeElementos - 1, 100 - IntervaloDeConfianca) *
                   (DesvioPadrao / Math.Sqrt(QuantidadeElementos));
        }

        private readonly ITabelaIntervaloConfianca _tabelaIntervaloConfianca;
    }
}