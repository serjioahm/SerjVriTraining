using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayCounterToChristmas
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            int numberOfDays = p.DayCounterToChristmas();
            Console.WriteLine(numberOfDays);
        }

        public int DayCounterToChristmas()
        {
            DateTime today = DateTime.Today;
            //int overallDays=0;
            //TimeSpan difference = date - date;
            //int days = (date-date).Days;
            DateTime xmas;
            int workDays = 0;

            if (today.CompareTo(new DateTime(today.Year, 12, 25)) > 0)
                xmas = new DateTime(today.Year + 1, 12, 25);
            else
                xmas = new DateTime(today.Year, 12, 25);

            int daysUntilChristmas = xmas.Subtract(today).Days;

            DateTime CurrentDate = today;
            while (daysUntilChristmas > 0)
            {
                CurrentDate = CurrentDate.AddDays(1);

                if (CurrentDate.DayOfWeek != DayOfWeek.Saturday &&
                    CurrentDate.DayOfWeek != DayOfWeek.Sunday &&
                    CurrentDate.DayOfWeek != DayOfWeek.Friday)
                {
                    workDays++;
                }
                daysUntilChristmas--;
            }

            return workDays;
        }

    }
}
