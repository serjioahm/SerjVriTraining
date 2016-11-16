using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoursSpentWorking.Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void ReadLinesFromTextFileTestNotExistingFilePath()
        {
            Program runner = new Program();

            string filePath = @"../../HoursNotFound.txt";
            runner.ReadLinesFromTextFile(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void ReadLinesFromTextFileTestNullFilepath()
        {
            Program runner = new Program();
            runner.ReadLinesFromTextFile(null);
        }

        [TestMethod]
        public void ReadLinesFromTextFileTestNormalCase()
        {
            Program runner = new Program();
            string filePath = @"../../workingHours.txt";
            string[] actual = runner.ReadLinesFromTextFile(filePath);
            string[] expected = new string[] { "Marto;HRM Stuff; 200-20+50", "Marto;Drinking tea;30", "Joro;Looking for the meaning of life;42", "Joro;Helping you solve your tasks;58+60" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadLinesFromTextFileTestEmptyFileCase()
        {
            Program runner = new Program();
            string filePath = @"../../EmptyFile.txt";
            string[] actual = runner.ReadLinesFromTextFile(filePath);
            string[] expected = new string[0];

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateWorkingHoursFromTextFileLinesTestNormalCase()
        {
            Program runner = new Program();
            string[] lines = new string[] { "Marto;HRM Stuff;200-20+50",
                                            "Marto;Drinking tea;30",
                                            "Joro;Looking for the meaning of life;42",
                                            "Joro;Helping you solve your tasks;58+60" };
            string[] actual = runner.CalculateWorkingHoursFromTextFileLines(lines);
            string[] expected = { "Marto-4.33", "Joro-2.67" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateWorkingHoursFromTextFileLinesTestEmptyCase()
        {
            Program runner = new Program();
            string[] lines = new string[0];
            runner.CalculateWorkingHoursFromTextFileLines(lines);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CalculateWorkingHoursFromTextFileLinesTestNullCase()
        {
            Program runner = new Program();
            runner.CalculateWorkingHoursFromTextFileLines(null);
        }

        [TestMethod]
        public void CalculateWorkingHoursFromTextFileLinesTestInputInvalidSumOfMinutesBelowZero()
        {
            Program runner = new Program();
            string[] lines = new string[] { "Marto;HRM Stuff;200-20+50",
                                            "Marto;Drinking tea;30",
                                            "Joro;Looking for the meaning of life;42",
                                            "Joro;Helping you solve your tasks;58-160" };
            string[] actual = runner.CalculateWorkingHoursFromTextFileLines(lines);
            string[] expected = { "Input invalid" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateWorkingHoursFromTextFileLinesTestInputInvalidDifferentDeveloperNames()
        {
            Program runner = new Program();
            string[] lines = new string[] { "Martijn;HRM Stuff;200-20+50",
                                            "Martijn;Drinking tea;30",
                                            "Serj;Looking for the meaning of life;42",
                                            "Serj;Helping you solve your tasks;58-160" };
            string[] actual = runner.CalculateWorkingHoursFromTextFileLines(lines);
            string[] expected = { "Input invalid" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateWorkingHoursFromTextFileLinesTestMissingInformationFromAnyLine()
        {
            Program runner = new Program();
            string[] lines = new string[] { ";HRM Stuff;200-20+50",
                                            "Marto;Drinking tea;30",
                                            "Joro;Looking for the meaning of life;42",
                                            "Joro;Helping the others;58-160" };
            string[] actual = runner.CalculateWorkingHoursFromTextFileLines(lines);
            string[] expected = { "Input invalid" };

            CollectionAssert.AreEqual(expected, actual);

            string[] lines2 = new string[] { "Marto;HRM Stuff;200-20+50",
                                            "Marto;30",
                                            "Joro;Looking for the meaning of life;42",
                                            "Joro;;58-160" };
            string[] actual2 = runner.CalculateWorkingHoursFromTextFileLines(lines);
            string[] expected2 = { "Input invalid" };

            CollectionAssert.AreEqual(expected2, actual2);
            string[] lines3 = new string[] { "Marto;HRM Stuff;200-20+50",
                                            "Marto;Drinking tea;30",
                                            "Joro;Looking for the meaning of life;",
                                            "Joro;;58-160" };
            string[] actual3 = runner.CalculateWorkingHoursFromTextFileLines(lines);
            string[] expected3 = { "Input invalid" };

            CollectionAssert.AreEqual(expected3, actual3);
        }

        [TestMethod]
        public void CalculateSimpleExpressionTestNormalCase()
        {
            string expression = "200-20+50";
            Program runner = new Program();
            double actual = runner.CalculateSimpleExpression(expression);
            double expected = 230.00;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CalculateSimpleExpressionTestNullCase()
        {
            Program runner = new Program();
            runner.CalculateSimpleExpression(null);
        }

        [TestMethod]
        public void CalculateSimpleExpressionTestExpressionWithOneNumber()
        {
            string expression = "200";
            Program runner = new Program();
            double actual = runner.CalculateSimpleExpression(expression);
            double expected = 200.00;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateSimpleExpressionTestExpressionWithOneZeroNumber()
        {
            string expression = "0";
            Program runner = new Program();
            double actual = runner.CalculateSimpleExpression(expression);
            double expected = 0.00;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateSimpleExpressionTestExpressionWithEqualCountOfOperatorsAndNumbers()
        {
            string expression = "-200-20+20";
            Program runner = new Program();
            double actual = runner.CalculateSimpleExpression(expression);
            double expected = -200.00;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateSimpleExpressionTestNegativeSumOfExpression()
        {
            string expression = "40-50";
            Program runner = new Program();
            double actual = runner.CalculateSimpleExpression(expression);
            double expected = -10.00;
            Assert.AreEqual(expected, actual);
        }
    }
}
