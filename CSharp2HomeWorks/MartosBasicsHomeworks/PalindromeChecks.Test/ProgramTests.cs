using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PalindromeChecks.Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CheckStringIfPolindromeTestPositiveEvenCharacters()
        {
            Program runner = new Program();

            string word = "ABBA";
            string expected = "yes";
            string actual = runner.CheckStringIfPolindrome(word);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckStringIfPolindromeTestPositiveOddCharacters()
        {
            Program runner = new Program();

            string word = "ABsBA";
            string expected = "yes";
            string actual = runner.CheckStringIfPolindrome(word);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckStringIfPolindromeTestNegativeOddCharacters()
        {
            Program runner = new Program();

            string word = "Hell0";
            string expected = "no";
            string actual = runner.CheckStringIfPolindrome(word);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckStringIfPolindromeTestNegativeOddCharactersDifferenceAtTheMiddle()
        {
            Program runner = new Program();

            string word = "ABCDECBA";
            string expected = "no";
            string actual = runner.CheckStringIfPolindrome(word);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckStringIfPolindromeTestNegativeOddDifferenceAtTheBeginingAndEnding()
        {
            Program runner = new Program();

            string word = "sABBBsBBBAz";
            string expected = "no";
            string actual = runner.CheckStringIfPolindrome(word);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckStringIfPolindromeTestNegativeEvenDifferenceAtTheBeginingAndEnding()
        {
            Program runner = new Program();

            string word = "sABBBBBBAz";
            string expected = "no";
            string actual = runner.CheckStringIfPolindrome(word);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckStringIfPolindromeTestNegativeEvenCharacters()
        {
            Program runner = new Program();

            string word = "Hell";
            string expected = "no";
            string actual = runner.CheckStringIfPolindrome(word);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckStringIfPolindromeTestWithEmptyString()
        {
            Program runner = new Program();

            string word = "";
            string expected = "yes";
            string actual = runner.CheckStringIfPolindrome(word);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CheckStringIfPolindromeTestWithNullString()
        {
            Program runner = new Program();

            string actual = runner.CheckStringIfPolindrome(null);

        }

    }
}
