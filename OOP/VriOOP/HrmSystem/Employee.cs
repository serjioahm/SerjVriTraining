using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmSystem
{
    class Employee
    {
        public static int EmployeeCounter { get; set; }

        public Employee(string firstName)
        {
            EmployeeCounter++;
            this.FirstName = firstName;
        }
        public Employee(string firstName, string lastName)
            : this(firstName)
        {
            this.LastName = lastName;
        }
        public Employee(string firstName, string lastName, string email, string egn, DateTime birthDay, DateTime dateOfJoining)
            : this(firstName, lastName)
        {
            this.Email = email;
            this.Egn = egn;
            this.Birthday = birthDay;
            this.DateOfJoining = dateOfJoining;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string Email { get; set; }
        public string Egn { get; set; }
        public DateTime Birthday { get; set; }

        public string BirthdayStr
        {
            get
            {
                return this.Birthday.ToString("yyyy-MM-dd");
            }
        }
        public DateTime DateOfJoining { get; set; }

        public int CalculateAge()
        {
            TimeSpan yearsPassed = DateTime.Today - this.Birthday;

            //if (DateTime.Now.Month < this.Birthday.Month || (DateTime.Now.Month == this.Birthday.Month && DateTime.Now.Day < this.Birthday.Day))
            //{
            //    yearsPassed--;
            //}
            return (int)yearsPassed.TotalDays/365;
        }

        public void PrintNameAndAge()
        {
            Console.WriteLine(this.FullName + " " + CalculateAge());
        }
    }
}
