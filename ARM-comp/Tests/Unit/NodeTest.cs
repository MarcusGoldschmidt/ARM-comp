using System.Collections.Generic;
using System.Linq;
using ARM_comp.Helpers.NotEval;
using NUnit.Framework;

namespace ARM_comp.Tests.Unit
{
    [TestFixture("x + x")]
    public class NodeTest : Node
    {

        public NodeTest(string data) : base(data)
        {
        }

        [TestCase("x + x", "(x + x)")]
        [TestCase("x + (x * x)", "x + (x * x)")]
        [TestCase("(x) + x", "(x) + x")]
        [TestCase("(x + x) * (x + x)", "(x + x) * (x + x)")]
        [TestCase("(x + x) * (x + x)", "((x + x) * (x + x))")]
        [TestCase("x + x", "x + x")]
        public void RemoveParentesesTest(string expected, string actual)
        {
            Assert.AreEqual(expected, RemovePareteses(actual));
        }
        
        [TestCase("(x+x)+2",
            "(x+x)",
            "+",
            "2")]
        [TestCase("2+(x+x)",
            "2",
            "+",
            "(x+x)")]
        [TestCase("(x+x)-x*(x/x)",
            "(x+x)",
            "-",
            "x",
            "*",
            "(x/x)")]
        [TestCase("(x+x)+100",
            "(x+x)",
            "+",
            "100")]
        public void LexicoTest(string actual,params string[] expected)
        {
            Assert.AreEqual(expected.ToList(), Lexico(actual));
        }
        
        [TestCase("(x + x)", "(x + x) + 2")]
        [TestCase("(x + x)", "(x + x)")]
        [TestCase("(x+x)", "(x+x)")]
        public void BlocoParentesesTest(string expected, string actual)
        {
            Assert.AreEqual(expected, BlocoParenteses(actual));
        }

        [TestCase("1000", "1000*(x+x)")]
        [TestCase("1.57", "1.57*(x+x)")]
        public void BlocoDecimalTest(string expected, string actual)
        {
            Assert.AreEqual(expected, BlocoDecimal(actual));
        }
        
        [TestCase(
            new object[] {"100","+","x", "*", "x"},
            new object[] {"100", "+","x*x"}
            )]
        [TestCase(
            new object[] {"100","+","x"},
            new object[] {"100", "+","x"}
        )]
        [TestCase(
            new object[] {"100","+","x", "*", "x", "*","x"},
            new object[] {"100", "+","x*x*x"}
        )]
        [TestCase(
            new object[] {"100","*","x", "*", "x"},
            new object[] {"100*x", "*","x"}
        )]
        [TestCase(
            new object[] {"x","*","x", "*", "x"},
            new object[] {"x*x", "*","x"}
        )]
        [TestCase(
            new object[] {"x","*","x", "*", "x","+","x"},
            new object[] {"x*x", "*","x+x"}
        )]
        [TestCase(
            new object[] {"x","+","(100+x)", "*", "(10/500)","+","x"},
            new object[] {"x", "+","(100+x)*(10/500)+x"}
        )]
        [TestCase(
            new object[] {"x","+","(100+x)", "*", "(10/500)"},
            new object[] {"x", "+","(100+x)*(10/500)"}
        )]
        [TestCase(
            new object[] {"100"},
            new object[] {"100"}
        )]
        [TestCase(
            new object[] {"x"},
            new object[] {"x"}
        )]
        
        [TestCase(
            new object[] {"*"},
            new object[] {"*"}
        )]
        [TestCase(
            new object[] {"+"},
            new object[] {"+"}
        )]
        [TestCase(
            new object[] {"x","*","x","+","(x+x)"},
            new object[] {"x*x","+","(x+x)"}
        )]
        public void AjustePrioridadeTest(object[] actual, object[] expected)
        {
            var lista = actual.Select(data => data.ToString()).ToList();
            
            Assert.AreEqual(expected.ToList(), AjustePrioridade(lista));
        }
    }
}