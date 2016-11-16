using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TranslateGibberishSentences.Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TranslateGibberishSentenceTestNormalCase()
        {
            Program runner = new Program();

            string sentence = "wrong is sentence this";
            string expected = "This sentence is wrong";
            string actual = runner.TranslateGibberishSentence(sentence);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TranslateGibberishSentenceTestWithSingleEmptySpace()
        {
            Program runner = new Program();

            string sentence = " ";
            string expected = " ";
            string actual = runner.TranslateGibberishSentence(sentence);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TranslateGibberishSentenceTestWithEmptySentence()
        {
            Program runner = new Program();

            string sentence ="";
            string actual = runner.TranslateGibberishSentence(sentence);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateOutputFromNameTestNullCase()
        {
            Program runner = new Program();

            runner.TranslateGibberishSentence(null);
        }

        [TestMethod]
        public void TranslateGibberishSentenceTestUpperCaseWithEmptyLastCharacterInSentence()
        {
            Program runner = new Program();

            string sentence = "wrong is sentence this ";
            string expected = "This sentence is wrong";
            string actual = runner.TranslateGibberishSentence(sentence);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TranslateGibberishSentenceTestOddNumberOfWords()
        {
            Program runner = new Program();

            string sentence = "wrong is sentence this really";
            string expected = "Really this sentence is wrong";
            string actual = runner.TranslateGibberishSentence(sentence);

            Assert.AreEqual(expected, actual);
        }

    }
}
