using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARM_comp.Models.Interpolacao;
using ARM_comp.Models.Interpolacao.Metodos;
using NUnit.Framework;

namespace ARM_comp.Tests
{
    public class FormaNewtonTeste
    {
        [TestCase(
            new object[]
            {
                new double[]
                {
                    1, 1
                },
                new double[]
                {
                    2, 7
                },
                new double[]
                {
                    3, 10
                }
            },
            new[]
            {
                1, 6,-((double)3/2)
            }
        )]
        public void SomaTest(object[] actualFist, double[] expected)
        {
            var newList = new List<PontoCartesiano>();

            foreach (var data in actualFist.Cast<double[]>().ToList())
            {
                newList.Add(new PontoCartesiano(data[0], data[1]));
            }

            var newton = new FormaNewton(newList);
            var a = newton.CalculaD();
            Assert.AreEqual(expected.ToList(), a);
        }
    }
}