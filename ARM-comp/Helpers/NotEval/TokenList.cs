using System.Linq;

namespace ARM_comp.Helpers.NotEval
{
    public class TokenList
    {
        private readonly string[] Operators = {
            "+", "-", "*", "/", "^"
        };

        private readonly string[] NormalOperators = {
            "+", "-"
        };

        private readonly string[] PreferenceOperators = {
            "*", "/"
        };

        private readonly string[] SpecialPreferenceOperators = {
            "^"
        };

        private readonly string[] Decimal = {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "."
        };

        private readonly string[] SpecialFunctions = {
            "sen","cos","tan",
            "arcsen","arccos","arctan",
            "cotan","sec","cosec",
            "arccotan","arcsec","arccosec",
            "log","sqrt"
        };

        public bool IsPrecedenceOperators(string data)
        {
            return PreferenceOperators.Any(VARIABLE => VARIABLE == data);
        }

        public bool IsSpecialPreferenceOperators(string data)
        {
            return SpecialPreferenceOperators.Any(VARIABLE => VARIABLE == data);
        }

        public bool IsDecimal(char data)
        {
            return Decimal.Any(number => number == data.ToString());
        }
    }
}