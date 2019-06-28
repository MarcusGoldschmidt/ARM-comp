using System.Linq;

namespace ARM_comp.Helpers.NotEval
{
    public class TokenList
    {
        private readonly string[] Operators = new[]
        {
            "+", "-", "*", "/","^"
        };
        
        private readonly string[] NormalOperators = new[]
        {
            "+", "-"
        };
        
        private readonly string[] PreferenceOperators = new[]
        {
            "*", "/","^"
        };
        
        private readonly string[] Decimal = new[]
        {
            "1","2","3","4","5","6","7","8","9","0","."
        };

        public bool IsPrecedenceOperators(string data)
        {
            return PreferenceOperators.Any(VARIABLE => VARIABLE == data);
        }
        
        public bool IsDecimal(string data)
        {
            return Decimal.Any(VARIABLE => VARIABLE == data);
        }
    }
}