using System.Collections.Generic;
using System.Linq;

namespace ARM_comp.Helpers.NotEval
{
    public static class TokenList
    {
        private static readonly string[] Operators = {
            "+", "-", "*", "/", "^"
        };

        private static readonly string[] NormalOperators = {
            "+", "-"
        };

        private static readonly string[] PreferenceOperators = {
            "*", "/"
        };

        private static readonly string[] SpecialPreferenceOperators = {
            "^"
        };

        private static readonly string[] Decimal = {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "."
        };

        private static readonly string[] SpecialFunctions = {
            "sen","cos","tan",
            "arcsen","arccos","arctan",
            "cotan","sec","cosec",
            "arccotan","arcsec","arccosec",
            "log","sqrt"
        };

        public static bool IsPrecedenceOperators(string data)
        {
            return PreferenceOperators.Any(VARIABLE => VARIABLE == data);
        }

        public static bool IsSpecialPreferenceOperators(string data)
        {
            return SpecialPreferenceOperators.Any(VARIABLE => VARIABLE == data);
        }

        public static bool IsDecimal(char data)
        {
            return Decimal.Any(number => number == data.ToString());
        }
        
        public static bool IsLetterAndNotX(char data)
        {
            if (data >= 99 && data <= 124 && data != 'x')
            {
                return true;
            }

            return false;
        }
        
        public static List<char> Ascii()
        {
            var Ascii = new List<char>();
            for (var i = 0; i < 255; i++)
            {
                Ascii.Add((char) i);
            }
            return Ascii;
        }
    }
}