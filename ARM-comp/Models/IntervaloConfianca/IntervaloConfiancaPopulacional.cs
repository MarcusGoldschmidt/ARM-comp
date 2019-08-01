using System;
using System.IO;
using ARM_comp.Helpers.Singleton;
using ARM_comp.Interfaces;

namespace ARM_comp.Models.IntervaloConfianca
{
    public class IntervaloConfiancaPopulacional
    {
        public IntervaloConfiancaPopulacional(ITabelaIntervaloConfianca tabelaIntervaloConfianca,
            IntervaloConfiancaDto data)
        {
            if (data.IntervaloDeConfianca < 0 && data.IntervaloDeConfianca > 100)
                throw new InvalidDataException();
            if (data.DesvioPadrao < 0 || data.DesvioPadrao == null)
                throw new InvalidDataException();
            if (data.DesvioPadrao == null)
                throw new InvalidDataException();
            if (data.QuantidadeElementos <= 0)
                throw new InvalidDataException();

            _tabelaIntervaloConfianca = tabelaIntervaloConfianca;
            DesvioPadrao = data.DesvioPadrao;
            QuantidadeElementos = data.QuantidadeElementos;
            IntervaloDeConfianca = data.IntervaloDeConfianca;
            CasoDeSucesso = data.CasosDeSucesso;
        }

        public double DesvioPadrao { get; set; }

        public double QuantidadeElementos { get; set; }

        public double IntervaloDeConfianca { get; set; }

        public double CasoDeSucesso { get; set; }

        public object ProporcaoPopulacional()
        {
            var P = CasoDeSucesso / QuantidadeElementos;

            var intervalo = _tabelaIntervaloConfianca.TabelaNormal(IntervaloDeConfianca) *
                            Math.Sqrt((P * (1 - P) / QuantidadeElementos));
            return new
            {
                Formula = $"{P} +- {intervalo}",
                Maior = P + intervalo,
                Menor = P - intervalo
            };
        }

        private readonly ITabelaIntervaloConfianca _tabelaIntervaloConfianca;
    }
}