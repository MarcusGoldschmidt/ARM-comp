using ARM_comp.Helpers.NotEval;

namespace ARM_comp.Helpers
{
    public class MathExpression
    {
        public MathExpression(string data)
        {
            Node = new Node(data);
        }

        private Node Node { get; }

        public double F(double x)
        {
            return Node.Calcular(x);
        }
    }
}