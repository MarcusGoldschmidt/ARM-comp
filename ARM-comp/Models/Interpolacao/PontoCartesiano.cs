namespace ARM_comp.Models.Interpolacao
{
    public class PontoCartesiano
    {
        public PontoCartesiano(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        
        public double x { get; set; }

        public double y { get; set; }
        
        public double xRad { get; set; }
    }
}