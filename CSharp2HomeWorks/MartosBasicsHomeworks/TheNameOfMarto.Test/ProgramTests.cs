using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheNameOfMarto.Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CreateOutputFromNameTestNormalCase()
        {
            Program runner = new Program();

            string name = "Martin Abrashev";
            string expected = "Hello my name is \"" + name + "\"";
            string actual = runner.CreateOutputFromName(name);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreateOutputFromNameTestNullCase()
        {
            Program runner = new Program();

            runner.CreateOutputFromName(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateOutputFromNameTestEmptyString()
        {
            Program runner = new Program();

            string name = "";
            runner.CreateOutputFromName(name);
        }

    }
}
