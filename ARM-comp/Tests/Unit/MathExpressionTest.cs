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
        public void CriacaoMathExpressionTest(object[] actual, double expected)
        {
            var aux = new MathExpression(actual[0].ToString());
            var x = Convert.ToDouble(actual[1]);
            Assert.AreEqual(expected, aux.F(x));
        }
    }
}