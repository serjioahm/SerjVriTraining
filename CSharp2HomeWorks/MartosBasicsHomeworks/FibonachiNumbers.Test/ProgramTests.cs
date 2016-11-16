using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FibonachiNumbers.Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void FindFibonachiNumbersTestNormalCase()
        {
            Program runner = new Program();

            int length = 10;
            int[] actual = runner.FindFibonachiNumbers(length);
            int[] expected = new int[] { 0, 1, 1, -2, 3, 5, -8, 13, 21, -34 };

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void FindFibonachiNumbersTestZeroCase()
        {
            Program runner = new Program();

            int length = 0;
            int[] actual = runner.FindFibonachiNumbers(length);
            int[] expected = new int[0];

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindFibonachiNumbersTestNegativeCase()
        {
            Program runner = new Program();

            int length = -10;
            int[] actual = runner.FindFibonachiNumbers(length);
        }
    }
}
