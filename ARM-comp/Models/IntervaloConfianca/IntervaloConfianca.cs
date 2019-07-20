using System.IO;
using ARM_comp.Models.Interfaces;

namespace ARM_comp.Models.IntervaloConfianca
{
    public class IntervaloConfianca
    {
        public IntervaloConfianca(ITabelaIntervaloConfianca table)
        {
            _tabelaIntervaloConfianca = table;
        }

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
            _tabelaIntervaloConfianca.TabelaNormal(1);
        }

        private readonly ITabelaIntervaloConfianca _tabelaIntervaloConfianca;
    }
}