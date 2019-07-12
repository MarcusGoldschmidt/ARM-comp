using System;
using System.Collections.Generic;
using System.Linq;

namespace ARM_comp.Helpers.NotEval
{
    public class Node
    {
        public Node(string data)
        {
            Expression = RemovePareteses(FormataString(data));
            ValidacaoString(Expression);
            var tokens = Lexico(Expression);
            tokens = AjustePrioridade(tokens);
            generate(tokens);
        }

        private string Expression { set; get; }

        public string Value { set; get; }

        public Node Left { set; get; }

        public Node Right { set; get; }

        private string FormataString(string data)
        {
            var aux = data.Replace(" ", ""); 
            return aux.Replace("E","*10^");
        }

        protected string RemovePareteses(string data)
        {
            if (data[0] != '(') return data;
            var insideBlock = 0;

            for (var j = 0; j < data.Length; j++)
            {
                if (data[j] == '(')
                    insideBlock++;

                if (data[j] != ')' && insideBlock == 0) break;

                if (data[j] != ')') continue;
                insideBlock--;
                if (j == data.Length - 1)
                {
                    return data.Substring(1, data.Length - 2);
                }
            }

            return data;
        }

        protected List<string> Lexico(string data)
        {
            var tokens = new List<string>();

            for (var i = 0; i < data.Length; i++)
            {
                // Gambiarra
                if (i == 0 && data[i] == '-')
                {
                    var aux = "-"+BlocoDecimal(data.Substring(i+1));
                    tokens.Add(aux);
                    i += aux.Length - 1;
                    continue;
                }

                if (data[i] == '(')
                {
                    var aux = BlocoParenteses(data.Substring(i));
                    tokens.Add(aux);
                    i += aux.Length - 1;
                }
                else
                {
                    if (TokenList.IsDecimal(data[i]))
                    {
                        var aux = BlocoDecimal(data.Substring(i));
                        tokens.Add(aux);
                        i += aux.Length - 1;
                    }
                    else
                    {
                        if (TokenList.IsLetterAndNotX(data[i]))
                        {
                            var aux = BlocoFuncao(data.Substring(i));
                            tokens.Add(aux);
                            i += aux.Length - 1;
                        }
                        else
                        {
                            // TODO: Verificar quando o valor é negativo
                            tokens.Add(data[i].ToString());
                            if (TokenList.IsOperators(data[i].ToString())
                                && data[i + 1] == '-')
                            {
                                var aux = data[++i].ToString();
                                aux = $"{aux}{BlocoDecimal(data.Substring(i + 1))}";
                                tokens.Add(aux);
                                i += aux.Length - 1;
                            }
                        }
                    }
                }
            }

            return tokens;
        }

        protected List<string> AjustePrioridade(List<string> lexemas)
        {
            var newList = new List<string>();

            // Funcao Trigonometrica
            // Primeira letra do primeiro lexema
            if (lexemas.Count == 1 && TokenList.IsLetterAndNotX(lexemas[0][0]))
            {
                var interator = 0;
                while (TokenList.IsLetterAndNotX(lexemas[0][interator]))
                {
                    interator++;
                }

                newList.Add(lexemas[0].Substring(0, interator));
                var blocoInterno = lexemas[0].Substring(interator);
                newList.Add(blocoInterno.Substring(1, blocoInterno.Length - 2));

                return newList;
            }

            // Quando valor é negativo
            if (lexemas.Count == 2 && lexemas[0] == "-")
            {
                var retoro = $"{lexemas[0]}{lexemas[1]}";
                newList.Add(retoro);
                return newList;
            }

            if (lexemas.Count == 3 || lexemas.Count == 1)
            {
                return lexemas;
            }

            // TODO: Essa parte tem que arrumar para cada novo operador de prioridade maior tem que
            // Colocar um for aumentado com o if da confição
            // Então fixme

            // Procura prioridade
            for (var i = 1; i < lexemas.Count; i++)
            {
                if (TokenList.IsSpecialPreferenceOperators(lexemas[i]))
                {
                    var bloco = $"{lexemas[i - 1]}{lexemas[i]}{lexemas[i + 1]}";
                    lexemas[i - 1] = bloco;
                    lexemas.RemoveAt(i);
                    lexemas.RemoveAt(i);
                }
            }

            // Procura prioridade
            for (var i = 1; i < lexemas.Count; i++)
            {
                if (TokenList.IsPrecedenceOperators(lexemas[i]) && lexemas.Count > 3)
                {
                    var bloco = $"{lexemas[i - 1]}{lexemas[i]}{lexemas[i + 1]}";
                    lexemas[i - 1] = bloco;
                    lexemas.RemoveAt(i);
                    lexemas.RemoveAt(i);
                }
            }

            newList.Add(lexemas[0]);
            newList.Add(lexemas[1]);
            var aux = "";
            for (var i = 2; i < lexemas.Count; i++)
            {
                aux += lexemas[i];
            }

            newList.Add(aux);

            return newList;
        }

        protected string BlocoParenteses(string data)
        {
            var block = 0;
            for (var i = 0; i < data.Length; i++)
            {
                if (data[i] == '(')
                    block++;

                if (data[i] == ')')
                    block--;

                if (block == 0)
                {
                    block = i;
                    break;
                }
            }

            return data.Substring(0, block + 1);
        }

        protected string BlocoDecimal(string data)
        {
            var i = 0;
            while (TokenList.IsDecimal(data[i]))
            {
                i++;
                if (i == data.Length)
                {
                    break;
                }
            }

            return data.Substring(0, i);
        }

        private void ValidacaoString(string data)
        {
            if (data.Any(e => e == '(' || e == ')'))
            {
                var abriu = data.Count(e => e == '(');
                var fechou = data.Count(e => e == ')');
                if (abriu - fechou != 0)
                {
                    throw new Exception("Formatação errada");
                }
            }
        }

        protected string BlocoFuncao(string data)
        {
            var aux = 0;
            while (TokenList.IsLetterAndNotX(data[aux]))
            {
                aux++;
            }

            var block = 0;
            for (var i = aux; i < data.Length; i++)
            {
                if (data[i] == '(')
                    block++;

                if (data[i] == ')')
                    block--;

                if (block == 0)
                {
                    block = i;
                    break;
                }
            }

            var let = data.Substring(0, block + 1);
            return let;
        }

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