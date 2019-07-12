using System.Collections.Generic;
using System.Linq;
using ARM_comp.Models.Interpolacao;
using ARM_comp.Models.Interpolacao.Metodos;
using NUnit.Framework;

namespace ARM_comp.Tests.Unit
{
    public class FormaNewtonTeste
    {
        [TestCase(
            new object[]
            {
                new double[]
                {
                    -1, 1
                },
                new double[]
                {
                    0, 1
                },
                new double[]
                {
                    1, 0
                },
                new double[]
                {
                    2, -1
                },
                new double[]
                {
                    3, -2
                }
            },
            new[]
            {
                1, 0, -0.5, -(1 / 6), 0.5
            }
        )]
        public void SomaTest(object[] actualFist, double[] expected)
        {
            var teste = actualFist.Cast<double[]>().ToList();
            var teste2 = new List<PontoCartesiano>();

            foreach (var data in teste)
            {
                teste2.Add(new PontoCartesiano(data[0], data[1]));
            }

            var newton = new FormaNewton();
            Assert.AreEqual(expected.ToList(), newton.CalculaD(teste2));
        }
    }
}