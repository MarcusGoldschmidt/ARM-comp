using System.Collections.Generic;

namespace ARM_comp.Helpers.NotEval
{
    public class Node
    {
        public Node(string data)
        {
            Expression = RemovePareteses(FormataString(data));
            var tokens = Lexico(Expression);
            tokens = AjustePrioridade(tokens);
            generate(tokens);
        }

        protected string Expression { set; get; }

        public string Value { set; get; }

        public Node Left { set; get; }

        public Node Right { set; get; }

        protected string FormataString(string data)
        {
            return data.Replace(" ", "");
        }

        protected string RemovePareteses(string data)
        {
            if (data[0] != '(') return data;
            var point = 0;
            var insideBlock = 0;

            for (var j = 0; j < data.Length; j++)
            {
                point++;
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
            var TokenList = new TokenList();
            var tokens = new List<string>();

            for (var i = 0; i < data.Length; i++)
            {
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
                        tokens.Add(data[i].ToString());
                    }
                }
            }

            return tokens;
        }
        
        protected List<string> AjustePrioridade(List<string> lexemas)
        {
            var newList = new List<string>();
            var tokenList = new TokenList();

            if (lexemas.Count == 3 || lexemas.Count == 1)
            {
                return lexemas;
            }

            // Procura prioridade
            for (var i = 1; i < lexemas.Count; i++)
            {
                if (tokenList.IsPrecedenceOperators(lexemas[i]))
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
            var TokenList = new TokenList();
            var aux = "";
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

        private void generate(List<string> data)
        {
            if (data.Count == 1)
            {
                Value = data[0];
            }
            else
            {
                Value = data[1];
                Left = new Node(data[0]);
                Right = new Node(data[2]);
            }
        }
    }
}