using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmSystem
{
    class Shipyard
    {
        private List<Boat> BoatHistory;
        public Shipyard(string name, string address, string email)
        {
            this.Name = name;
            this.Address = address;
            this.Email = email;
            BoatHistory = new List<Boat>();
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public void AddBoat(Boat boatName)
        {
            this.BoatHistory.Add(boatName);
        }

        public List<Boat> Search(string name = "", int number = 0, int length = 0)
        {
            List<Boat> resultBoats = new List<Boat>();
            if (!string.IsNullOrEmpty(name))
            {
                resultBoats = SearchByName(name);
            }
            if (number > 0)
            {
                resultBoats.AddRange(SearchByNumber(number));
            }
            if (length > 0)
            {
                resultBoats.AddRange(SearchByLength(length));
            }

            return resultBoats;
        }
        private List<Boat> SearchByName(string searchName)
        {
            List<Boat> resultBoats = new List<Boat>();
            foreach (var item in BoatHistory)
            {
                if (item.Name.Contains(searchName))
                {
                    resultBoats.Add(item);
                }
            }

            return resultBoats;
        }

        private List<Boat> SearchByNumber(int searchNumber)
        {
            List<Boat> resultBoats = new List<Boat>();
            foreach (var item in BoatHistory)
            {
                if (item.Number == searchNumber)
                {
                    resultBoats.Add(item);
                }
            }

            return resultBoats;
        }

        private List<Boat> SearchByLength(int searchLength)
        {
            List<Boat> resultBoats = new List<Boat>();
            foreach (var item in BoatHistory)
            {
                if (item.Lenght == searchLength)
                {
                    resultBoats.Add(item);
                }
            }

            return resultBoats;
        }
        public void ShowAllBoats()
        {
            Console.WriteLine("All created boats:");

            this.BoatHistory.Sort();
            foreach (var boat in this.BoatHistory)
            {
                Console.WriteLine(boat.ToString());
            }
        }

    }
}
