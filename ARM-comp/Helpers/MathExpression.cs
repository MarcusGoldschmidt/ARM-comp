using System;

namespace ARM_comp.Helpers.NotEval
{
    public class MathExpression
    {
        public MathExpression(string data)
        {
            _node = new Node(data);
        }

        private Node _node { set; get; }

        public double F(double x)
        {
            // TODO: Colocar essa exception no node
            var aux = _node.Calcular(x);
            if (double.IsNaN(aux) || double.IsInfinity(aux))
            {
                throw new DivideByZeroException();
            }
            return _node.Calcular(x);
        }
    }
}