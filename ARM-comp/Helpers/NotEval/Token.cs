using System.Linq;

namespace ARM_comp.Helpers.NotEval
{
    public class Token
    {
        public Token(string expresion)
        {
            this.Expresion = expresion;
            verificationOperator();
        }
        
        public string Expresion { set; get; }
        
        public bool ContainsSpecialOperator { set; get; }

        private void verificationOperator()
        {
            var List = new TokenList().SpecialOperators;
            ContainsSpecialOperator = false;
            foreach (var Operator in List)
            {
                if (Expresion.Contains(Operator))
                {
                    ContainsSpecialOperator = true;
                    break;
                }
            }
        }
    }
}