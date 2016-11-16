using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsecutiveLettersToOne.Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void DeleteConsecutiveLettersTestNormalCase()
        {
            Program runner = new Program();

            string word = "n00bs";
            string expected = "n0bs";
            string actual = runner.DeleteConsecutiveLetters(word);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteConsecutiveLettersTestEvenOccurences()
        {
            Program runner = new Program();

            string word = "nnnnobs";
            string actual = runner.DeleteConsecutiveLetters(word);
            string expected = "nobs";

            Assert.AreEqual(actual, expected, "breaks in front!");

            word = "nobssssss";
            actual = runner.DeleteConsecutiveLetters(word);
            expected = "nobs";

            Assert.AreEqual(actual, expected, "Breaks in the back!");
        }

        [TestMethod]
        public void DeleteConsecutiveLettersTestOddOccurences()
        {
            Program runner = new Program();

            string word = "nnnobs";
            string actual = runner.DeleteConsecutiveLetters(word);
            string expected = "nobs";

            Assert.AreEqual(actual, expected, "breaks in front!");

            word = "nobSSS";
            actual = runner.DeleteConsecutiveLetters(word);
            expected = "nobS";

            Assert.AreEqual(actual, expected, "Breaks in the back!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteConsecutiveLettersTestWithNullString()
        {
            Program runner = new Program();

            string actual = runner.DeleteConsecutiveLetters(null);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteConsecutiveLettersTestWithEmptyString()
        {
            Program runner = new Program();
            string word = "";
            string actual = runner.DeleteConsecutiveLetters(word);
        }
    }
}
