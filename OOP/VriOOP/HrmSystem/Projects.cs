using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmSystem
{
    class Projects
    {
        public Projects(string name, int number, int length, Employee boss, ProjectStatus status)
        {
            this.Name = name;
            this.Number = number;
            this.Length = length;
            this.Status = status;
            this.Boss = boss;
        }

        public string Name { get; set; }
        public int Number { get; set; }
        public int Length { get; set; }

        public Employee Boss { get; set; }
        public ProjectStatus Status { get; set; }

        public enum ProjectStatus
        {
            Planing,
            InProgress,
            ReadyForConstruction,
            Constructed
        }
        public override string ToString()
        {
            string project = "";
            project = "Name of the project : " + this.Name + " And the number of the project is:" + this.Number +
                ", the boss:" + this.Boss.FullName + ", the status:" + Status.ToString();

            return project;
        }

    }
}
