using System.Linq;
using ARM_comp.Helpers;
using ARM_comp.Helpers.NotEval;
using NUnit.Framework;

namespace ARM_comp.Tests
{
    public class PolinomialTest
    {
        [TestCase(
            new double[] {1, 1},
            new double[] {1, 1},
            new double[] {1, 2, 1}
        )]
        [TestCase(
            new double[] {1, 2},
            new double[] {1, 2},
            new double[] {1, 4, 4}
        )]
        [TestCase(
            new double[] {1, 2},
            new double[] {1},
            new double[] {1, 2}
        )]
        [TestCase(
            new double[] {},
            new double[] {1,2},
            new double[] {}
        )]
        public void MultiplicarTest(double[] actualFist, double[] actualSecond, double[] expected)
        {
            var a = new Polinomial(actualFist.ToList());
            var b = new Polinomial(actualSecond.ToList());
            a.Multiplicar(b);
            Assert.IsTrue(expected.SequenceEqual(a.Polinomio.Values.ToList()));
        }

        [TestCase(
            new double[] {1, 1},
            new double[] {1, 1},
            new double[] {2, 2}
        )]
        [TestCase(
            new double[] {1, 4, 8},
            new double[] {1, 2},
            new double[] {2, 6, 8}
        )]
        [TestCase(
            new double[] {1},
            new double[] {8, 5, 3, 9},
            new double[] {9, 5, 3, 9}
        )]
        public void SomaTest(double[] actualFist, double[] actualSecond, double[] expected)
        {
            var a = new Polinomial(actualFist.ToList());
            var b = new Polinomial(actualSecond.ToList());
            a.Somar(b);
            Assert.IsTrue(expected.SequenceEqual(a.Polinomio.Values.ToList()));
        }
        
        [TestCase(
            new double[] {1, 1},
            0,
            new double[] {0, 0}
        )]
        [TestCase(
            new double[] {1, 4, 8},
            2,
            new double[] {2, 8, 16}
        )]
        [TestCase(
            new double[] {1},
            5,
            new double[] {5}
        )]
        public void SomaDeContantesTest(double[] actualFist, double actualSecond, double[] expected)
        {
            var a = new Polinomial(actualFist.ToList());
            a.Multiplicar(actualSecond);
            Assert.IsTrue(expected.SequenceEqual(a.Polinomio.Values.ToList()));
        }
    }
}