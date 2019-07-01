using System.Collections.Generic;
using ARM_comp.Helpers.NotEval;
using NUnit.Framework;

namespace ARM_comp.Tests.Unit
{
    [TestFixture("x + x")]
    [TestFixture("x + x * x")]
    public class NodeTest : Node
    {

        public NodeTest(string data) : base(data)
        {
        }

        [Test]
        public void Construtor()
        {
            Assert.AreEqual("x + x", this.Expression);
        }

        [TestCase("x + x", "(x + x)")]
        [TestCase("x + (x * x)", "x + (x * x)")]
        [TestCase("(x) + x", "(x) + x")]
        [TestCase("(x + x) * (x + x)", "(x + x) * (x + x)")]
        [TestCase("(x + x) * (x + x)", "((x + x) * (x + x))")]
        public void removeParentesesTest(string expected, string actual)
        {
            Assert.AreEqual(expected, removePareteses(actual));
        }
        
        [TestCase(new[]{"AA"}, "(x + x)")]
        public void tokenizeTest(List<string> expected, string actual)
        {
            
        }
    }
}