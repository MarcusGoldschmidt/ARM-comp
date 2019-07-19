using System;
using System.Collections.Generic;
using System.Linq;

namespace ARM_comp.Helpers.NotEval
{
    public class Node
    {
        public Node(string data)
        {
            var aux = new Analyzer();
            generate(aux.BlocoGeracao(data));
        }
        public string Value { set; get; }

        public Node Left { set; get; }

        public Node Right { set; get; }

        private void generate(IReadOnlyList<string> data)
        {
            if (data.Count == 1)
            {
                Value = data[0];
            }
            else if (data.Count == 2)
            {
                Value = data[0];
                Right = new Node(data[1]);
            }
            else
            {
                Value = data[1];
                Left = new Node(data[0]);
                Right = new Node(data[2]);
            }
        }

        public double Calcular(double number)
        {
            // Terminal
            if (Left == null && Right == null)
            {
                switch (Value)
                {
                    case "x":
                        return number;
                    case "e":
                        return Math.E;
                    case "P":
                        return Math.PI;
                    default:
                        return Convert.ToDouble(Value);
                }
            }

            // Funcoes normais
            if (Right != null && Left != null)
            {
                switch (Value)
                {
                    case "+":
                        return Left.Calcular(number) + Right.Calcular(number);
                    case "-":
                        return Left.Calcular(number) - Right.Calcular(number);
                    case "*":
                        return Left.Calcular(number) * Right.Calcular(number);
                    case "/":
                        var aux = Left.Calcular(number) / Right.Calcular(number);
                        if (double.IsNaN(aux) || double.IsInfinity(aux))
                            throw new DivideByZeroException();
                        return aux;
                    case "^":
                        return Math.Pow(Left.Calcular(number), Right.Calcular(number));
                }
            }

            // Funcoes trigonometrica
            if (Right != null)
            {
                switch (Value)
                {
                    case "sen":
                        return Math.Sin(Right.Calcular(number));
                    case "cos":
                        return Math.Cos(Right.Calcular(number));
                    case "tan":
                        return Math.Tan(Right.Calcular(number));
                    case "arcsen":
                        return Math.Asin(Right.Calcular(number));
                    case "arccos":
                        return Math.Acos(Right.Calcular(number));
                    case "arctan":
                        return Math.Atan(Right.Calcular(number));
                    case "ln":
                        return Math.Log10(Right.Calcular(number));
                    case "sqrt":
                        return Math.Sqrt(Right.Calcular(number));
                    default:
                        throw new Exception("Função não reconhecida: " + Value);
                }
            }

            return number;
        }
    }
}