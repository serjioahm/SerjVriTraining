using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneDevice
{
    public class GSM
    {
        //Problem 1. -> fields
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private List<Calls> CallHistory = new List<Calls>();
        //private List<Calls> CallHistory { get; set; }
        private decimal CallPricePerSecond = 0.37m;

        // 6. Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
        // static field for iPhone4S

        private static GSM iPhone4S;
        //Problem 2. -> constructor
        static GSM()
        {
            iPhone4S = new GSM("IPhone 4S", "Apple", 1300.00m, "Telenor",
                new Battery("Apple", 8, 200, Battery.BatType.LiPo),
                new Display(960, 640, 16000000));
        }
        public GSM()
        {

        }
        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            CallHistory = new List<Calls>();
        }

        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
            : this(model, manufacturer)
        {
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        //Problem 5. ->Properties
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model can not be null or empty.");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Manufacturer can not be null or empty.");
                }

                this.manufacturer = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price can not be a negative number.");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Owner can not be null or empty.");
                }

                this.owner = value;
            }
        }

        public Battery Battery { get; set; }
        public Display Display { get; set; }

        //add call method (takes number as a string and duaration - dateTime is always NOW)
        public void AddCall(string currentPhoneNumber, ulong currDuration)
        {
            this.CallHistory.Add(new Calls(currentPhoneNumber, currDuration));
        }

        //remove call 
        public void DeleteCall(int position)
        {
            if ((this.CallHistory.Count <= position - 1) || (position - 1 < 0))
            {
                throw new ApplicationException("Such call history log does not exist!");
            }
            this.CallHistory.RemoveAt(position - 1);
        }

        //Problem 12
        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }
        //Problem 12
        public void ShowCallHistory()
        {
            Console.WriteLine("Current call history:");
            //int indexer = 1;
            foreach (var call in this.CallHistory)
            {
                //Console.Write(indexer++);
                //Console.Write(" ---> ");
                Console.WriteLine(call.ToString());
            }
        }
        /* Add a method that calculates the total price of the calls in the call history.
          Assume the price per minute is fixed and is provided as a parameter. */
        public decimal TotalCallPrice()
        {
            ulong allDuration = 0;

            foreach (var call in this.CallHistory)
            {
                allDuration += call.Duration;
            }

            return allDuration * CallPricePerSecond;
        }
        // 6. IPhone4S property
        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }
        // 4. Add a method in the GSM class for displaying all information about it. Try to override ToString().
        public override string ToString()
        {
            StringBuilder stringCreator = new StringBuilder();
            stringCreator.Append("GSM Specifications: ");
            stringCreator.Append(this.model);
            stringCreator.AppendLine();
            stringCreator.Append(this.manufacturer);
            stringCreator.AppendLine();
            stringCreator.Append(this.price);
            stringCreator.AppendLine();
            stringCreator.Append(this.owner);
            stringCreator.AppendLine();
            stringCreator.Append("GSM Battery Specifications : Model -" + this.Battery.Model + ", Type - " + this.Battery.BatteryType +
                ", talk time - " + this.Battery.HoursTalk + ", idle time - " + this.Battery.HoursIdle);
            stringCreator.AppendLine();
            stringCreator.Append("GSM Display Specifications : Height - " + this.Display.Height + " , Width - " + this.Display.Width + 
                " , Number of Colors - " + this.Display.NumberOfColors);
            stringCreator.AppendLine();

            return stringCreator.ToString();
        }
    }
}
