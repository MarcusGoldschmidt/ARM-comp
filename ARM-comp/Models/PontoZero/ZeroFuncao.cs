using System;
using System.ComponentModel.DataAnnotations;
using ARM_comp.Helpers.NotEval;

namespace ARM_comp.Models.PontoZero
{
    public class ZeroFuncao
    {
        public ZeroFuncao(ZeroFuncaoDto data)
        {
            Funcao = data.Funcao;
            DerivadaFuncao = data.DerivadaFuncao;
            
            _math = new MathExpression(Funcao);
            if (!ZeroNoIntervalo(data.Ponto))
                throw new Exception("Zero não está contido no intervalo");
            Presicao = data.Presicao != 0 ? data.Presicao : 0.001;
            Ponto = data.Ponto;
            Ponto2 = data.Ponto2;
        }
        
        [Required]
        public string Funcao { set; get; }
        
        public string DerivadaFuncao { set; get; }
        
        public double Presicao { set; get; }

        [Required]
        public Ponto Ponto { set; get; }
        
        public Ponto Ponto2 { set; get; }

        private MathExpression _math { set; get; }

        private bool ZeroNoIntervalo(Ponto date)
        {
            return _math.F(date.A) * _math.F(date.B) <= 0;
        }

        public double Bissecao()
        {  
            double x;
            double fx;
            
            do
            {
                x = (Ponto.A + Ponto.B) / 2;

                fx = _math.F(x);

                if (_math.F(Ponto.A) < 0 & fx < 0)
                {
                    Ponto.A = x;
                }
                else
                {
                    Ponto.B = x;
                }

            } while (Math.Abs(fx) >= Presicao);

            return x;
        }

        public double PosicaoFalsa()
        {
            double x;
            double fx;
            
            do
            {
                var fa = _math.F(Ponto.A);
                var fb = _math.F(Ponto.B);
                
                x = (Ponto.A * fb - Ponto.B * fa) / (fb - fa);

                fx = _math.F(x);

                if (_math.F(Ponto.A) < 0 & fx < 0)
                {
                    Ponto.A = x;
                }
                else
                {
                    Ponto.B = x;
                }

            } while (Math.Abs(fx) >= Presicao);

            return x;
        }
    }
}