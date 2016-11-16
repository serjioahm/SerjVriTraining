using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleClass
{
    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Guid IdNumber { get; set; }

        //suzdavam 4ovek p osledniq na4in : ima msamo purvoto ime , ime i familiq ..., trite imena, purvo ime i godini, firstname last name i age, tri imena i godini, first name i ID, first last ID, tri imena i ID....AALLLL
        public Person(string firstName)
        {
            this.FirstName = firstName;
        }

        public Person(string firstName, string lastName)
            :this(firstName)
        {
            this.LastName = lastName;
        }

        public Person(string firstName, string middleName, string lastName)
            :this(firstName, lastName)
        {
            this.MiddleName = middleName;
        }

        public Person(string firstName, int age)
            :this(firstName)
        {
            this.Age = age;
        }
        public Person(string firstName, string lastName, int age)
            :this(firstName, age)
        {
            this.LastName = lastName;
        }
        public Person(string firstName, string middleName, string lastName, int age)
            :this(firstName,middleName,lastName)
        {
            this.Age = age;
        }
        public Person(string firstName, Guid idNumber)
            :this(firstName)
        {
            this.IdNumber = idNumber;
        }
        public Person(string firstName, string lastName, Guid idNumber)
            :this(firstName, lastName)
        {
            this.IdNumber = idNumber;
        }
        public Person(string firstName, string middleName, string lastName, Guid idNumber)
            : this(firstName, middleName, lastName)
        {
            this.IdNumber = idNumber;
        }
        public Person(string firstName, string middleName, string lastName, Guid idNumber, int age)
            :this(firstName, middleName, lastName,age)
        {
            this.IdNumber = idNumber;
        }
    }
}
