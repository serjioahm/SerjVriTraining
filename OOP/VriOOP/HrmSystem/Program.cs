using MyExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HrmSystem.Projects;

namespace HrmSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Marto";
            string lastName = "Abrashev";
            string email = "headsExploding@abv.bg";
            string egn = "9901010101";
            DateTime birthday = new DateTime(1999, 01, 01);
            DateTime dateOfJoining = new DateTime(2013, 02, 25);

            Employee marto = new Employee(firstName, lastName, email, egn, birthday, dateOfJoining);
            //Employee marto2 = new Employee(firstName, lastName, email, egn, birthday, dateOfJoining);
            Employee marto2 = marto;
            marto.PrintNameAndAge();
            Console.WriteLine("Number of employees is: " + Employee.EmployeeCounter);
            Console.WriteLine();


            List<int> listExp = new List<int>();
            int[] arrExp = new int[] { 2, 3, 4, 5, 6 };
            listExp = arrExp.ToList();

            int min = listExp.Min();
            Console.WriteLine("The min is: " + min);
            int max = listExp.Max();
            Console.WriteLine("The max is: " + max);
            double avgExample = arrExp.Avg();
            Console.WriteLine("The avg is: {0:F2}", avgExample);
            int sum = listExp.Sum();
            Console.WriteLine("The sum is: " + sum);
            Console.WriteLine();



            string name = "The iceCreamHouse";
            //name.PrintOnConsole();
            int number = 5;
            int length = 10;
            ProjectStatus status = ProjectStatus.ReadyForConstruction;
            Projects testProject = new Projects(name, number, length, marto, status);
            Console.WriteLine(testProject);
            Console.WriteLine();

            Shipyard testShipyard = new Shipyard("Nokia", "TelerikCorp", "headsExploding@abv.bg");
            testShipyard.AddBoat(new Boat("TheBestBoatEver", 1));
            testShipyard.AddBoat(new Boat("AveMariq", 2));
            testShipyard.AddBoat(new Boat("MariqAve", 3));
            testShipyard.ShowAllBoats();
            Shipyard testShipyardTwo = new Shipyard("Sony", "Corp", "what@abv.bg");
            testShipyard.AddBoat(new Boat("TheSecondBestBoatEver", 1));

            testShipyard.AddBoat(new Boat("MariqAriAve", 3));
            //testShipyard.Search("marto");
            //testShipyard.Search("marto", 55);
            //testShipyard.Search("marto", 55, 10);
            //testShipyard.Search(name: "marto", length: 10);
            //testShipyard.Search(number: 5);

        }
    }
}

