using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator2;

namespace Calculator.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private BaseCalculatorModel _calc;

        [TestInitialize]
        public void Initialization()
        {
            _calc = new();
        }



        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
