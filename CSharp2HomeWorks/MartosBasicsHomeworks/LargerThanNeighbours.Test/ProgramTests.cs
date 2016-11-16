using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LargerThanNeighbours;

namespace LargerThanNeighbours.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ConvertStringArrayToIntegerArrayTestNormalCase()
        {
            Program runner = new Program();

            string[] stringArray = new string[] { "1", "3", "5", "12", "4", "6" };
            int[] expected = new int[] { 1, 3, 5, 12, 4, 6 };

            int[] actual = runner.ConvertStringArrayToIntegerArray(stringArray);

            Assert.AreEqual(expected.Length, actual.Length);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ConvertStringArrayToIntegerArrayTestStringArrayWithNotNumbers()
        {
            Program runner = new Program();

            string[] stringArray = new string[] { "1", "3", "5", "asd", "4", "6" };
            int[] actual = runner.ConvertStringArrayToIntegerArray(stringArray);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ConvertStringArrayToIntegerArrayTestWithNull()
        {
            Program runner = new Program();
            runner.ConvertStringArrayToIntegerArray(null);
        }

        [TestMethod]
        public void IsLargerThanNeighbourTestNormalCaseTrue()
        {
            Program runner = new Program();
            int index = 3;
            int[] array = new int[] { 1, 4, 2, 7, 5 };

            bool actual = runner.IsLargerThanNeighbours(index, array);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsLargerThanNeighbourTestNormalCaseFalse()
        {
            Program runner = new Program();
            int index = 2;
            int[] array = new int[] { 1, 4, 2, 7, 5 };

            bool actual = runner.IsLargerThanNeighbours(index, array);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsLargerThanNeighbourTestBorderCaseLeft()
        {
            Program runner = new Program();
            int index = 0;
            int[] array = new int[] { 1, 4, 2, 7, 5 };

            bool actual = runner.IsLargerThanNeighbours(index, array);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsLargerThanNeighbourTestBorderCaseRight()
        {
            Program runner = new Program();
            int[] array = new int[] { 1, 4, 2, 7, 5 };
            int index = array.Length - 1;

            bool actual = runner.IsLargerThanNeighbours(index, array);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IsLargerThanNeighbourTestNegativeIndex()
        {
            Program runner = new Program();
            int[] array = new int[] { 1, 4, 2, 7, 5 };
            int index = -3;

            runner.IsLargerThanNeighbours(index, array);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IsLargerThanNeighbourTestLargerIndex()
        {
            Program runner = new Program();
            int[] array = new int[] { 1, 4, 2, 7, 5 };
            int index = 985;

            runner.IsLargerThanNeighbours(index, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsLargerThanNeighbourTestNullArray()
        {
            Program runner = new Program();
            int index = 1;

            runner.IsLargerThanNeighbours(index, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsLargerThanNeighbourTestEmptyArray()
        {
            Program runner = new Program();
            int[] array = new int[0];
            int index = 0;

            runner.IsLargerThanNeighbours(index, array);
        }

        private void SomeMethod()
        {

        }

    }
}
