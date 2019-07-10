using System.Linq;
using ARM_comp.Helpers.NotEval;
using NUnit.Framework;

namespace ARM_comp.Tests.Unit
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
        public void BlocoParentesesTest(double[] actualFist, double[] actualSecond, double[] expected)
        {
            var a = new Polinomial(actualFist.ToList());
            var b = new Polinomial(actualSecond.ToList());
            a.Multiplicar(b);
            Assert.IsTrue(expected.SequenceEqual(a.Polinomio.Values.ToList()));
        }
    }
}