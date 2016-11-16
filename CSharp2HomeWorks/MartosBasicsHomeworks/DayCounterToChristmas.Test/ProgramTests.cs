using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayCounterToChristmas.Test
{
    [TestClass]
    public class ProgramTests

    {
        [TestMethod]
        public void DayCounterToChristmas()
        {
            Program runner = new Program();
            runner.DayCounterToChristmas();
        }
    }
}
