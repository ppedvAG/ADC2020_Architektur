using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_3_and_4_results_9()
        {
            //Arrange
            var calc = new Calc();

            //Act
            int result = calc.Sum(4, 5);

            //Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Calc_Sum_0_and_0_results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Calc_Sum_MAX_and_1_throws_OverflowException()
        {
            //Arrange
            var calc = new Calc();

            //Act + Assert
            Assert.ThrowsException<OverflowException>(()=> calc.Sum(int.MaxValue, 1));

        }
    }
}
