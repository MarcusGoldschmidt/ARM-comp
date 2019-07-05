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
                    ponto.A = args[0];
                    ponto.B = args[1];
                    break;
                case 4:
                    ponto.A = args[0];
                    ponto.B = args[1];
                    ponto2.A = args[2];
                    ponto2.B = args[3];
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
        public Ponto ponto { set; get; }
        
        public Ponto ponto2 { set; get; }

        private MathExpression _math { set; get; }

        private bool ZeroNoIntervalo(Ponto date)
        {
            return _math.F(date.A) * _math.F(date.B) <= 0;
        }

        public double Bissecao()
        {
            return _math.F(ponto.A);
        }
    }
}