using System.Collections.Generic;

namespace ARM_comp.Helpers.NotEval
{
    public class Node
    {
        public Node(string data)
        {
            this.Expression = data;
        }

        protected string Expression { set; get; }

        public string value { set; get; }

        public Node Left { set; get; }

        public Node Right { set; get; }

        protected List<string> Tokens { set; get; }

        protected string formataString(string data)
        {
            return data.Replace(" ", "");
        }

        protected string removePareteses(string data)
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
    }
}