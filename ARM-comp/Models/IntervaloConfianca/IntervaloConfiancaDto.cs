namespace ARM_comp.Models.IntervaloConfianca
{
    public class IntervaloConfiancaDto
    {
        public double IntervaloDeConfianca { get; set; }
        
        public double Media { get; set; }
        
        public double DesvioPadrao { get; set; }
        
        public int QuantidadeElementos { get; set; }
    }
}