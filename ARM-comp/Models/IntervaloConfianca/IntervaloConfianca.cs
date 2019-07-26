using System;
using System.Collections.Generic;
using System.IO;
using ARM_comp.Models.Interfaces;

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
        }

        public double Media { get; set; }
        
        public double DesvioPadrao { get; set; }
        
        public double QuantidadeElementos { get; set; }

        public double IntervaloDeConfianca { get; set; }

        public object DesvioPadraoConhecido(double media, double desvioPadrao, int quantidadeElementos,
            double porcentagem)
        {
            var intervalo = CalculaIntervaloTabelaNormal(desvioPadrao, quantidadeElementos, porcentagem);
            return new
            {
                Formula = $"{media} +- {intervalo}",
                Maior = media + intervalo,
                Menor = media - intervalo
            };
        }
        
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

        public double CalculaIntervaloTabelaNormal(double desvioPadrao,int quantidadeElementos, double porcentagem)
        {
            return _tabelaIntervaloConfianca.TabelaNormal(porcentagem) *
                   (desvioPadrao / Math.Sqrt(quantidadeElementos));
        }
        
        public double CalculaIntervaloTabelaNormal()
        {
            return _tabelaIntervaloConfianca.TabelaNormal(IntervaloDeConfianca) *
                   (DesvioPadrao / Math.Sqrt(QuantidadeElementos));
        }

        private readonly ITabelaIntervaloConfianca _tabelaIntervaloConfianca;
    }
}