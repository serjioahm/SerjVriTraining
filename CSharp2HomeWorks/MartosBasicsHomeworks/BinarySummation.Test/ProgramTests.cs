using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySummation.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void SummationOfBineryRepresentationOfIntegersTestNormalCase()
        {
            Program runner = new Program();

            int number1 = 2;
            int number2 = 5;
            int actual = runner.SummationOfBineryRepresentationOfIntegers(number1, number2);
            int expectedSum = 3;

            Assert.AreEqual(expectedSum, actual);
        }

        [TestMethod]
        public void SummationOfBineryRepresentationOfIntegersTestZeroCase()
        {
            Program runner = new Program();

            int minNumber = 0;

            int actual = runner.SummationOfBineryRepresentationOfIntegers(minNumber, minNumber);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void SummationOfBineryRepresentationOfIntegersTestMaxCase()
        {
            Program runner = new Program();

            int maxNumber = int.MaxValue;

            int actual = runner.SummationOfBineryRepresentationOfIntegers(maxNumber, maxNumber);

            Assert.AreEqual(62, actual);
        }

        //..

        [TestMethod]
        public void CalculateOnesInNumberTestNormalCase()
        {
            Program runner = new Program();

            int number = 5;
            int actual = runner.CalculateOnesInNumber(number);
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateOnesInNumberTestZeroCase()
        {
            Program runner = new Program();

            int minNumber = 0;

            int actual = runner.CalculateOnesInNumber(minNumber);

            Assert.AreEqual(0, actual);

        }

        [TestMethod]
        public void CalculateOnesInNumberTestMaxCase()
        {
            Program runner = new Program();

            int maxNumber = int.MaxValue;

            int actual = runner.CalculateOnesInNumber(maxNumber);

            Assert.AreEqual(31, actual);
        }

    }
}
