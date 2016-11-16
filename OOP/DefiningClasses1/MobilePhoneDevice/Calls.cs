using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneDevice
{
    class Calls
    {
        private string phoneNumber;
        private ulong duration;


        public Calls(string phonenumber, ulong duration)
        {
            this.DateTime = DateTime.Now;
            this.PhoneNumber = phonenumber;
            this.Duration = duration;
        }

        public DateTime DateTime { get; set; }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Phonenumber can not be null or empty!");
                }

                if (value.Length != 10)
                {
                    throw new ArgumentException("Phonenumber must be in correct format!");
                }

                this.phoneNumber = value;
            }
        }

        public ulong Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Duaration can not be a negative number!");
                }

                this.duration = value;
            }
        }
        public override string ToString()
        {
            string calls = "";
            calls = calls + "PhoneNumber is: " + this.phoneNumber + " And the duration is : " + this.duration;

            return calls;
        }


    }
}
