using System.ComponentModel.DataAnnotations;

namespace ARM_comp.Models.PontoZero
{
    public class ZeroFuncaoDto
    {
        public string funcao { set; get; }
        
        public double presicao { set; get; }
        public PontoCartesiano ponto { set; get; }
        
        public PontoCartesiano ponto2 { set; get; }
    }
}