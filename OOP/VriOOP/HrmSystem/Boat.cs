using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmSystem
{
    public class Boat : IComparable<Boat>
    {
        public Boat(string name)
        {
            this.Name = name;
        }
        public Boat(string name, int lenght)
        {
            this.Name = name;
            this.Lenght = lenght;
        }
        public string Name { get; set; }
        public int Lenght { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            string boat = "The name is: " + this.Name;

            return boat;
        }

        public int CompareTo(Boat other)
        {
            return this.Lenght.CompareTo(other.Lenght);
        }
    }
}
