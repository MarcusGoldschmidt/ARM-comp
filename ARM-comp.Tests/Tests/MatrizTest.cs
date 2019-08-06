using System;
using System.Linq;
using ARM_comp.Helpers;
using NUnit.Framework;

namespace ARM.comp.Tests.Tests
{
    public class MatrizTest
    {
        [TestCase(
            new object[]
            {
                new double[]
                {
                    1, 2, 3
                },
                new double[]
                {
                    4, 5, 6
                }
            },
            5,
            new object[]
            {
                new double[]
                {
                    5, 10, 15
                },
                new double[]
                {
                    20, 25, 30
                }
            }
        )]
        [TestCase(
            new object[]
            {
                new double[]
                {
                    1, 2, 3
                },
                new double[]
                {
                    4, 5, 6
                }
            },
            1,
            new object[]
            {
                new double[]
                {
                    1, 2, 3
                },
                new double[]
                {
                    4, 5, 6
                }
            }
        )]
        public void MultiplicarTest(object[] actualFist, double multiplicador, object[] expected)
        {
            var entrada = actualFist.ToList()
                .Select(e => ((double[]) e).Select(Convert.ToDouble).ToList())
                .ToList();
            var esperado = expected.ToList()
                .Select(e => ((double[]) e).Select(Convert.ToDouble).ToList())
                .ToList();

            var matriz = new Matriz(entrada);
            matriz.Multiplica(multiplicador);
            Assert.True(matriz.Equals(new Matriz(esperado)));
        }
    }
}