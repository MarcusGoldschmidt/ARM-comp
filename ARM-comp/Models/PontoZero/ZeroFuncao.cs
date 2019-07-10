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
            X = data.X;
            X2 = data.X2;
            
            _math = new MathExpression(Funcao);
            if (!ZeroNoIntervalo(data.Ponto))
                throw new Exception("Zero não está contido no intervalo");
            Precisao = data.Precisao != 0 ? data.Precisao : 0.001;
            Ponto = data.Ponto;
        }
        
        [Required]
        public string Funcao { set; get; }
        
        public string DerivadaFuncao { set; get; }
        
        public double X { set; get; }
        
        public double X2 { set; get; }
        
        public double Precisao { set; get; }

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

            } while (Math.Abs(fx) >= Precisao);

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

            } while (Math.Abs(fx) >= Precisao);

            return x;
        }
        
        public double NewtonRaphson()
        {
            if (DerivadaFuncao == null)
                throw new Exception("Função derivada necessária");

            if (X == null)
                throw new Exception("Valor de X necessário");
            
            var funcaoLinha = new MathExpression(DerivadaFuncao);
            var x = X;
            double fx;
            
            do
            {
                x -= _math.F(x) / funcaoLinha.F(x);

                fx = _math.F(x);
            } while (Math.Abs(fx) >= Precisao);
            
            return x;
        }
        
        public double NewtonRaphsonDerivadaSimulada()
        {  
            if (X2 == null)
                throw new Exception("Segundo ponto é necessário");
            
            var x1 = X;
            var x2 = X2;
            double x;
            double fx;
            
            do
            {
                var fx1 = _math.F(x1);
                var fx2 = _math.F(x2);
                
                x = (x2 * fx1 - x1 * fx2) / (fx1 - fx2);
                
                x2 = x1;
                x1 = x;
                
                fx = _math.F(x1);
            } while (Math.Abs(fx) >= Precisao);
            
            return x;
        }
    }
}