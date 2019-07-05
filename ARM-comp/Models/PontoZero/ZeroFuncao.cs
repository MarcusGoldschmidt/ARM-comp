using System;
using System.ComponentModel.DataAnnotations;
using ARM_comp.Helpers.NotEval;

namespace ARM_comp.Models.PontoZero
{
    public class ZeroFuncao
    {
        public ZeroFuncao(string data, params double[] args)
        {
            presicao = 0.001;
            switch (args.Length)
            {
                case 2:
                    ponto.X = args[0];
                    ponto.Y = args[1];
                    break;
                case 4:
                    ponto.X = args[0];
                    ponto.Y = args[1];
                    ponto2.X = args[2];
                    ponto2.Y = args[3];
                    break;
                default:
                    throw new Exception("Mande apenas 2 pontos");
            }
            _math = new MathExpression(data);
        }

        public ZeroFuncao(ZeroFuncaoDto data)
        {
            funcao = data.funcao;
            
            _math = new MathExpression(funcao);
            if (!ZeroNoIntervalo(data.ponto))
            {
                throw new Exception("Zero não está contido no intervalo");
            }

            presicao = data.presicao;
            ponto = data.ponto;
            ponto2 = data.ponto2;
        }
        
        [Required]
        public string funcao { set; get; }
        
        public double presicao { set; get; }

        [Required]
        public PontoCartesiano ponto { set; get; }
        
        public PontoCartesiano ponto2 { set; get; }

        private MathExpression _math { set; get; }

        private bool ZeroNoIntervalo(PontoCartesiano date)
        {
            return _math.F(date.X) * _math.F(date.Y) < 0;
        }

        public double Bissecao()
        {
            return _math.F(ponto.X);
        }
    }
}