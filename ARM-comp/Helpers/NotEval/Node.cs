using System.Collections.Generic;

namespace ARM_comp.Helpers.NotEval
{
    public class Node
    {
        public Node(string data)
        {
            Expression = data.Replace(" ", "");
            Expression = removeParenteses(Expression);
            Tokenize(Expression);
            Generate();
        }

        private string Expression { set; get; }

        public string value { set; get; }

        public Node Left { set; get; }

        public Node Right { set; get; }

        private List<string> Tokens { set; get; }

        private string removeParenteses(string data)
        {
            if (data[0] == '(')
            {
                var point = 0;
                var insideBlock = 0;

                for (var j = 0; j < data.Length; j++)
                {
                    point++;
                    if (data[j] == '(')
                        insideBlock++;

                    if (data[j] != ')') continue;
                    insideBlock--;
                    if (j == data.Length - 1)
                    {
                        return data.Substring(1,data.Length - 2);
                    }

                }
            }
            return data;
        }

        private void Tokenize(string data)
        {
            var Valid = new TokenList();
            Tokens = new List<string>();
            for (var i = 0; i < data.Length; i++)
            {
                // Identifica um bloco com ()
                if (data[i] == '(')
                {
                    var point = i;
                    var insideBlock = 0;

                    for (var j = i; j < data.Length; j++)
                    {
                        point++;
                        if (data[j] == '(')
                            insideBlock++;

                        if (data[j] == ')')
                            insideBlock--;

                        if (insideBlock == 0)
                            break;
                    }

                    Tokens.Add(data.Substring(i, point - i));
                    Tokens.Add(data.Substring(point,1));
                    i = point;
                    continue;
                }

                Tokens.Add(data.Substring(i,1));
            }
        }

        private void Generate()
        {
            if (Tokens.Count == 1)
            {
                value = Tokens[0];
            }
            else if (Tokens.Count >= 3)
            {
                Left = new Node(Tokens[0]);
                value = Tokens[1];
                Right = new Node(Tokens[2]);
            }
        }
    }
}