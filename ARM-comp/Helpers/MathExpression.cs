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
            return _node.Calcular(x);
        }
    }
}