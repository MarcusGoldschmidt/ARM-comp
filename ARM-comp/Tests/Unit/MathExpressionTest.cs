using System;
using ARM_comp.Helpers.NotEval;
using NUnit.Framework;

namespace ARM_comp.Tests.Unit
{
    public class MathExpressionTest
    {
        // Primeiro valor é a equação, segundo o x e o terceiro o resultado
        [TestCase(
            new object[] {"100","100"},
            100
        )]
        [TestCase(
            new object[] {"x+x","10"},
            20
        )]
        [TestCase(
            new object[] {"x-x","10"},
            0
        )]
        [TestCase(
            new object[] {"x*x","10"},
            100
        )]
        [TestCase(
            new object[] {"x*x","-10"},
            100
        )]
        [TestCase(
            new object[] {"x+x*x","10"},
            110
        )]
        [TestCase(
            new object[] {"x-x*x","10"},
            -90
        )]
        [TestCase(
            new object[] {"x-x*x","1"},
            0
        )]
        [TestCase(
            new object[] {"(x-x)*x","10"},
            0
        )]
        [TestCase(
            new object[] {"(x-x)+x*x","0"},
            0
        )]
        [TestCase(
            new object[] {"0 * x","5"},
            0
        )]
        [TestCase(
            new object[] {"(100 - 50) * 1","5"},
            50
        )]
        [TestCase(
            new object[] {"(100 - 50) * x","5"},
            250
        )]
        [TestCase(
            new object[] {"100 * x","1"},
            100
        )]
        [TestCase(
            new object[] {"100 + x","5"},
            105
        )]
        [TestCase(
            new object[] {"x*x + 3 * x + 5","5"},
            45
        )]
        [TestCase(
            new object[] {"x /1","5"},
            5
        )]
        [TestCase(
            new object[] {"x / 5","5"},
            1
        )]
        /*[TestCase(
            new object[] {"x / 0","0"},
            double.NaN
        )]*/
        [TestCase(
            new object[] {"x ^ 3","3"},
            27
        )]
        [TestCase(
            new object[] {"(x ^ 2) ^ 2","2"},
            16
        )]
        [TestCase(
            new object[] {"x ^ 2 ^ 2","2"},
            16
        )]
        [TestCase(
            new object[] {"x ^ (1 + 1)","2"},
            4
        )]
        public void CriacaoMathExpressionTest(object[] actual, double expected)
        {
            var aux = new MathExpression(actual[0].ToString());
            var x = Convert.ToDouble(actual[1]);
            Assert.AreEqual(expected, aux.F(x));
        }
    }
}