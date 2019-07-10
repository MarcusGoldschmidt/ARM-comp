using System.ComponentModel.DataAnnotations;

namespace ARM_comp.Models.PontoZero
{
    public class ZeroFuncaoDto
    {
        public string Funcao { set; get; }

        public string DerivadaFuncao { set; get; }

        public double X { set; get; }
        
        public double X2 { set; get; }

        public double Precisao { set; get; }
        
        [Required]
        public Ponto Ponto { set; get; }
    }
}