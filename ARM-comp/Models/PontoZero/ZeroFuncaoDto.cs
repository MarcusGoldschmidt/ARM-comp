using System.ComponentModel.DataAnnotations;

namespace ARM_comp.Models.PontoZero
{
    public class ZeroFuncaoDto
    {
        [Required]
        public string Funcao { set; get; }

        public string DerivadaFuncao { set; get; }

        public double X { set; get; }
        
        public double X2 { set; get; }

        public double Precisao { set; get; }
        public Ponto Ponto { set; get; }
    }
}